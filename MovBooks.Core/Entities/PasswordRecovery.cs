using System;

namespace MovBooks.Core.Entities
{
    public class PasswordRecovery : BaseEntity
    {
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
