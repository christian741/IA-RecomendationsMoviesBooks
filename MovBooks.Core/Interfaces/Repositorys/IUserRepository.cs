using Microsoft.Extensions.Logging;
using MovBooks.Core.CustomEntities;
using MovBooks.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovBooks.Core.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetLoginByCredentials(UserLogin login);
        Task<User> FindByEmail(string email);
        Task<User> FindByEmailOrNickName(string email, string nickname);
        Task<User> FindByNickname(string nickname);
        Task GenerateDataFakeAsync(int quantityUsers);
        IEnumerable<Movie> GetProfileWatchedMovies(int userId);
        IEnumerable<Book> GetProfileWatchedBooks(int userId);
    }
}
