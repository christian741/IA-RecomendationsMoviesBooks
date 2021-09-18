using MovBooks.Core.Entities;
using System.Threading.Tasks;

namespace MovBooks.Core.Interfaces
{
    public interface IMovieRepository : IRepository<Movie>
    {
        Task<Movie> FindByTitle(int? id, string title);
    }
}
