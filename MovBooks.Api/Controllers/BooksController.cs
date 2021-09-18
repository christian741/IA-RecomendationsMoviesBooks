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

namespace MovBooks.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService, IMapper mapper)
        {
            _mapper = mapper;
            _bookService = bookService;
        }

        // GET: api/Books
        [HttpGet]
        public IActionResult GetBooks([FromQuery] BookQueryFilter filters)
        {
            var books = _bookService.GetAll(filters);
            var bookDtos = _mapper.Map<IEnumerable<BookDto>>(books);

            var metadata = new Metadata
            {
                TotalCount = books.TotalCount,
                PageSize = books.PageSize,
                CurrentPage = books.CurrentPage,
                TotalPages = books.TotalPages,
                HasNextPage = books.HasNextPage,
                HasPreviousPage = books.HasPreviousPage
            };

            var response = new ApiResponse<IEnumerable<BookDto>>(bookDtos)
            {
                Meta = metadata
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(response);
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            var book = await _bookService.GetById(id);
            if (book == null)
            {
                return NotFound();
            }
            var bookDto = _mapper.Map<BookDto>(book);
            var response = new ApiResponse<BookDto>(bookDto);
            return Ok(response);
        }

        // POST: api/Books
        [HttpPost]
        public async Task<IActionResult> PostBook(BookDto bookDto)
        {
            bookDto.Aggregated = true;
            var book = _mapper.Map<Book>(bookDto);
            await _bookService.Insert(book);

            bookDto = _mapper.Map<BookDto>(book);
            var response = new ApiResponse<BookDto>(bookDto);
            return Ok(response);
        }

        // PUT: api/Books/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, BookDto bookDto)
        {
            bookDto.Aggregated = true;
            var book = _mapper.Map<Book>(bookDto);
            if (book.Id != id)
            {
                return BadRequest();
            }
            var result = await _bookService.Update(book);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var result = await _bookService.Delete(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpGet]
        [Route("findByTitle")]
        public async Task<ActionResult<Book>> FindByTitle(int? id, string title)
        {
            var book = await _bookService.FindByTitle(id, title);
            var bookDto = _mapper.Map<BookDto>(book);
            var response = new ApiResponse<BookDto>(bookDto);
            return Ok(response);
        }
    }
}
