using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;
using WebAPI.AppData;
using WebAPI.Handlers;
using WebAPI.Models;
using WebAPI.Repositories;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("CmdConnection");
            var connection = new MySqlConnection(connectionString);
            connection.Open();

            services.AddDbContext<CmdDbContext>(x => x.UseMySQL(connection));
            services.AddTransient<MoviesHandler>();
            services.AddTransient<IMovieRepository, MovieRepository>();
            services.AddTransient<IActorRepository, ActorRepository>();
            services.AddTransient<IActorMovieRepository, ActorMovieRepository>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
