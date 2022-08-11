using System.Linq;
using Microsoft.EntityFrameworkCore;
using MovBooks.Core.Entities;
using MovBooks.Core.Interfaces;
using MovBooks.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using MovBooks.Core.Interfaces.Repositorys;

namespace MovBooks.Infrastructure.Repositories
{
    public class RecomenderRepository : IRecomenderRepository
    {
        private readonly MovBooksContext _context;
        public RecomenderRepository(MovBooksContext context)
        {
            _context = context;
        }

        public void RecomenderBooks(int idUser, int idBook)
        {
            throw new System.NotImplementedException();
        }

        public void RecomenderBooksAndMovies(int idUser)
        {
            throw new System.NotImplementedException();
        }

        public void RecomenderMovies(int idUser, int idMovie)
        {
            throw new System.NotImplementedException();
        }
    }
}
