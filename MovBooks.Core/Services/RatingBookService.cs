using Microsoft.Extensions.Options;
using MovBooks.Core.CustomEntities;
using MovBooks.Core.Entities;
using MovBooks.Core.Interfaces;
using MovBooks.Core.QueryFilters;
using System.Linq;
using System.Threading.Tasks;

namespace MovBooks.Core.Services
{
    public class RatingBookService : IRatingBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;

        public RatingBookService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = options.Value;
        }

        public PagedList<RatingBook> GetAllInclude(RatingBookQueryFilter filters)
        {
            filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;

            var ratingsBooks = _unitOfWork.RatingBookRepository.GetAllInclude();

            // Aplicar filtros
            if (filters.BookId != null)
            {
                ratingsBooks = ratingsBooks.Where(x => x.BookId == filters.BookId);
            }

            // La paginación se hace después de que los filtros sean aplicados
            var pagedList = PagedList<RatingBook>.Create(ratingsBooks, filters.PageNumber, filters.PageSize);

            return pagedList;
        }

        public async Task<RatingBook> GetById(int id)
        {
            return await _unitOfWork.RatingBookRepository.GetById(id);
        }

        public async Task Insert(RatingBook ratingBook)
        {
            await _unitOfWork.RatingBookRepository.Add(ratingBook);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> Update(RatingBook ratingBook)
        {
            _unitOfWork.RatingBookRepository.Update(ratingBook);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            await _unitOfWork.RatingBookRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<RatingBook> Find(int userId, int bookId)
        {
            return await _unitOfWork.RatingBookRepository.Find(userId, bookId);
        }
    }
}
