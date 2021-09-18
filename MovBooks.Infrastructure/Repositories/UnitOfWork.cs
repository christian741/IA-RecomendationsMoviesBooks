using System;
using MovBooks.Core.Entities;
using MovBooks.Core.Interfaces;
using System.Threading.Tasks;
using MovBooks.Infrastructure.Data;
using MovBooks.Core.Interfaces.Repositorys;

namespace MovBooks.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MovBooksContext _context;

        private readonly IPqrRepository _pqrRepository;
        private readonly IUserRepository _userRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IRepository<Role> _roleRepository;
        private readonly IGenderRepository _genderRepository;
        private readonly IMovieRepository _movieRepository;
        private readonly IParameterRepository _parameterRepository;
        private readonly IRatingBookRepository _ratingBookRepository;
        private readonly IRatingMovieRepository _ratingMovieRepository;
        private readonly IPasswordRecoveryRepository _passwordRecoveryRepository;

        public UnitOfWork(MovBooksContext context)
        {
            _context = context;
        }

        public IPqrRepository PqrRepository => _pqrRepository ?? new PqrRepository(_context);
        public IBookRepository BookRepository => _bookRepository ?? new BookRepository(_context);
        public IUserRepository UserRepository => _userRepository ?? new UserRepository(_context);
        public IMovieRepository MovieRepository => _movieRepository ?? new MovieRepository(_context);
        public IRepository<Role> RoleRepository => _roleRepository ?? new BaseRepository<Role>(_context);
        public IParameterRepository ParameterRepository => _parameterRepository ?? new ParameterRepository(_context);
        public IRatingBookRepository RatingBookRepository => _ratingBookRepository ?? new RatingBookRepository(_context);
        public IRatingMovieRepository RatingMovieRepository => _ratingMovieRepository ?? new RatingMovieRepository(_context);
        public IPasswordRecoveryRepository PasswordRecoveryRepository => _passwordRecoveryRepository ?? new PasswordRecoveryRepository(_context);

        public IGenderRepository GenderRepository => _genderRepository ?? new GenderRepository(_context);

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }
    }
}
