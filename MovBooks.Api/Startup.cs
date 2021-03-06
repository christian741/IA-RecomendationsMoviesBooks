using System;
using System.Text;
using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using MovBooks.Api.Models;
using MovBooks.Infrastructure.Extensions;
using MovBooks.Infrastructure.Filters;
using Newtonsoft.Json;

namespace MovBooks.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Configure Cors
            services.AddCors(MyAllowSpecificOrigins);

            // Configurar el Automapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddControllers(options =>
            {
                // Agregar Global Exception Filter
                options.Filters.Add<GlobalExceptionFilter>();
            }).AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            }).ConfigureApiBehaviorOptions(options =>
            {
                // Configurar el comportamiento del [ApiController] decorator
                // options.SuppressModelStateInvalidFilter = true;
            });

            // Access HttpContext
            services.AddHttpContextAccessor();

            // Configure Options
            services.AddOptions(Configuration);

            // DbContext
            services.AddDbContexts(Configuration);

            // Services
            services.AddServices();

            // Authentication con JWT (agregar antes de MVC por el Middleware)
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Authentication:Issuer"],
                    ValidAudience = Configuration["Authentication:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Authentication:SecretKey"]))
                };
            });

            // Configure MVC
            services.AddMvc(options =>
            {
                // Configurar nuestro filtro/middleware de forma global
                options.Filters.Add<ValidationFilter>();
            }).AddFluentValidation(options =>
            {
                // Agregar el Fluent Validator para no usar DataAnnotations en los DTOs (aunque perfectamente se podr?a hacer)
                options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            });

            // Authorization Roles
            services.AddAuthorization(config => {
                config.AddPolicy(Policies.Admin, Policies.AdminPolicy());
                config.AddPolicy(Policies.User, Policies.UserPolicy());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseDefaultFiles(); // para utilizar el index.html

            app.UseStaticFiles();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
