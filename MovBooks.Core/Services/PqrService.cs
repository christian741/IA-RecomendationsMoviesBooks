using Microsoft.Extensions.Options;
using MovBooks.Core.CustomEntities;
using MovBooks.Core.Entities;
using MovBooks.Core.Interfaces;
using MovBooks.Core.QueryFilters;
using System.Linq;
using System.Threading.Tasks;

namespace MovBooks.Core.Services
{
    public class PqrService : IPqrService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;

        public PqrService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = options.Value;
        }

        public PagedList<Pqr> GetAllIncludeUser(PqrQueryFilter filters)
        {
            filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;

            var pqrs = _unitOfWork.PqrRepository.GetAllIncludeUser();

            // Filters
            if (filters.UserId != null)
            {
                pqrs = pqrs.Where(x => x.UserId == filters.UserId);
            }

            // La paginación se hace después de que los filtros sean aplicados
            var pagedList = PagedList<Pqr>.Create(pqrs, filters.PageNumber, filters.PageSize);

            return pagedList;
        }

        public async Task<Pqr> GetByIdIncludeUser(int id)
        {
            return await _unitOfWork.PqrRepository.GetByIdIncludeUser(id);
        }

        public async Task Insert(Pqr pqr)
        {
            await _unitOfWork.PqrRepository.Add(pqr);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> Update(Pqr pqr)
        {
            pqr.Answered = !string.IsNullOrEmpty(pqr.Answer);
            _unitOfWork.PqrRepository.Update(pqr);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            await _unitOfWork.PqrRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
