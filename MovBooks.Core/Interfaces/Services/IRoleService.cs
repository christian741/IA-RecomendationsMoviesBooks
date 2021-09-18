using MovBooks.Core.CustomEntities;
using MovBooks.Core.Entities;
using MovBooks.Core.QueryFilters;
using System.Threading.Tasks;

namespace MovBooks.Core.Interfaces
{
    public interface IRoleService
    {
        PagedList<Role> GetAll(RoleQueryFilter filters);
        Task<Role> GetById(int id);
        Task Insert(Role role);
        Task<bool> Update(Role role);
        Task<bool> Delete(int id);
    }
}
