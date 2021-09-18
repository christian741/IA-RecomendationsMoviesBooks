using System;

namespace MovBooks.Core.DTOs
{
    public class PqrDto : BaseDto
    {
        public string Description { get; set; }
        public string Answer { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool Answered { get; set; }
        public int UserId { get; set; }
    }
}
