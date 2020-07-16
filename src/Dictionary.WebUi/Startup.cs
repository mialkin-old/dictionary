using System;
using System.IO;
using AutoMapper;
using Dictionary.Database;
using Dictionary.Database.Repositories.Word;
using Dictionary.Excel.Parsers;
using Dictionary.Excel.Parsers.Word;
using Dictionary.Services.Services.Import;
using Dictionary.Services.Services.Word;
using Dictionary.WebUi.AutoMapper;
using Dictionary.WebUi.Configs;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Dictionary.WebUi
{
    public class Startup
    {
        /// <summary>
        /// Absolute path to the database file.
        /// </summary>
        private readonly string _dbFileAbsolutePath;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;

            DatabaseConfig dbConfig = Configuration.GetSection("Database").Get<DatabaseConfig>();

            string dbFileDirectory = Path.Combine(env.ContentRootPath, dbConfig.Folder);
            Directory.CreateDirectory(dbFileDirectory);
            _dbFileAbsolutePath = Path.Combine(dbFileDirectory, dbConfig.File);
        }

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
                    config =>
                    {
                        config.Cookie.Name = CookieAuthenticationDefaults.AuthenticationScheme;
                        config.ExpireTimeSpan = TimeSpan.FromDays(30);
                    });

            services.AddControllersWithViews();
            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration => { configuration.RootPath = "npm-build"; });
            services.AddDbContext<DictionaryDb>(options => options.UseSqlite($"Data Source={_dbFileAbsolutePath}"));

            var mapperConfiguration = new MapperConfiguration(cfg => { cfg.AddProfile<MappingProfile>(); });
            services.AddSingleton(mapperConfiguration.CreateMapper());

            services.AddTransient<IWordRepository, WordRepository>();
            services.AddTransient<IWordService, WordService>();
            services.AddTransient<IExcelParser<WordImportModel>, WordsImportParser>();
            services.AddTransient<IImportService, ImportService>();

            string adminPassword = Environment.GetEnvironmentVariable("ADMIN_PASSWORD");
            if(string.IsNullOrWhiteSpace(adminPassword))
                throw new ArgumentNullException(adminPassword,"Environment variable ADMIN_PASSWORD must be specified");

            services.AddSingleton(new AccountConfig(adminPassword));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseHttpsRedirection();
            }

            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "api/{controller}/{action=Index}/{id?}");
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