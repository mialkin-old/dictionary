using System;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using Dictionary.Database;
using Dictionary.Database.Repositories.Word;
using Dictionary.Services.Configs;
using Dictionary.Services.Models.Account;
using Dictionary.Services.Models.Word;
using Dictionary.Services.Services.Account;
using Dictionary.Services.Services.Word;
using Dictionary.Web.AutoMapper;
using Dictionary.Web.Configs;
using Dictionary.Web.Options;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Dictionary.Web
{
    public class Startup
    {
        private readonly string _dbFilePath;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;

            DatabaseConfig databaseConfig = Configuration.GetSection("Database").Get<DatabaseConfig>();

            string dbFileDirectory = Path.Combine(env.ContentRootPath, databaseConfig.Folder);
            Directory.CreateDirectory(dbFileDirectory);
            _dbFilePath = Path.Combine(dbFileDirectory, databaseConfig.File);
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
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


            services.AddControllersWithViews();
            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration => { configuration.RootPath = "ClientApp/build"; });

            services.AddDbContext<DictionaryDb>(options => options.UseSqlite($"Data Source={_dbFilePath}"));

            var mapperConfiguration = new MapperConfiguration(cfg => { cfg.AddProfile<MappingProfile>(); });
            services.AddSingleton(mapperConfiguration.CreateMapper());

            services.AddOptions<LoginOptions>().Bind(Configuration.GetSection(LoginOptions.Login))
                .ValidateDataAnnotations();

            services.AddTransient<IWordRepository, WordRepository>();
            services.AddTransient<IWordService, WordService>();
            services.AddTransient<WordExistsValidator>();
            services.AddTransient<UserCredentialsValidator>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();
            
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}