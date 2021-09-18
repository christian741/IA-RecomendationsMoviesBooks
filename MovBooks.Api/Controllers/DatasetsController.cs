using Microsoft.AspNetCore.Mvc;
using MovBooks.Core.Interfaces;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using MovBooks.Core.Entities;
using System.Threading.Tasks;
using System.Data;
using LumenWorks.Framework.IO.Csv;

namespace MovBooks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatasetsController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IMovieService _movieService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public DatasetsController(IBookService bookService, IMovieService movieService, IWebHostEnvironment webHostEnvironment)
        {
            _bookService = bookService;
            _movieService = movieService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        [Route("books")]
        public async Task<IActionResult> LoadBooks()
        {
            var pathFile = Path.Combine(_webHostEnvironment.WebRootPath, "Datasets/kaggle/books.csv");
            var csvTable = new DataTable();
            using (var csvReader = new CsvReader(new StreamReader(System.IO.File.OpenRead(pathFile)), true))
            {
                csvTable.Load(csvReader);

                for (int i = 0; i < csvTable.Rows.Count; i++)
                {
                    var book = new Book { Title = csvTable.Rows[i][9].ToString() };
                    await _bookService.Insert(book);
                }
            }
            return Ok();
        }

        [HttpGet]
        [Route("movies")]
        public async Task<IActionResult> LoadMovies()
        {
            var pathFile = Path.Combine(_webHostEnvironment.WebRootPath, "Datasets/movielens/movies.csv");
            var csvTable = new DataTable();
            using (var csvReader = new CsvReader(new StreamReader(System.IO.File.OpenRead(pathFile)), true))
            {
                csvTable.Load(csvReader);

                for (int i = 0; i < csvTable.Rows.Count; i++)
                {
                    var movie = new Movie { Title = csvTable.Rows[i][1].ToString().Split("(")[0].TrimEnd() };
                    await _movieService.Insert(movie);
                }
            }
            return Ok();
        }
    }
}
