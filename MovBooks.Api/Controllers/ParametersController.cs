using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovBooks.Api.Models;
using MovBooks.Api.Responses;
using MovBooks.Core.CustomEntities;
using MovBooks.Core.DTOs;
using MovBooks.Core.Entities;
using MovBooks.Core.Interfaces;
using MovBooks.Core.QueryFilters;
using Newtonsoft.Json;

namespace MovBooks.Api.Controllers
{
    [Authorize(Policy = Policies.Admin)]
    [Route("api/[controller]")]
    [ApiController]
    public class ParametersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IParameterService _parameterService;

        public ParametersController(IParameterService parameterService, IMapper mapper)
        {
            _mapper = mapper;
            _parameterService = parameterService;
        }

        // GET: api/Parameters
        [HttpGet]
        public IActionResult GetParameters([FromQuery] ParameterQueryFilter filters)
        {
            var parameters = _parameterService.GetAll(filters);
            var parametersDto = _mapper.Map<IEnumerable<ParameterDto>>(parameters);

            var metadata = new Metadata
            {
                TotalCount = parameters.TotalCount,
                PageSize = parameters.PageSize,
                CurrentPage = parameters.CurrentPage,
                TotalPages = parameters.TotalPages,
                HasNextPage = parameters.HasNextPage,
                HasPreviousPage = parameters.HasPreviousPage
            };

            var response = new ApiResponse<IEnumerable<ParameterDto>>(parametersDto)
            {
                Meta = metadata
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(response);
        }

        // GET: api/Parameters/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetParameter(int id)
        {
            var parameter = await _parameterService.GetById(id);
            if (parameter == null)
            {
                return NotFound();
            }
            var parameterDto = _mapper.Map<ParameterDto>(parameter);
            var response = new ApiResponse<ParameterDto>(parameterDto);
            return Ok(response);
        }

        // POST: api/Parameters
        [HttpPost]
        public async Task<IActionResult> PostParameter(ParameterDto parameterDto)
        {
            var parameter = _mapper.Map<Parameter>(parameterDto);
            await _parameterService.Insert(parameter);

            parameterDto = _mapper.Map<ParameterDto>(parameter);
            var response = new ApiResponse<ParameterDto>(parameterDto);
            return Ok(response);
        }

        // PUT: api/Parameters/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParameter(int id, ParameterDto parameterDto)
        {
            var parameter = _mapper.Map<Parameter>(parameterDto);
            if (parameter.Id != id)
            {
                return BadRequest();
            }
            var result = await _parameterService.Update(parameter);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        // DELETE: api/Parameters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParameter(int id)
        {
            var result = await _parameterService.Delete(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpGet]
        [Route("findByKey")]
        public async Task<ActionResult<Book>> FindByKey(string key, int? id)
        {
            var parameter = await _parameterService.FindByKey(key, id);
            var parameterDto = _mapper.Map<ParameterDto>(parameter);
            var response = new ApiResponse<ParameterDto>(parameterDto);
            return Ok(response);
        }
    }
}
