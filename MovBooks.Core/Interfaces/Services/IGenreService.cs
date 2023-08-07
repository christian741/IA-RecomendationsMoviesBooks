using MovBooks.Core.CustomEntities;
using MovBooks.Core.Entities;
using MovBooks.Core.QueryFilters;
using System.Threading.Tasks;

namespace MovBooks.Core.Interfaces.Services
{
    public interface IGenreService
    {

        PagedList<Genre> GetAll(GenreQueryFilter filters);
        Task<Genre> GetById(int id);
        Task Insert(Genre gender, int? id, string? type);
        Task<bool> Update(Genre gender);
        Task<bool> Delete(int id);

    }
}
