
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using MovBooks.Api.Models;
using MovBooks.Api.Responses;
using MovBooks.Core.CustomEntities;
using MovBooks.Core.DTOs;
using MovBooks.Core.Entities;
using MovBooks.Core.Interfaces;
using MovBooks.Core.Jobs.Interfaces;
using MovBooks.Core.QueryFilters;
using Newtonsoft.Json;

namespace MovBooks.Api.Controllers
{
    [Authorize(Policy = Policies.Admin)]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private IBackgroundTaskQueue _queue;

        public UsersController(IMapper mapper, IUserService userService, IBackgroundTaskQueue queue)
        {
            _mapper = mapper;
            _userService = userService;
            _queue = queue;
        }

        [HttpGet]
        public IActionResult GetUsers([FromQuery] UserQueryFilter filters)
        {
            var users = _userService.GetAll(filters);
            var usersDto = _mapper.Map<IEnumerable<UserDto>>(users);

            var metadata = new Metadata
            {
                TotalCount = users.TotalCount,
                PageSize = users.PageSize,
                CurrentPage = users.CurrentPage,
                TotalPages = users.TotalPages,
                HasNextPage = users.HasNextPage,
                HasPreviousPage = users.HasPreviousPage
            };

            var response = new ApiResponse<IEnumerable<UserDto>>(usersDto)
            {
                Meta = metadata
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            var userDto = _mapper.Map<UserDto>(user);
            var response = new ApiResponse<UserDto>(userDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> PostUser(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            await _userService.Insert(user);

            userDto = _mapper.Map<UserDto>(user);
            var response = new ApiResponse<UserDto>(userDto);
            return Ok(response);
        }

        [HttpPut("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> PutUser(int id, UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            if (user.Id != id)
            {
                return BadRequest();
            }
            var result = await _userService.Update(user);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _userService.Delete(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("findByEmail")]
        public async Task<IActionResult> FindByEmail(string email)
        {
            var user = await _userService.FindByEmail(email);
            if (user == null)
            {
                return NotFound();
            }
            var userDto = _mapper.Map<UserDto>(user);
            var response = new ApiResponse<UserDto>(userDto);
            return Ok(response);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("findByNickname")]
        public async Task<IActionResult> FindByNickname(string nickname)
        {
            var user = await _userService.FindByNickname(nickname);
            if (user == null)
            {
                return NotFound();
            }
            var userDto = _mapper.Map<UserDto>(user);
            var response = new ApiResponse<UserDto>(userDto);
            return Ok(response);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("generateFakeData/{quantityUsers}")]
        public async Task<IActionResult> GenerateDataFakeAsync(int? quantityUsers)
        {
            _ = _queue.QueueBackgroundWorkItemAsync(async (token) => {
                if (quantityUsers == null)
                {
                   quantityUsers = 100;
                }
                await _userService.GenerateDataFakeAsync((int)quantityUsers);

            });
            return Ok("In progress..");
        }
    }
}
