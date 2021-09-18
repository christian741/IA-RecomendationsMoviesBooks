using System;

namespace MovBooks.Core.DTOs
{
    public class PasswordRecoveryDto : BaseDto
    {
        public string Email { get; set; }
        public string Token { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
