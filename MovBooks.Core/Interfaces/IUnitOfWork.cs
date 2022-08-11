using System;
using MovBooks.Core.Entities;
using System.Threading.Tasks;
using MovBooks.Core.Interfaces.Repositorys;

namespace MovBooks.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        //Users
        IUserRepository UserRepository { get; }
        IRepository<Role> RoleRepository { get; }
        IPasswordRecoveryRepository PasswordRecoveryRepository { get; }

        //Books
        IBookRepository BookRepository { get; }
        IRatingBookRepository RatingBookRepository { get; }
        //Movies
        IMovieRepository MovieRepository { get; }
        IRatingMovieRepository RatingMovieRepository { get; }

        //Configuration
        IPqrRepository PqrRepository { get; }
        IParameterRepository ParameterRepository { get; }
        IGenderRepository GenderRepository { get; }
        IRecomenderRepository RecomenderRepository { get; }

       
        //Metodos
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
