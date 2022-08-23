using MovBooks.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovBooks.Core.Interfaces.Repositorys
{
    public interface IGenderRepository : IRepository<Gender>
    {
        Task<Gender> FindByName(string name);

        Task saveGenderBooks(Gender gender, Book book);

        Task saveGenderMovies(Gender gender, Movie movie);
    }
}
