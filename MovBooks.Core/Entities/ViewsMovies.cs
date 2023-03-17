using System;
using System.Collections.Generic;
using System.Text;

namespace MovBooks.Core.Entities
{
    public class ViewsMovies : BaseEntity
    {
        public ViewsMovies()
        {

        }
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public Int64 Views { get; set; }
        public virtual User User { get; set; }
        public virtual Movie Movie { get; set; }


    }
}
