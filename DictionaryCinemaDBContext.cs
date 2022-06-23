using Cinema_Dictionary.Model;
using Microsoft.EntityFrameworkCore;

namespace Cinema_Dictionary
{
    public partial class DictionaryCinemaDBContext : DbContext
    {
        public DictionaryCinemaDBContext()
        {
            Database.EnsureCreated();
        }

        public DictionaryCinemaDBContext(DbContextOptions<DictionaryCinemaDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cinema> Cinemas { get; set; } = null!;
        public virtual DbSet<Session> Sessions { get; set; } = null!;
        public virtual DbSet<Theatre> Theatres { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=DictionaryCinemaDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cinema>(entity =>
            {
                entity.HasKey(e => e.IdCinema);

                entity.ToTable("Cinema");

                entity.Property(e => e.Duraction).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Genre).HasMaxLength(50);

                entity.HasOne(d => d.Theatre)
                    .WithMany(p => p.Cinemas)
                    .HasForeignKey(d => d.TheatreId)
                    .HasConstraintName("FK_Cinema_Theatre");
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.HasKey(e => e.IdSession);

                entity.ToTable("Session");

                entity.Property(e => e.DateSession).HasColumnType("date");

                entity.Property(e => e.End).HasColumnType("time(2)");

                entity.Property(e => e.Start).HasColumnType("time(2)");

                entity.HasOne(d => d.Cinema)
                    .WithMany(p => p.Sessions)
                    .HasForeignKey(d => d.CinemaId)
                    .HasConstraintName("FK_Session_Cinema");
            });

            modelBuilder.Entity<Theatre>(entity =>
            {
                entity.HasKey(e => e.IdTeathre);

                entity.ToTable("Theatre");

                entity.Property(e => e.End).HasColumnType("time(2)");

                entity.Property(e => e.Korpus).HasMaxLength(10);

                entity.Property(e => e.Number).HasMaxLength(50);

                entity.Property(e => e.Open).HasColumnType("time(2)");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.Street).HasMaxLength(50);

                entity.Property(e => e.Title).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
