using System.Collections.Generic;

namespace MovBooks.Core.Entities
{
    public class Movie : BaseEntity
    {
        public Movie()
        {
            RatingsMovies = new HashSet<RatingMovie>();
            GenreMovies = new HashSet<GenreMovies>();
            ViewMovies = new HashSet<ViewsMovies>();
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public bool Aggregated { get; set; }

        public virtual ICollection<GenreMovies> GenreMovies { get; set; }
        public virtual ICollection<RatingMovie> RatingsMovies { get; set; }
        public virtual ICollection<ViewsMovies> ViewMovies { get; set; }
    }
}
