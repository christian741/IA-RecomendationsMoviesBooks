using MovBooks.Core.Entities;
using System.Threading.Tasks;

namespace MovBooks.Core.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<Book> FindByTitle(int? id, string title);
    }
}
