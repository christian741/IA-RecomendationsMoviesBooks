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
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovBooks.Api.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class RatingsBooksController : ControllerBase
    {
        private readonly IRatingBookService _ratingBookService;
        private readonly IMapper _mapper;

        public RatingsBooksController(IRatingBookService ratingBookService, IMapper mapper)
        {
            _ratingBookService = ratingBookService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetRatingsBooks([FromQuery] RatingBookQueryFilter filters)
        {
            var ratingsBooks = _ratingBookService.GetAllInclude(filters);

            var metadata = new Metadata
            {
                TotalCount = ratingsBooks.TotalCount,
                PageSize = ratingsBooks.PageSize,
                CurrentPage = ratingsBooks.CurrentPage,
                TotalPages = ratingsBooks.TotalPages,
                HasNextPage = ratingsBooks.HasNextPage,
                HasPreviousPage = ratingsBooks.HasPreviousPage
            };

            var response = new ApiResponse<IEnumerable<RatingBook>>(ratingsBooks)
            {
                Meta = metadata
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRatingBook(int id)
        {
            var ratingBook = await _ratingBookService.GetById(id);
            if (ratingBook == null)
            {
                return NotFound();
            }
            var ratingBookDto = _mapper.Map<RatingBookDto>(ratingBook);
            var response = new ApiResponse<RatingBookDto>(ratingBookDto);
            return Ok(response);
        }

        [HttpGet]
        [Route("find")]
        public async Task<IActionResult> FindRatingBook(int userId, int bookId)
        {
            var ratingBook = await _ratingBookService.Find(userId, bookId);
            if (ratingBook == null)
            {
                return NotFound();
            }
            var ratingBookDto = _mapper.Map<RatingBookDto>(ratingBook);
            var response = new ApiResponse<RatingBookDto>(ratingBookDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> PostRatingBook(RatingBookDto ratingBookDto)
        {
            var ratingBook = _mapper.Map<RatingBook>(ratingBookDto);
            await _ratingBookService.Insert(ratingBook);

            ratingBookDto = _mapper.Map<RatingBookDto>(ratingBook);
            var response = new ApiResponse<RatingBookDto>(ratingBookDto);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRatingBook(int id, RatingBookDto ratingBookDto)
        {
            var ratingBook = _mapper.Map<RatingBook>(ratingBookDto);
            if (ratingBook.Id != id)
            {
                return BadRequest();
            }
            var result = await _ratingBookService.Update(ratingBook);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRatingBook(int id)
        {
            var result = await _ratingBookService.Delete(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
