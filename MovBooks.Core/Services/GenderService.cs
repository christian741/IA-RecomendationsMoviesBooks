using Microsoft.Extensions.Options;
using MovBooks.Core.CustomEntities;
using MovBooks.Core.Entities;
using MovBooks.Core.Interfaces;
using MovBooks.Core.Interfaces.Services;
using MovBooks.Core.QueryFilters;
using System.Linq;
using System.Threading.Tasks;

namespace MovBooks.Core.Services
{
    public class GenderService : IGenderService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;

        public GenderService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = options.Value;
        }

        public PagedList<Gender> GetAll(GenderQueryFilter filters)
        {
            filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;

            var genders = _unitOfWork.GenderRepository.GetAll();

            /* Aplicar filtros*/
            if (!string.IsNullOrEmpty(filters.Name))
            {
                genders = genders.Where(x => x.Name.ToLower().Contains(filters.Name.ToLower()));
            }
            /*
            if (filters.Aggregated != null)
            {
                books = books.Where(x => x.Aggregated == filters.Aggregated);
            }*/

            // La paginación se hace después de que los filtros sean aplicados
            var pagedList = PagedList<Gender>.Create(genders, filters.PageNumber, filters.PageSize);

            return pagedList;
        }

        public async Task<Gender> GetById(int id)
        {
            return await _unitOfWork.GenderRepository.GetById(id);
        }

        public async Task Insert(Gender gender)
        {
            await _unitOfWork.GenderRepository.Add(gender);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> Update(Gender gender)
        {
            _unitOfWork.GenderRepository.Update(gender);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            await _unitOfWork.GenderRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

    }
}
