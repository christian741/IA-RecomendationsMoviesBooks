using System.Linq;
using Microsoft.EntityFrameworkCore;
using MovBooks.Core.Entities;
using MovBooks.Core.Interfaces;
using MovBooks.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovBooks.Infrastructure.Repositories
{
    public class RatingBookRepository : BaseRepository<RatingBook>, IRatingBookRepository
    {
        public RatingBookRepository(MovBooksContext context) : base(context)
        {
        }

        public IEnumerable<RatingBook> GetAllInclude()
        {
            return _entities.Include(x => x.Book).Include(x => x.User).AsEnumerable();
        }

        public async Task<RatingBook> Find(int userId, int bookId)
        {
            return await _entities.FirstOrDefaultAsync(x => x.UserId == userId && x.BookId == bookId);
        }
    }
}
