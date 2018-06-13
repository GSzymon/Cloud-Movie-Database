using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.AppData
{
    public class CmdDbContext : DbContext
    {
        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<ActorMovie> ActorsMovies { get; set; }

        public CmdDbContext(DbContextOptions<CmdDbContext> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=35.234.102.251;user=root;password=123456;database=cmd_database");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActorMovie>()
                .HasKey(bc => new { bc.ActorId, bc.MovieId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
