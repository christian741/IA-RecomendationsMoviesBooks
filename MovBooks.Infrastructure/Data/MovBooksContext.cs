using Microsoft.EntityFrameworkCore;
using MovBooks.Core.Entities;
using System.Reflection;

namespace MovBooks.Infrastructure.Data
{
    public class MovBooksContext : DbContext
    {
        public MovBooksContext()
        {
        }

        public MovBooksContext(DbContextOptions<MovBooksContext> options)
            : base(options)
        {
        }
        //Users
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<PasswordRecovery> PasswordRecoveries { get; set; }
        //Movies
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<ViewsMovies> ViewsMovies { get; set; }
        public virtual DbSet<RatingMovie> RatingsMovies { get; set; }

        //Books
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<ViewsBooks>ViewsBooks { get; set; }
        public virtual DbSet<RatingBook> RatingsBooks { get; set; }

        //Configuration
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<Pqr> Pqrs { get; set; }
        public virtual DbSet<Parameter> Parameters { get; set; }
        
        
      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
