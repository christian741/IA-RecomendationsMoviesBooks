using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovBooks.Api.Responses;
using MovBooks.Core.CustomEntities;
using MovBooks.Core.DTOs;
using MovBooks.Core.Entities;
using MovBooks.Core.Interfaces;
using MovBooks.Core.QueryFilters;
using Newtonsoft.Json;

namespace MovBooks.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;

        public MoviesController(IMovieService movieService, IMapper mapper)
        {
            _mapper = mapper;
            _movieService = movieService;
        }

        // GET: api/Movies
        [HttpGet]
        public IActionResult GetMovies([FromQuery] MovieQueryFilter filters)
        {
            var movies = _movieService.GetAll(filters);
            var moviesDto = _mapper.Map<IEnumerable<MovieDto>>(movies);

            var metadata = new Metadata
            {
                TotalCount = movies.TotalCount,
                PageSize = movies.PageSize,
                CurrentPage = movies.CurrentPage,
                TotalPages = movies.TotalPages,
                HasNextPage = movies.HasNextPage,
                HasPreviousPage = movies.HasPreviousPage
            };

            var response = new ApiResponse<IEnumerable<MovieDto>>(moviesDto)
            {
                Meta = metadata
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(response);
        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovie(int id)
        {
            var movie = await _movieService.GetById(id);
            if (movie == null)
            {
                return NotFound();
            }
            var movieDto = _mapper.Map<MovieDto>(movie);
            var response = new ApiResponse<MovieDto>(movieDto);
            return Ok(response);
        }

        // POST: api/Movies
        [HttpPost]
        public async Task<IActionResult> PostMovie(MovieDto movieDto)
        {
            movieDto.Aggregated = true;
            var movie = _mapper.Map<Movie>(movieDto);
            await _movieService.Insert(movie);

            movieDto = _mapper.Map<MovieDto>(movie);
            var response = new ApiResponse<MovieDto>(movieDto);
            return Ok(response);
        }

        // PUT: api/Movies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, MovieDto movieDto)
        {
            movieDto.Aggregated = true;
            var movie = _mapper.Map<Movie>(movieDto);
            if (movie.Id != id)
            {
                return BadRequest();
            }
            var result = await _movieService.Update(movie);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var result = await _movieService.Delete(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpGet]
        [Route("findByTitle")]
        public async Task<IActionResult> FindByTitle(int? id, string title)
        {
            var movie = await _movieService.FindByTitle(id, title);
            var movieDto = _mapper.Map<MovieDto>(movie);
            var response = new ApiResponse<MovieDto>(movieDto);
            return Ok(response);
        }
    }
}
