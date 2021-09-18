using Microsoft.EntityFrameworkCore;
using MovBooks.Core.Entities;
using MovBooks.Core.Interfaces;
using MovBooks.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovBooks.Infrastructure.Repositories
{
    public class PqrRepository : BaseRepository<Pqr>, IPqrRepository
    {
        public PqrRepository(MovBooksContext context) : base(context)
        {
        }

        public IEnumerable<Pqr> GetAllIncludeUser()
        {
            return _entities.Include(x => x.User).AsEnumerable();
        }

        public async Task<Pqr> GetByIdIncludeUser(int id)
        {
            return await _entities.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
