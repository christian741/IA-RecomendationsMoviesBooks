using Microsoft.Extensions.Options;
using MovBooks.Core.CustomEntities;
using MovBooks.Core.Entities;
using MovBooks.Core.Interfaces;
using MovBooks.Core.QueryFilters;
using System.Linq;
using System.Threading.Tasks;

namespace MovBooks.Core.Services
{
    public class RatingMovieService : IRatingMovieService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;

        public RatingMovieService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = options.Value;
        }

        public PagedList<RatingMovie> GetAllInclude(RatingMovieQueryFilter filters)
        {
            filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;

            var ratingsMovies = _unitOfWork.RatingMovieRepository.GetAllInclude();

            // Aplicar filtros
            if (filters.MovieId != null)
            {
                ratingsMovies = ratingsMovies.Where(x => x.MovieId == filters.MovieId);
            }

            // La paginación se hace después de que los filtros sean aplicados
            var pagedList = PagedList<RatingMovie>.Create(ratingsMovies, filters.PageNumber, filters.PageSize);

            return pagedList;
        }

        public async Task<RatingMovie> GetById(int id)
        {
            return await _unitOfWork.RatingMovieRepository.GetById(id);
        }

        public async Task Insert(RatingMovie ratingMovie)
        {
            await _unitOfWork.RatingMovieRepository.Add(ratingMovie);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> Update(RatingMovie ratingMovie)
        {
            _unitOfWork.RatingMovieRepository.Update(ratingMovie);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            await _unitOfWork.RatingMovieRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<RatingMovie> Find(int userId, int movieId)
        {
            return await _unitOfWork.RatingMovieRepository.Find(userId, movieId);
        }
    }
}
