using Microsoft.Extensions.Options;
using MovBooks.Core.CustomEntities;
using MovBooks.Core.Entities;
using MovBooks.Core.Interfaces;
using MovBooks.Core.QueryFilters;
using System.Threading.Tasks;

namespace MovBooks.Core.Services
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;

        public RoleService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = options.Value;
        }

        public PagedList<Role> GetAll(RoleQueryFilter filters)
        {
            filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;

            var roles = _unitOfWork.RoleRepository.GetAll();

            // La paginación se hace después de que los filtros sean aplicados
            var pagedList = PagedList<Role>.Create(roles, filters.PageNumber, filters.PageSize);

            return pagedList;
        }

        public async Task<Role> GetById(int id)
        {
            return await _unitOfWork.RoleRepository.GetById(id);
        }

        public async Task Insert(Role role)
        {
            await _unitOfWork.RoleRepository.Add(role);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> Update(Role role)
        {
            _unitOfWork.RoleRepository.Update(role);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            await _unitOfWork.RoleRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
