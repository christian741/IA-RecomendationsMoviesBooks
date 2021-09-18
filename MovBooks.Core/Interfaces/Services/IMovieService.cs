using MovBooks.Core.CustomEntities;
using MovBooks.Core.Entities;
using MovBooks.Core.QueryFilters;
using System.Threading.Tasks;

namespace MovBooks.Core.Interfaces
{
    public interface IMovieService
    {
        PagedList<Movie> GetAll(MovieQueryFilter filters);
        Task<Movie> GetById(int id);
        Task Insert(Movie movie);
        Task<bool> Update(Movie movie);
        Task<bool> Delete(int id);
        Task<Movie> FindByTitle(int? id, string title);
    }
}
