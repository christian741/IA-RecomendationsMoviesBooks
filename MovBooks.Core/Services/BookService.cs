using Microsoft.Extensions.Options;
using MovBooks.Core.CustomEntities;
using MovBooks.Core.Entities;
using MovBooks.Core.Interfaces;
using MovBooks.Core.QueryFilters;
using System.Linq;
using System.Threading.Tasks;

namespace MovBooks.Core.Services
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;

        public BookService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = options.Value;
        }

        public PagedList<Book> GetAll(BookQueryFilter filters)
        {
            filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;

            var books = _unitOfWork.BookRepository.GetAll();

            // Aplicar filtros
            if (!string.IsNullOrEmpty(filters.Title))
            {
                books = books.Where(x => x.Title.ToLower().Contains(filters.Title.ToLower()));
            }

            if (filters.Aggregated != null)
            {
                books = books.Where(x => x.Aggregated == filters.Aggregated);
            }

            // La paginación se hace después de que los filtros sean aplicados
            var pagedList = PagedList<Book>.Create(books, filters.PageNumber, filters.PageSize);

            return pagedList;
        }

        public async Task<Book> GetById(int id)
        {
            return await _unitOfWork.BookRepository.GetById(id);
        }

        public async Task Insert(Book book)
        {
            await _unitOfWork.BookRepository.Add(book);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> Update(Book book)
        {
            _unitOfWork.BookRepository.Update(book);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            await _unitOfWork.BookRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<Book> FindByTitle(int? id, string title)
        {
            return await _unitOfWork.BookRepository.FindByTitle(id, title);
        }
    }
}
