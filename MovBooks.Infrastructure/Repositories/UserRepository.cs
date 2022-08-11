using Microsoft.EntityFrameworkCore;
using MovBooks.Core.Entities;
using MovBooks.Core.Interfaces;
using MovBooks.Infrastructure.Data;
using System.Threading.Tasks;

namespace MovBooks.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(MovBooksContext context) : base(context) { }

        public async Task<User> GetLoginByCredentials(UserLogin login)
        {
            return await _entities.Include(x => x.Role)
                        .FirstOrDefaultAsync(x => x.Email == login.Email && x.Password == login.Password);
        }

        public async Task<User> FindByEmail(string email)
        {
            return await _entities.FirstOrDefaultAsync(x => x.Email.ToLower() == email.ToLower());
        }

        public async Task<User> FindByNickname(string nickname)
        {
            return await _entities.FirstOrDefaultAsync(x => x.Nickname.ToLower() == nickname.ToLower());
        }

        public async Task<int> getCountUsers()
        {
            return await _entities.CountAsync();
        }
    }
}
