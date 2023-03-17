using MovBooks.Core.Entities;
using MovBooks.Core.Interfaces;
using MovBooks.Infrastructure.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace MovBooks.Infrastructure.Repositories
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(MovBooksContext context) : base(context) { }

        public async Task<Book> FindByTitle(int? id, string title)
        {
            var book = await _entities
                    .FirstOrDefaultAsync(x => (id == null || x.Id != id) && x.Title.ToLower() == title.ToLower());
            return book;
        }

        public IEnumerable<RatingBook> GetRaingsBooks()
        {
            return (IEnumerable<RatingBook>)(_context.RatingsBooks.AsAsyncEnumerable());
        }
    }
}
