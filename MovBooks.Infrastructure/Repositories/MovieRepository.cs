using Microsoft.EntityFrameworkCore;
using MovBooks.Core.Entities;
using MovBooks.Core.Interfaces;
using MovBooks.Infrastructure.Data;
using System.Threading.Tasks;

namespace MovBooks.Infrastructure.Repositories
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        public MovieRepository(MovBooksContext context) : base(context)
        {
        }

        public async Task<Movie> FindByTitle(int? id, string title)
        {
            var movie = await _entities
                        .FirstOrDefaultAsync(x => (id == null || x.Id != id) && x.Title.ToLower() == title.ToLower());
            return movie;
        }
    }
}
