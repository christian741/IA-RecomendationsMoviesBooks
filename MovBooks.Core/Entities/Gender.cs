using System;
using System.Collections.Generic;
using System.Text;

namespace MovBooks.Core.Entities
{
    public class Gender : BaseEntity
    {

        public Gender()
        {
            GenderMovies = new HashSet<GenderMovies>();
            GenderBooks = new HashSet<GenderBooks>();
        }

        public string Name { get; set; }

        public virtual ICollection<GenderBooks> GenderBooks { get; set; }

        public virtual ICollection<GenderMovies> GenderMovies { get; set; }


    }
}
