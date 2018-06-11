using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.AppData
{
    public class CmdDbContext : DbContext
    {
        //public CmdDbContext()
        //{
        //}

        public CmdDbContext(DbContextOptions<CmdDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<ActorMovie> ActorsMovies { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=35.234.102.251;user=root;password=123456;database=cmd_database");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActorMovie>()
                .HasKey(bc => new { bc.ActorId, bc.MovieId });

            //modelBuilder.Entity<ActorMovie>()
            //    .HasOne(bc => bc.Actor)
            //    .WithMany(b => b.ActorMovie)
            //    .HasForeignKey(bc => bc.ActorId);

            //modelBuilder.Entity<ActorMovie>()
            //    .HasOne(bc => bc.Movie)
            //    .WithMany(c => c.ActorMovie)
            //    .HasForeignKey(bc => bc.MovieId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
