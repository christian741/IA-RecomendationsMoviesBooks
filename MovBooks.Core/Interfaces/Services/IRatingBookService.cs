using MovBooks.Core.CustomEntities;
using MovBooks.Core.Entities;
using MovBooks.Core.QueryFilters;
using System.Threading.Tasks;

namespace MovBooks.Core.Interfaces
{
    public interface IRatingBookService
    {
        PagedList<RatingBook> GetAllInclude(RatingBookQueryFilter filters);
        Task<RatingBook> GetById(int id);
        Task<RatingBook> Find(int userId, int bookId);
        Task Insert(RatingBook ratingBook);
        Task<bool> Update(RatingBook ratingBook);
        Task<bool> Delete(int id);
    }
}
