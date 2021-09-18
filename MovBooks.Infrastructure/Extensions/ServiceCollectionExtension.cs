using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovBooks.Core.CustomEntities;
using MovBooks.Core.Interfaces;
using MovBooks.Core.Interfaces.Services;
using MovBooks.Core.Services;
using MovBooks.Infrastructure.Data;
using MovBooks.Infrastructure.Interfaces;
using MovBooks.Infrastructure.Repositories;
using MovBooks.Infrastructure.Services;

namespace MovBooks.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddCors(this IServiceCollection services, string namePolicy)
        {
            services.AddCors(options => {
                options.AddPolicy(name: namePolicy, builder => {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyHeader();
                    builder.AllowAnyMethod();
                });
            });
            return services;
        }

        public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MovBooksContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("MovBooks"));
            });
            return services;
        }

        public static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration configuration)
        {
            // Configurar Pagination Options
            // Configure crea un Singleton, entonces es como un dependency injection con el mapeo
            services.Configure<PaginationOptions>(options => configuration.GetSection("Pagination").Bind(options));

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            // Resolver dependencia Scoped para el Generic Repository
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

            // Resolver dependencia para la unidad de trabajo
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            // Servicios Core
            services.AddTransient<IPqrService, PqrService>();
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<IGenderService, GenderService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IMovieService, MovieService>();
            services.AddTransient<IParameterService, ParameterService>();
            services.AddTransient<IRatingBookService, RatingBookService>();
            services.AddTransient<IRatingMovieService, RatingMovieService>();
            services.AddTransient<IPasswordRecoveryService, PasswordRecoveryService>();

            // Servicios Infrastructure
            services.AddTransient<IMailService, MailService>();

            return services;
        }
    }
}
