using MovBooks.Core.Entities;
using System.Threading.Tasks;

namespace MovBooks.Core.Interfaces.Repositorys
{
    public interface IGenreRepository : IRepository<Genre>
    {
        Task<Genre> FindByName(string name);

        Task saveGenreBooks(Genre gender, Book book);

        Task saveGenreMovies(Genre gender, Movie movie);
    }
}
