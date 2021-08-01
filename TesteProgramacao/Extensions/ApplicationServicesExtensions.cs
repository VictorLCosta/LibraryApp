using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TesteProgramacao.Data.Context;
using TesteProgramacao.Interfaces;
using TesteProgramacao.Repositories;
using TesteProgramacao.Repositories.Contracts;
using TesteProgramacao.Services;

namespace TesteProgramacao.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, 
            IConfiguration config)
        {
            #region Repositories
            services.AddTransient<IBooksRepository, BooksRepository>();
            services.AddTransient<IAuthorRepository, AuthorRepository>();
            services.AddTransient<IPublisherRepository, PublisherRepository>();
            #endregion
            
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    config.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            return services;
        }
    }
}