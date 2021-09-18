using MovBooks.Core.CustomEntities;
using MovBooks.Core.Entities;
using MovBooks.Core.QueryFilters;
using System.Threading.Tasks;

namespace MovBooks.Core.Interfaces
{
    public interface IPqrService
    {
        PagedList<Pqr> GetAllIncludeUser(PqrQueryFilter filters);
        Task<Pqr> GetByIdIncludeUser(int id);
        Task Insert(Pqr pqr);
        Task<bool> Update(Pqr pqr);
        Task<bool> Delete(int id);
    }
}
