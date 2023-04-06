using Microsoft.EntityFrameworkCore;
using MovBooks.Core.Entities;
using System;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MovBooks.Infrastructure.Data
{
    public class MovBooksContext : DbContext
    {
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
        public virtual DbSet<ViewsBooks> ViewsBooks { get; set; }
        public virtual DbSet<RatingBook> RatingsBooks { get; set; }

        //Configuration
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<Pqr> Pqrs { get; set; }
        public virtual DbSet<Parameter> Parameters { get; set; }

        /**
         * Seeds
         */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
            //Main Seeds
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Admin", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now });
            modelBuilder.Entity<Role>().HasData(
               new Role { Id = 2, Name = "User", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now });
            modelBuilder.Entity<User>().HasData(
              new User { Id = 1, Email = "admin@movbooks.com", Password = "12345678", Nickname = "AdminMovbooks", RoleId = 1, Enabled = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now });
        }


        /**
         * 
         * Override Save to work Created_at and Updated_at
         * 
         */
        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            AddTimestamps();
            return await base.SaveChangesAsync();
        }

        private void AddTimestamps()
        {
            var entities = ChangeTracker.Entries()
                .Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                var now = DateTime.UtcNow;

                if (entity.State == EntityState.Added)
                {
                    ((BaseEntity)entity.Entity).CreatedAt = now;
                }
                ((BaseEntity)entity.Entity).UpdatedAt = now;
            }
        }

    }
}
