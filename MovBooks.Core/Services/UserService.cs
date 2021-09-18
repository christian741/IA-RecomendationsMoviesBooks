using Microsoft.Extensions.Options;
using MovBooks.Core.CustomEntities;
using MovBooks.Core.Entities;
using MovBooks.Core.Interfaces;
using MovBooks.Core.QueryFilters;
using System.Threading.Tasks;

namespace MovBooks.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;

        public UserService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = options.Value;
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

            // La paginación se hace después de que los filtros sean aplicados
            var pagedPosts = PagedList<User>.Create(users, filters.PageNumber, filters.PageSize);

            return pagedPosts;
        }

        public async Task<User> GetById(int id)
        {
            return await _unitOfWork.UserRepository.GetById(id);
        }

        public async Task Insert(User user)
        {
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
    }
}
