using System;

namespace MovBooks.Core.Entities
{
    public class Pqr : BaseEntity
    {
        public string Description { get; set; }
        public string Answer { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Answered { get; set; }
        public int UserId { get; set; }
        public DateTime AnswerDate { get; set; }
        public virtual User User { get; set; }
    }
}
