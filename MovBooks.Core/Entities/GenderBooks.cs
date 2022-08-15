using System;
using System.Collections.Generic;
using System.Text;

namespace MovBooks.Core.Entities
{
    public class GenderBooks : BaseEntity
    {
        public GenderBooks()
        {
        }
        public int IdGender { get; set; }
        public int IdBook { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual Book Book { get; set; }
    }
}
