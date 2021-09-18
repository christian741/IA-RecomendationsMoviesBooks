using MovBooks.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovBooks.Core.Interfaces
{
    public interface IRatingBookRepository : IRepository<RatingBook>
    {
        IEnumerable<RatingBook> GetAllInclude(); 
        Task<RatingBook> Find(int userId, int bookId);
    }
}
