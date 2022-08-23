using System;
using System.Collections.Generic;
using System.Text;

namespace MovBooks.Core.DTOs
{
    public class GenderDto : BaseDto
    {
        public string Name { get; set; }
        public int IdApi { get; set; }
        public string Description { get; set; }
        public bool Enabled { get; set; }
        public int IdMorph { get; set; }
        public string TypeMorph { get; set; }
    }
}
