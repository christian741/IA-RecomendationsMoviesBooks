using System.Linq;
using Microsoft.EntityFrameworkCore;
using MovBooks.Core.Entities;
using MovBooks.Core.Interfaces;
using MovBooks.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovBooks.Infrastructure.Repositories
{
    public class RatingMovieRepository : BaseRepository<RatingMovie>, IRatingMovieRepository
    {
        public RatingMovieRepository(MovBooksContext context) : base(context)
        {
        }

        public async Task<RatingMovie> Find(int userId, int movieId)
        {
            return await _entities.FirstOrDefaultAsync(x => x.UserId == userId && x.MovieId == movieId);
        }

        public IEnumerable<RatingMovie> GetAllInclude()
        {
            return _entities.Include(x => x.User).Include(x => x.Movie).AsEnumerable();
        }
    }
}
