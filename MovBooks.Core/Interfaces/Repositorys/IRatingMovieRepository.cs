using MovBooks.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovBooks.Core.Interfaces
{
    public interface IRatingMovieRepository : IRepository<RatingMovie>
    {
        IEnumerable<RatingMovie> GetAllInclude();
        Task<RatingMovie> Find(int userId, int movieId);
    }
}
