using System.Collections.Generic;

namespace MovBooks.Core.Entities
{
    public class Movie : BaseEntity
    {
        public Movie()
        {
            RatingsMovies = new HashSet<RatingMovie>();
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public bool Aggregated { get; set; }

        public virtual ICollection<RatingMovie> RatingsMovies { get; set; }
    }
}
