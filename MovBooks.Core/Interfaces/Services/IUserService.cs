using MovBooks.Core.CustomEntities;
using MovBooks.Core.Entities;
using MovBooks.Core.QueryFilters;
using System.Threading.Tasks;

namespace MovBooks.Core.Interfaces
{
    public interface IUserService
    {
        PagedList<User> GetAll(UserQueryFilter filters);
        Task<User> GetById(int id);
        Task Insert(User user);
        Task<bool> Update(User user);
        Task<bool> Delete(int id);
        Task<User> GetLoginByCredentials(UserLogin login);
        Task<User> FindByEmail(string email);
        Task<User> FindByNickname(string nickname);
        Task GenerateDataFakeAsync(int quantityUsers);
        PagedList<Movie> GetProfileWatchedMovies(MovieQueryFilter filters,int idUser);
        PagedList<Book> GetProfileWatchedBooks(BookQueryFilter filters, int idUser);
    }
}
