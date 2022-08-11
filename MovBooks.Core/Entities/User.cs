using System;
using System.Collections.Generic;

namespace MovBooks.Core.Entities
{
    public class User : BaseEntity
    {
        public User()
        {
            Pqrs = new HashSet<Pqr>();
            RatingsBooks = new HashSet<RatingBook>();
            RatingsMovies = new HashSet<RatingMovie>();
        }

        public User(string nickname, string email, string password, int roleId, string avatar, string image, bool enabled, DateTime registrationDate, Role role, ICollection<Pqr> pqrs, ICollection<RatingBook> ratingsBooks, ICollection<RatingMovie> ratingsMovies)
        {
            Nickname = nickname;
            Email = email;
            Password = password;
            RoleId = roleId;
            Avatar = avatar;
            Image = image;
            Enabled = enabled;
            RegistrationDate = registrationDate;
            Role = role;
            Pqrs = pqrs;
            RatingsBooks = ratingsBooks;
            RatingsMovies = ratingsMovies;
        }

        public string Nickname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public string Avatar { get; set; }
        public string Image { get; set; }
        public bool Enabled { get; set; }
        public DateTime RegistrationDate { get; set; } = DateTime.Now;
        public virtual Role Role { get; set; }
        public virtual ICollection<Pqr> Pqrs { get; set; }
        public virtual ICollection<RatingBook> RatingsBooks { get; set; }
        public virtual ICollection<RatingMovie> RatingsMovies { get; set; }
    }
}
