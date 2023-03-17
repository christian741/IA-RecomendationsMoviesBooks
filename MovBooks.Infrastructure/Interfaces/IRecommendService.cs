using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovBooks.Infrastructure.Interfaces
{
    public interface IRecommendService
    {
        Task RecommendBooksUserService(int userId, int numberIterations, int aproximationRank);
        Task RecommendMoviesUserService(int userId, int numberIterations, int aproximationRank);
        Task TrainerModelRecommender(int userId, int numberIterations, int aproximationRank);
    }
}
