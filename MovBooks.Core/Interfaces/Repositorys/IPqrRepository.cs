using MovBooks.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovBooks.Core.Interfaces
{
    public interface IPqrRepository : IRepository<Pqr>
    {
        IEnumerable<Pqr> GetAllIncludeUser();
        Task<Pqr> GetByIdIncludeUser(int id);
    }
}
