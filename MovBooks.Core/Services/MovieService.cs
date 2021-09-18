using Microsoft.Extensions.Options;
using MovBooks.Core.CustomEntities;
using MovBooks.Core.Entities;
using MovBooks.Core.Interfaces;
using MovBooks.Core.QueryFilters;
using System.Linq;
using System.Threading.Tasks;

namespace MovBooks.Core.Services
{
    public class MovieService : IMovieService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;

        public MovieService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = options.Value;
        }

        public PagedList<Movie> GetAll(MovieQueryFilter filters)
        {
            filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;

            var movies = _unitOfWork.MovieRepository.GetAll();

            // Aplicar filtros

            if (!string.IsNullOrEmpty(filters.Title))
            {
                movies = movies.Where(x => x.Title.ToLower().Contains(filters.Title.ToLower()));
            }

            if (filters.Aggregated != null)
            {
                movies = movies.Where(x => x.Aggregated == filters.Aggregated);
            }

            // La paginación se hace después de que los filtros sean aplicados
            var pagedList = PagedList<Movie>.Create(movies, filters.PageNumber, filters.PageSize);

            return pagedList;
        }

        public async Task<Movie> GetById(int id)
        {
            return await _unitOfWork.MovieRepository.GetById(id);
        }

        public async Task Insert(Movie movie)
        {
            await _unitOfWork.MovieRepository.Add(movie);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> Update(Movie movie)
        {
            _unitOfWork.MovieRepository.Update(movie);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            await _unitOfWork.MovieRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<Movie> FindByTitle(int? id, string title)
        {
            return await _unitOfWork.MovieRepository.FindByTitle(id, title);
        }
    }
}
