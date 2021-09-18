using MovBooks.Core.CustomEntities;
using MovBooks.Core.Entities;
using MovBooks.Core.QueryFilters;
using System.Threading.Tasks;

namespace MovBooks.Core.Interfaces
{
    public interface IRatingMovieService
    {
        PagedList<RatingMovie> GetAllInclude(RatingMovieQueryFilter filters);
        Task<RatingMovie> GetById(int id);
        Task<RatingMovie> Find(int userId, int movieId);
        Task Insert(RatingMovie ratingMovie);
        Task<bool> Update(RatingMovie ratingMovie);
        Task<bool> Delete(int id);
    }
}
