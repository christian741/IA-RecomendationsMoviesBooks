using System;
using System.Collections.Generic;
using System.Text;

namespace MovBooks.Core.Entities
{
    public class GenderMovies : BaseEntity
    {
        public GenderMovies()
        {
        }
        public int IdGender { get; set; }
        public int IdMovie { get; set; }

        public virtual Gender Gender { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
