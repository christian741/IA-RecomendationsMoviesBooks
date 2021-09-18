using MovBooks.Core.Entities;
using MovBooks.Core.Interfaces;
using MovBooks.Infrastructure.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovBooks.Core.Interfaces.Repositorys;

namespace MovBooks.Infrastructure.Repositories
{
    public class GenderRepository : BaseRepository<Gender>, IGenderRepository
    {
        public GenderRepository(MovBooksContext context) : base(context) { }

     
    }
}
