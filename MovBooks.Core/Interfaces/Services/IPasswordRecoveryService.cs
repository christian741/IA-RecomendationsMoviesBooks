using MovBooks.Core.CustomEntities;
using MovBooks.Core.Entities;
using MovBooks.Core.QueryFilters;
using System.Threading.Tasks;

namespace MovBooks.Core.Interfaces
{
    public interface IPasswordRecoveryService
    {
        PagedList<PasswordRecovery> GetAll(PasswordRecoveryQueryFilter filters);
        Task<PasswordRecovery> GetById(int id);
        Task Insert(PasswordRecovery passwordRecovery);
        Task<bool> Update(PasswordRecovery passwordRecovery);
        Task<bool> Delete(int id);
        Task<PasswordRecovery> FindByToken(string token);
        Task<bool> DeleteRange(string email);
    }
}
