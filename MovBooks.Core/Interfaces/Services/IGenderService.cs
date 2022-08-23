using MovBooks.Core.CustomEntities;
using MovBooks.Core.Entities;
using MovBooks.Core.QueryFilters;
using System.Threading.Tasks;

namespace MovBooks.Core.Interfaces.Services
{
    public interface IGenderService
    {

        PagedList<Gender> GetAll(GenderQueryFilter filters);
        Task<Gender> GetById(int id);
        Task Insert(Gender gender, int? id, string? type);
        Task<bool> Update(Gender gender);
        Task<bool> Delete(int id);

    }
}
