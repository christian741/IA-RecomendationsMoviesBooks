using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovBooks.Infrastructure.Interfaces
{
    public interface IApiMovieDb
    {
       Task GetGenresApiMovie();
    }
}
