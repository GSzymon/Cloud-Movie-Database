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
        public virtual DbSet<StarringDetails> StarringDetails { get; set; }
        
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
            modelBuilder.Entity<Actor>(entity =>
            {
                entity.HasKey(e => e.ActorId);

                entity.Property(e => e.ActorId).HasColumnType("int(11)");

                entity.Property(e => e.Birthday).HasMaxLength(255);

                entity.Property(e => e.Filmography).HasMaxLength(255);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasKey(e => e.MovieId);

                entity.Property(e => e.MovieId).HasColumnType("int(11)");

                entity.Property(e => e.Genre).HasMaxLength(255);

                entity.Property(e => e.StarringActors)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Year).HasColumnType("int(11)");
            });

            modelBuilder.Entity<StarringDetails>(entity =>
            {
                entity.HasKey(e => new { e.ActorId, e.MovieId });

                entity.HasIndex(e => e.MovieId)
                    .HasName("SD_M_FK_idx");

                entity.Property(e => e.ActorId).HasColumnType("int(11)");

                entity.Property(e => e.MovieId).HasColumnType("int(11)");

                entity.HasOne(d => d.Actor)
                    .WithMany(p => p.StarringDetails)
                    .HasForeignKey(d => d.ActorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SD_A_FK");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.StarringDetails)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SD_M_FK");
            });
        }
    }
}
