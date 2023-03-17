using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MovBooks.Core.Entities;
using MovBooks.Core.Interfaces;
using MovBooks.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace MovBooks.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(MovBooksContext context) : base(context) { }

        public async Task<User> GetLoginByCredentials(UserLogin login)
        {
            return await _entities.Include(x => x.Role)
                        .FirstOrDefaultAsync(x => x.Email == login.Email && x.Password == login.Password);
        }

        public async Task<User> FindByEmail(string email)
        {
            return await _entities.FirstOrDefaultAsync(x => x.Email.ToLower() == email.ToLower());
        }

        public async Task<User> FindByNickname(string nickname)
        {
            return await _entities.FirstOrDefaultAsync(x => x.Nickname.ToLower() == nickname.ToLower());
        }

        public async Task GenerateDataFakeAsync(int quantityUsers)
        {
            int quantityBooks = await _context.Books.CountAsync();
            int quantityMovies = await _context.Movies.CountAsync();

            int randomRatings = 40;

            var testRatingsBooks = new Faker<RatingBook>(locale: "es_MX")
              .RuleFor(r => r.Rating, f => f.Random.Number(1, 5))
              .RuleFor(r => r.Comment, f => f.Random.Number(1,10) % 2 == 0 ? f.Lorem.Sentence(f.Random.Number(10,20)) : null )
              .RuleFor(r => r.BookId, f => f.Random.Number(1, quantityBooks))
              .RuleFor(r => r.RatingDate, f => f.Date.Past());

            var testRatingsMovies = new Faker<RatingMovie>(locale: "es_MX")
              .RuleFor(r => r.Rating, f => f.Random.Number(1, 5))
              .RuleFor(r => r.Comment, f => f.Random.Number(1, 10) % 2 == 0 ? f.Lorem.Sentence(f.Random.Number(10, 20)) : null)
              .RuleFor(r => r.MovieId, f => f.Random.Number(1, quantityMovies))
              .RuleFor(r => r.RatingDate, f => f.Date.Past());


            var testUsers = new Faker<User>(locale: "es_MX")
               .RuleFor(u => u.Nickname, f => f.Person.FullName)
               .RuleFor(u => u.Email, f => f.Person.Email)
               .RuleFor(u => u.RoleId, 2)
               .RuleFor(u => u.Avatar, f => "av" + Convert.ToString(f.Random.Number(1, 10)) + ".png")
               .RuleFor(u => u.Enabled, true)
               .RuleFor(u => u.RegistrationDate, DateTime.Now)
               .RuleFor(u => u.Password, "123456")
               .RuleFor(u => u.RatingsBooks, f => testRatingsBooks.Generate(f.Random.Number(1, randomRatings)))
               .RuleFor(u => u.RatingsMovies, f => testRatingsMovies.Generate(f.Random.Number(1, randomRatings))); 
            

            var userList = testUsers.Generate(quantityUsers);

            userList.ForEach(async u =>
                {
                    await Add(u);
                });
            await _context.SaveChangesAsync();

           
            await Task.Delay(100);

        }

        public IEnumerable<Movie> GetProfileWatchedMovies(int userId)
        {
            return (IEnumerable<Movie>)(from movies in _context.Movies
                    join viewMovies in _context.ViewsMovies on movies.Id equals viewMovies.MovieId
                    join user in _context.Users on viewMovies.UserId equals user.Id
                    where user.Id == userId
                    select new { movies }
                  ).AsAsyncEnumerable();
        }

        public IEnumerable<Book> GetProfileWatchedBooks(int userId)
        {
            return (IEnumerable<Book>)(from books in _context.Books
                                        join viewBooks in _context.ViewsBooks on books.Id equals viewBooks.BookId
                                        join user in _context.Users on viewBooks.UserId equals user.Id
                                        where user.Id == userId
                                        select new { books }
                 ).AsAsyncEnumerable();
        }

        public async Task<User> FindByEmailOrNickName(string email, string nickname)
        {
            return await _entities.FirstOrDefaultAsync(x => x.Email.ToLower() == email.ToLower() || x.Nickname.ToLower() == nickname.ToLower());
        }
    }
}
