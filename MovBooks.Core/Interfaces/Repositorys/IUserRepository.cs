using MovBooks.Core.Entities;
using System.Threading.Tasks;

namespace MovBooks.Core.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetLoginByCredentials(UserLogin login);
        Task<User> FindByEmail(string email);
        Task<User> FindByNickname(string nickname);
        Task<int> getCountUsers();
    }
}
