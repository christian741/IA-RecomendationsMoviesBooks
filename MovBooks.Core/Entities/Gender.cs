using System;
using System.Collections.Generic;
using System.Text;

namespace MovBooks.Core.Entities
{
    public class Gender : BaseEntity
    {
      
        public string Name { get; set; }
        //public string Description { get; set; }
        //public bool Enabled { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
 


    }
}
