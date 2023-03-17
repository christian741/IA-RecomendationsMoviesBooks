using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.ML;
using Microsoft.ML;
using MovBooks.Api.Responses;
using MovBooks.Core.CustomEntities;
using MovBooks.Core.DataStructures;
using MovBooks.Core.DTOs;
using MovBooks.Core.Entities;
using MovBooks.Core.Interfaces;
using MovBooks.Core.Jobs.Interfaces;
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
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _haccess;
        private readonly IMapper _mapper;
        private readonly ILogger<MoviesController> _logger;
        private IBackgroundTaskQueue _queue;

        public MoviesController(IMovieService movieService, IUserService userService, IHttpContextAccessor haccess, IMapper mapper, ILogger<MoviesController> logger, IBackgroundTaskQueue queue)
        {
            _movieService = movieService;
            _userService = userService;
            _haccess = haccess;
            _mapper = mapper;
            _logger = logger;
            _queue = queue;
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

        [HttpGet]
        [Route("getRecommendMovieUser/{userId}")]
        public ActionResult getRecommendMovieUser([FromQuery] MovieQueryFilter filters, int userId)
        {

            var claimsIdentity = _haccess.HttpContext.User.Identity as ClaimsIdentity;
            var userClaim = claimsIdentity.FindFirst("user");
            var user = JsonConvert.DeserializeObject<User>(userClaim.Value);

            if (user == null)
            {
                return NotFound();
            }
            // 1. Create the ML.NET environment and load the already trained model
            MLContext mlContext = new MLContext();
            return NotFound();
            /* List<(int movieId, float normalizedScore)> ratings = new List<(int movieId, float normalizedScore)>();
             var MovieRatings = _userService.GetProfileWatchedMovies(filters,id);
             List<Movie> WatchedMovies = new List<Movie>();

             foreach ((int movieId, int movieRating) in MovieRatings)
             {
                 WatchedMovies.Add(_movieService.GetById(movieId));
             }

             return Ok();*/

            /*

            MovieRatingPrediction prediction = null;
            foreach (var movie in _movieService.GetTrendingMovies)
            {
                // Call the Rating Prediction for each movie prediction
                prediction = _model.Predict(new MovieRating
                {
                    userId = id.ToString(),
                    movieId = movie.MovieID.ToString()
                });

                // Normalize the prediction scores for the "ratings" b/w 0 - 100
                float normalizedscore = Sigmoid(prediction.Score);

                // Add the score for recommendation of each movie in the trending movie list
                ratings.Add((movie.MovieID, normalizedscore));
            }

            //3. Provide rating predictions to the view to be displayed
            ViewData["watchedmovies"] = WatchedMovies;
            ViewData["ratings"] = ratings;
            ViewData["trendingmovies"] = _movieService.GetTrendingMovies;
            return View(activeprofile);*/
        }
    }
}
