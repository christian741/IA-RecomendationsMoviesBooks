using System;
using System.Collections.Generic;
using System.Text;

namespace MovBooks.Core.Entities
{
    public class GenderMovies : BaseEntity
    {
        public GenderMovies()
        {
            Genders = new HashSet<Gender>();
            Movies = new HashSet<Movie>();
        }

        public virtual ICollection<Gender> Genders { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
    }
}
