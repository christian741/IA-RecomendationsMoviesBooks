using Bogus;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MovBooks.Core.CustomEntities;
using MovBooks.Core.Entities;
using MovBooks.Core.Exceptions;
using MovBooks.Core.Interfaces;
using MovBooks.Core.QueryFilters;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MovBooks.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;
        private IServiceProvider _serviceProvider;

        public UserService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options, IServiceProvider serviceProvider)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = options.Value;
            _serviceProvider = serviceProvider;
        }

        public async Task<User> GetLoginByCredentials(UserLogin login)
        {
            return await _unitOfWork.UserRepository.GetLoginByCredentials(login);
        }

        public PagedList<User> GetAll(UserQueryFilter filters)
        {
            filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;

            var users = _unitOfWork.UserRepository.GetAll();

            users = users.Where(x => x.Nickname.ToLower().Contains(!string.IsNullOrEmpty(filters.Nickname) ? filters.Nickname.ToLower() : "") 
            || x.Email.ToLower().Contains(!string.IsNullOrEmpty(filters.Email) ? filters.Email.ToLower() : ""));

            return PagedList<User>.Create(users, filters.PageNumber, filters.PageSize);
        }

        public async Task<User> GetById(int id)
        {
            return await _unitOfWork.UserRepository.GetById(id);
        }

        public async Task Insert(User user)
        {
            var findUser = await _unitOfWork.UserRepository.FindByEmailOrNickName(user.Email,user.Nickname);
            if (findUser != null) throw new ValidationAppException("This user already exists", (int)HttpStatusCode.InternalServerError, HttpStatusCode.InternalServerError.ToString());
            await _unitOfWork.UserRepository.Add(user);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> Update(User user)
        {
            _unitOfWork.UserRepository.Update(user);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            await _unitOfWork.UserRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<User> FindByEmail(string email)
        {
            return await _unitOfWork.UserRepository.FindByEmail(email);
        }

        public async Task<User> FindByNickname(string nickname)
        {
            return await _unitOfWork.UserRepository.FindByNickname(nickname);
        }

        public async Task GenerateDataFakeAsync(int quantityUsers)
        {
            using(var scope = _serviceProvider.CreateScope())
            {
                var service = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

               await service.UserRepository.GenerateDataFakeAsync(quantityUsers);
            }
            
        }

        public PagedList<Movie> GetProfileWatchedMovies(MovieQueryFilter filters, int idUser)
        {

            filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;

            var movies = _unitOfWork.UserRepository.GetProfileWatchedMovies(idUser);

            // La paginación se hace después de que los filtros sean aplicados
            var pagedPosts = PagedList<Movie>.Create(movies, filters.PageNumber, filters.PageSize);
            return pagedPosts;            
        }

        public PagedList<Book> GetProfileWatchedBooks(BookQueryFilter filters, int idUser)
        {
            filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;

            var books = _unitOfWork.UserRepository.GetProfileWatchedBooks(idUser);

            // La paginación se hace después de que los filtros sean aplicados
            var pagedPosts = PagedList<Book>.Create(books, filters.PageNumber, filters.PageSize);
            return pagedPosts;
        }
    }
}
