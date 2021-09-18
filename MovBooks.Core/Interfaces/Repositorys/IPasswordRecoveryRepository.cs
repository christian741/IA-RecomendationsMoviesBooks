using MovBooks.Core.Entities;
using System.Threading.Tasks;

namespace MovBooks.Core.Interfaces
{
    public interface IPasswordRecoveryRepository : IRepository<PasswordRecovery>
    {
        Task<PasswordRecovery> FindByToken(string token);
        Task DeleteRange(string email);
    }
}
