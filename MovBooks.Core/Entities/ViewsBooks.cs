using System;
using System.Collections.Generic;
using System.Text;

namespace MovBooks.Core.Entities
{
    public class ViewsBooks : BaseEntity
    {
        public ViewsBooks()
        {

        }

        public int UserId { get; set; }
        public int BookId { get; set; }
        public Int64 Views { get; set; }
        public virtual User User { get; set; }
        public virtual Book Book { get; set; }
    }
}
