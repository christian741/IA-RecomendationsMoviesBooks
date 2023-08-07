using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovBooks.Api.Responses;
using MovBooks.Core.CustomEntities;
using MovBooks.Core.DTOs;
using MovBooks.Core.Entities;
using MovBooks.Core.Interfaces.Services;
using MovBooks.Core.QueryFilters;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovBooks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IGenreService _GenreService;

        public GenreController(IMapper mapper, IGenreService GenreService)
        {
            _mapper = mapper;
            _GenreService = GenreService;
        }


        [HttpGet]
        public IActionResult getGenres([FromQuery] GenreQueryFilter filters)
        {
            var Genres = _GenreService.GetAll(filters);
            var GenresDtos = _mapper.Map<IEnumerable<GenreDto>>(Genres);

            var metadata = new Metadata
            {
                TotalCount = Genres.TotalCount,
                PageSize = Genres.PageSize,
                CurrentPage = Genres.CurrentPage,
                TotalPages = Genres.TotalPages,
                HasNextPage = Genres.HasNextPage,
                HasPreviousPage = Genres.HasPreviousPage
            };

            var response = new ApiResponse<IEnumerable<GenreDto>>(GenresDtos)
            {
                Meta = metadata
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getGenre(int id)
        {
            var Genre = await _GenreService.GetById(id);
            if (Genre == null)
            {
                return NotFound();
            }
            var GenreDto = _mapper.Map<GenreDto>(Genre);
            var response = new ApiResponse<GenreDto>(GenreDto);
            return Ok(response);
        }


        [HttpPost]
        public async Task<IActionResult> saveGenre(GenreDto GenreDto)
        {
            var id = GenreDto.IdMorph;
            var type = GenreDto.TypeMorph;
            var Genre = _mapper.Map<Genre>(GenreDto);
            await _GenreService.Insert(Genre, id, type);

            GenreDto = _mapper.Map<GenreDto>(Genre);
            var response = new ApiResponse<GenreDto>(GenreDto);
            return Ok(response);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> updateGenre(int id, GenreDto GenreDto)
        {

            var Genre = _mapper.Map<Genre>(GenreDto);
            if (Genre.Id != id)
            {
                return BadRequest();
            }
            var result = await _GenreService.Update(Genre);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteGenre(int id)
        {
            var result = await _GenreService.Delete(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
