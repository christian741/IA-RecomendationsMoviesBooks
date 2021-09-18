using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovBooks.Api.Responses;
using MovBooks.Core.CustomEntities;
using MovBooks.Core.DTOs;
using MovBooks.Core.Entities;
using MovBooks.Core.Interfaces;
using MovBooks.Core.QueryFilters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovBooks.Api.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class RatingsMoviesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRatingMovieService _ratingMovieService;

        public RatingsMoviesController(IRatingMovieService ratingMovieService, IMapper mapper)
        {
            _ratingMovieService = ratingMovieService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetRatingsMovies([FromQuery] RatingMovieQueryFilter filters)
        {
            var ratingsMovies = _ratingMovieService.GetAllInclude(filters);

            var metadata = new Metadata
            {
                TotalCount = ratingsMovies.TotalCount,
                PageSize = ratingsMovies.PageSize,
                CurrentPage = ratingsMovies.CurrentPage,
                TotalPages = ratingsMovies.TotalPages,
                HasNextPage = ratingsMovies.HasNextPage,
                HasPreviousPage = ratingsMovies.HasPreviousPage
            };

            var response = new ApiResponse<IEnumerable<RatingMovie>>(ratingsMovies)
            {
                Meta = metadata
            };

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRatingMovie(int id)
        {
            var ratingMovie = await _ratingMovieService.GetById(id);
            if (ratingMovie == null)
            {
                return NotFound();
            }
            var ratingMovieDto = _mapper.Map<RatingMovieDto>(ratingMovie);
            var response = new ApiResponse<RatingMovieDto>(ratingMovieDto);
            return Ok(response);
        }

        [HttpGet]
        [Route("find")]
        public async Task<IActionResult> Find(int userId, int movieId)
        {
            var ratingMovie = await _ratingMovieService.Find(userId, movieId);
            if (ratingMovie == null)
            {
                return NotFound();
            }
            var ratingMovieDto = _mapper.Map<RatingMovieDto>(ratingMovie);
            var response = new ApiResponse<RatingMovieDto>(ratingMovieDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> PostRatingMovie(RatingMovieDto ratingMovieDto)
        {
            var ratingMovie = _mapper.Map<RatingMovie>(ratingMovieDto);
            await _ratingMovieService.Insert(ratingMovie);

            ratingMovieDto = _mapper.Map<RatingMovieDto>(ratingMovie);
            var response = new ApiResponse<RatingMovieDto>(ratingMovieDto);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRatingMovie(int id, RatingMovieDto ratingMovieDto)
        {
            var ratingMovie = _mapper.Map<RatingMovie>(ratingMovieDto);
            if (ratingMovie.Id != id)
            {
                return BadRequest();
            }
            var result = await _ratingMovieService.Update(ratingMovie);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRatingMovie(int id)
        {
            var result = await _ratingMovieService.Delete(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
