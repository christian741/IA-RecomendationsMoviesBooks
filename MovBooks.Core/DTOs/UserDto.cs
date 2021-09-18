using System;

namespace MovBooks.Core.DTOs
{
    public class UserDto : BaseDto
    {
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public string Avatar { get; set; }
        public string Image { get; set; }
        public bool Enabled { get; set; }
        public DateTime RegistrationDate { get; set; } = DateTime.Now;
    }
}
