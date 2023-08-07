using Microsoft.EntityFrameworkCore;
using MovBooks.Core.Entities;
using MovBooks.Core.Interfaces.Repositorys;
using MovBooks.Infrastructure.Data;
using System.Threading.Tasks;

namespace MovBooks.Infrastructure.Repositories
{
    public class GenreRepository : BaseRepository<Genre>, IGenreRepository
    {
        public GenreRepository(MovBooksContext context) : base(context) { }


        public async Task<Genre> FindByName(string name)
        {
            return await _entities.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());
        }

        public async Task saveGenreBooks(Genre genre, Book book)
        {
            genre.GenreBooks.Add(new GenreBooks()
            {
                Genre = genre,
                Book = book,
            });

            await _context.SaveChangesAsync();
        }

        public async Task saveGenreMovies(Genre Genre, Movie movie)
        {
            Genre.GenreMovies.Add(new GenreMovies()
            {
                Genre = Genre,
                Movie = movie,
            });

            await _context.SaveChangesAsync();
        }
    }
}
