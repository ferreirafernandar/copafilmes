using CopaFilmes.Models;
using CopaFilmes.Services;
using CopaFilmes.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CopaFilmes
{
    public class Startup
    {
        public static IConfiguration Configuration { get; set; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", false, true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();

            Configuration.GetSection("ApplicationSettings").Bind(Singleton.AppSettings);
        }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddCors();
            services.AddCors(options => options.AddPolicy("AllowMyOrigin", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials()));

            services.AddScoped<IHttpClient, HttpClient>();
            services.AddScoped<ICopaFilmesService, CopaFilmesService>();
            services.Configure<AppSettings>(Configuration.GetSection("ApplicationSettings"));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseCors("AllowMyOrigin");
        }
    }
}
