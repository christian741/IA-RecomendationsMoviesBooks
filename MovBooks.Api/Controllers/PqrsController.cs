using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovBooks.Core.Interfaces;
using MovBooks.Core.QueryFilters;
using MovBooks.Core.DTOs;
using MovBooks.Core.CustomEntities;
using MovBooks.Api.Responses;
using Newtonsoft.Json;
using MovBooks.Core.Entities;
using MovBooks.Api.Models;

namespace MovBooks.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PqrsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPqrService _pqrService;

        public PqrsController(IPqrService pqrService, IMapper mapper)
        {
            _mapper = mapper;
            _pqrService = pqrService;
        }

        // GET: api/Pqrs
        [HttpGet]
        public IActionResult GetPqrs([FromQuery] PqrQueryFilter filters)
        {
            var pqrs = _pqrService.GetAllIncludeUser(filters);

            var metadata = new Metadata
            {
                TotalCount = pqrs.TotalCount,
                PageSize = pqrs.PageSize,
                CurrentPage = pqrs.CurrentPage,
                TotalPages = pqrs.TotalPages,
                HasNextPage = pqrs.HasNextPage,
                HasPreviousPage = pqrs.HasPreviousPage
            };

            var response = new ApiResponse<IEnumerable<Pqr>>(pqrs)
            {
                Meta = metadata
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(response);
        }

        // GET: api/Pqrs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPqr(int id)
        {
            var pqr = await _pqrService.GetByIdIncludeUser(id);
            if (pqr == null)
            {
                return NotFound();
            }
            var response = new ApiResponse<Pqr>(pqr);
            return Ok(response);
        }

        // POST: api/Pqrs
        [HttpPost]
        public async Task<IActionResult> PostPqr(PqrDto pqrDto)
        {
            var pqr = _mapper.Map<Pqr>(pqrDto);
            await _pqrService.Insert(pqr);

            pqrDto = _mapper.Map<PqrDto>(pqr);
            var response = new ApiResponse<PqrDto>(pqrDto);
            return Ok(response);
        }

        // PUT: api/Pqrs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPqr(int id, PqrDto pqrDto)
        {
            var pqr = _mapper.Map<Pqr>(pqrDto);
            if (pqr.Id != id)
            {
                return BadRequest();
            }
            var result = await _pqrService.Update(pqr);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        // DELETE: api/Pqrs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Pqr>> DeletePqr(int id)
        {
            var result = await _pqrService.Delete(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
