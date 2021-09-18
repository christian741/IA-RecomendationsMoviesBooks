using MovBooks.Core.CustomEntities;
using MovBooks.Core.Entities;
using MovBooks.Core.QueryFilters;
using System.Threading.Tasks;

namespace MovBooks.Core.Interfaces
{
    public interface IBookService
    {
        PagedList<Book> GetAll(BookQueryFilter filters);
        Task<Book> GetById(int id);
        Task Insert(Book book);
        Task<bool> Update(Book book);
        Task<bool> Delete(int id);
        Task<Book> FindByTitle(int? id, string title);
    }
}
