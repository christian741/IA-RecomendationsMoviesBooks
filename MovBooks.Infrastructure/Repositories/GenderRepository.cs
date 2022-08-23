using MovBooks.Core.Entities;
using MovBooks.Core.Interfaces;
using MovBooks.Infrastructure.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovBooks.Core.Interfaces.Repositorys;

namespace MovBooks.Infrastructure.Repositories
{
    public class GenderRepository : BaseRepository<Gender>, IGenderRepository
    {
        public GenderRepository(MovBooksContext context) : base(context) { }


        public async Task<Gender> FindByName(string name)
        {
            return await _entities.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());
        }

        public async Task saveGenderBooks(Gender gender, Book book)
        {
            gender.GenderBooks.Add(new GenderBooks()
            {
                Gender = gender,
                Book = book,
            });

            await _context.SaveChangesAsync();
        }

        public async Task saveGenderMovies(Gender gender, Movie movie)
        {
            gender.GenderMovies.Add(new GenderMovies()
            {
                Gender = gender,
                Movie = movie,
            });

            await _context.SaveChangesAsync();
        }
    }
}
