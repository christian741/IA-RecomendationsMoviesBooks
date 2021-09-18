using System;
using System.Collections.Generic;
using System.Text;

namespace MovBooks.Core.Entities
{
    public class GenderBooks : BaseEntity
    {
        public GenderBooks()
        {
            Genders = new HashSet<Gender>();
            Books = new HashSet<Book>();
        }

        public virtual ICollection<Gender> Genders { get; set; }
        public virtual ICollection<Book>  Books{ get; set; }

    }
}
