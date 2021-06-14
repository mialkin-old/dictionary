using System;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using Dictionary.Database;
using Dictionary.Database.Repositories.Word;
using Dictionary.Services.Models.Word;
using Dictionary.Services.Services.Word;
using Dictionary.Web.AutoMapper;
using Dictionary.Web.Configs;
using Dictionary.Web.Options;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration,
            IWebHostEnvironment environment)
        {
            DatabaseConfig config = configuration.GetSection(DatabaseConfig.Database).Get<DatabaseConfig>();
            string directory = Path.Combine(environment.ContentRootPath, config.Folder);
            Directory.CreateDirectory(directory);
            string path = Path.Combine(directory, config.File);

            services.AddDbContext<DictionaryDb>(options =>
                options.UseSqlite($"Data Source={path}", x => x.MigrationsAssembly("Dictionary.Web")));
        }

        public static void ConfigureAuthentication(this IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
                    config =>
                    {
                        config.Cookie.Name = CookieAuthenticationDefaults.AuthenticationScheme;
                        config.ExpireTimeSpan = TimeSpan.FromDays(30);
                        config.Events.OnRedirectToLogin = context =>
                        {
                            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                            return Task.FromResult<object>(null);
                        }; // https://github.com/dotnet/aspnetcore/issues/9039#issuecomment-629617025
                    });
        }

        public static void ConfigureMappers(this IServiceCollection services)
        {
            var mapperConfiguration = new MapperConfiguration(cfg => { cfg.AddProfile<MappingProfile>(); });
            services.AddSingleton(mapperConfiguration.CreateMapper());
        }

        public static void ConfigureOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions<LoginOptions>().Bind(configuration.GetSection(LoginOptions.Login))
                .ValidateDataAnnotations();
        }

        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddTransient<IWordRepository, WordRepository>();
        }
        
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddTransient<IWordService, WordService>();
        }
        
        public static void ConfigureValidators(this IServiceCollection services)
        {
            services.AddTransient<WordExistsValidator>();
        }
    }
}