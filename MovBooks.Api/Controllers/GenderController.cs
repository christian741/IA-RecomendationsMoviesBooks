using AutoMapper;
using Newtonsoft.Json;
using MovBooks.Core.DTOs;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using MovBooks.Core.Interfaces;
using MovBooks.Core.QueryFilters;
using MovBooks.Api.Responses;
using MovBooks.Core.CustomEntities;
using MovBooks.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using MovBooks.Core.Interfaces.Services;

namespace MovBooks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenderController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IGenderService _genderService;

        public GenderController(IMapper mapper, IGenderService genderService)
        {
            _mapper = mapper;
            _genderService = genderService;
        }

        
        [HttpGet]
        public IActionResult getGenders([FromQuery] GenderQueryFilter filters)
        {
            var genders = _genderService.GetAll(filters);
            var gendersDtos = _mapper.Map<IEnumerable<GenderDto>>(genders);

            var metadata = new Metadata
            {
                TotalCount = genders.TotalCount,
                PageSize = genders.PageSize,
                CurrentPage = genders.CurrentPage,
                TotalPages = genders.TotalPages,
                HasNextPage = genders.HasNextPage,
                HasPreviousPage = genders.HasPreviousPage
            };

            var response = new ApiResponse<IEnumerable<GenderDto>>(gendersDtos)
            {
                Meta = metadata
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getGender(int id)
        {
            var gender = await _genderService.GetById(id);
            if (gender == null)
            {
                return NotFound();
            }
            var genderDto = _mapper.Map<GenderDto>(gender);
            var response = new ApiResponse<GenderDto>(genderDto);
            return Ok(response);
        }

      
        [HttpPost]
        public async Task<IActionResult> saveGender(GenderDto genderDto)
        {
           
            var gender = _mapper.Map<Gender>(genderDto);
            await _genderService.Insert(gender);

            genderDto = _mapper.Map<GenderDto>(gender);
            var response = new ApiResponse<GenderDto>(genderDto);
            return Ok(response);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> updateGender(int id, GenderDto genderDto)
        {
            
            var gender = _mapper.Map<Gender>(genderDto);
            if (gender.Id != id)
            {
                return BadRequest();
            }
            var result = await _genderService.Update(gender);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

       
        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteGender(int id)
        {
            var result = await _genderService.Delete(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
