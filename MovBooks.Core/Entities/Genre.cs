using System.Collections.Generic;

namespace MovBooks.Core.Entities
{
    public class Genre : BaseEntity
    {

        public Genre()
        {
            GenreMovies = new HashSet<GenreMovies>();
            GenreBooks = new HashSet<GenreBooks>();
        }

        public string Name { get; set; }
        public int? IdApi { get; set; }

        public virtual ICollection<GenreBooks> GenreBooks { get; set; }

        public virtual ICollection<GenreMovies> GenreMovies { get; set; }


    }
}
