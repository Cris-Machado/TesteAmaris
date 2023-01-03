using Amaris.Consolidacao.Data.Context;
using Amaris.Consolidacao.Data.Interfaces;
using Amaris.Consolidacao.Data.Repositories;
using Amaris.Consolidacao.Data.Repositories.Base;
using Amaris.Consolidacao.Data.UnitOfWork;
using Amaris.Consolidacao.Identity.Context;
using Amaris.Consolidacao.Identity.Entities;
using Amaris.Consolidacao.Service.Interfaces.Repository;
using Amaris.Consolidacao.Service.Interfaces.Service;
using Amaris.Consolidacao.Service.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Amaris.Consolidacao.IoC
{
    public class InjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            #region Application
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IDbContext, ConsolidacaoContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<ConsolidacaoContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Default"))
            );
            #endregion

            #region ## Identity
            services.AddDbContext<IdentityContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Default"))
            );

            services.Configure<IdentityOptions>(options =>
            {
                // Default Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
            });
            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<IdentityContext>()
                .AddDefaultTokenProviders();

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear(); // => remove default claims
            services
                .AddAuthentication()
                .AddJwtBearer(cfg =>
                {
                    cfg.RequireHttpsMetadata = false;
                    cfg.SaveToken = true;
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = configuration["JwtIssuer"],
                        ValidAudience = configuration["JwtIssuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtKey"])),
                        ClockSkew = TimeSpan.Zero
                    };
                });
            #endregion

            #region Services
            services.AddScoped<IUsersService, UsersService>();
            #endregion

            #region Repositories
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IUsersRepository, UsersRepository>();
            #endregion
        }
    }
}