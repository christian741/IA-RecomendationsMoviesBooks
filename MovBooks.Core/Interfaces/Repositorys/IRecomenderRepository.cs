using System;
using System.Collections.Generic;
using System.Text;

namespace MovBooks.Core.Interfaces.Repositorys
{
    public interface IRecomenderRepository
    {
        void RecomenderMovies(int idUser,int idMovie);
        void RecomenderBooks(int idUser,int idBook);
        void RecomenderBooksAndMovies(int idUser);

    }
}
