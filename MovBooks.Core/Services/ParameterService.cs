using Microsoft.Extensions.Options;
using MovBooks.Core.CustomEntities;
using MovBooks.Core.Entities;
using MovBooks.Core.Interfaces;
using MovBooks.Core.QueryFilters;
using System.Threading.Tasks;

namespace MovBooks.Core.Services
{
    public class ParameterService : IParameterService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;

        public ParameterService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = options.Value;
        }

        public PagedList<Parameter> GetAll(ParameterQueryFilter filters)
        {
            filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;

            var parameters = _unitOfWork.ParameterRepository.GetAll();

            // La paginación se hace después de que los filtros sean aplicados
            var pagedList = PagedList<Parameter>.Create(parameters, filters.PageNumber, filters.PageSize);

            return pagedList;
        }

        public async Task<Parameter> GetById(int id)
        {
            return await _unitOfWork.ParameterRepository.GetById(id);
        }

        public async Task Insert(Parameter parameter)
        {
            await _unitOfWork.ParameterRepository.Add(parameter);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> Update(Parameter parameter)
        {
            _unitOfWork.ParameterRepository.Update(parameter);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            await _unitOfWork.ParameterRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<Parameter> FindByKey(string key, int? id)
        {
            return await _unitOfWork.ParameterRepository.FindByKey(key, id);
        }
    }
}
