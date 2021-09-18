using Microsoft.Extensions.Options;
using MovBooks.Core.CustomEntities;
using MovBooks.Core.Entities;
using MovBooks.Core.Interfaces;
using MovBooks.Core.QueryFilters;
using System;
using System.Threading.Tasks;

namespace MovBooks.Core.Services
{
    public class PasswordRecoveryService : IPasswordRecoveryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;

        public PasswordRecoveryService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = options.Value;
        }

        public PagedList<PasswordRecovery> GetAll(PasswordRecoveryQueryFilter filters)
        {
            filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;

            var passwordRecoveries = _unitOfWork.PasswordRecoveryRepository.GetAll();

            // La paginación se hace después de que los filtros sean aplicados
            var pagedList = PagedList<PasswordRecovery>.Create(passwordRecoveries, filters.PageNumber, filters.PageSize);

            return pagedList;
        }

        public async Task<PasswordRecovery> GetById(int id)
        {
            return await _unitOfWork.PasswordRecoveryRepository.GetById(id);
        }

        public async Task Insert(PasswordRecovery passwordRecovery)
        {
            passwordRecovery.Token = Guid.NewGuid().ToString();
            await _unitOfWork.PasswordRecoveryRepository.Add(passwordRecovery);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> Update(PasswordRecovery passwordRecovery)
        {
            _unitOfWork.PasswordRecoveryRepository.Update(passwordRecovery);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            await _unitOfWork.PasswordRecoveryRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<PasswordRecovery> FindByToken(string token)
        {
            return await _unitOfWork.PasswordRecoveryRepository.FindByToken(token);
        }

        public async Task<bool> DeleteRange(string email)
        {
            await _unitOfWork.PasswordRecoveryRepository.DeleteRange(email);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
