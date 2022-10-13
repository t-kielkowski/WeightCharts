using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WeightChart.Infrastructure.DbModel;

namespace WeightChart.Infrastructure
{
    public partial class SensorReadingsContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public SensorReadingsContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public virtual DbSet<Bh1750> Bh1750s { get; set; } = null!;
        public virtual DbSet<Bmp280> Bmp280s { get; set; } = null!;
        public virtual DbSet<Hdc1080> Hdc1080s { get; set; } = null!;
        public virtual DbSet<Sht31> Sht31s { get; set; } = null!;
        public virtual DbSet<Sht31test> Sht31tests { get; set; } = null!;
        public virtual DbSet<SoilMoisture> SoilMoistures { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = Configuration.GetConnectionString("MySqlDatabase");
                optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("latin1_swedish_ci")
                .HasCharSet("latin1");

            modelBuilder.Entity<Bh1750>(entity =>
            {
                entity.ToTable("BH1750");

                entity.Property(e => e.Id).HasColumnType("int(6) unsigned");

                entity.Property(e => e.Luks).HasMaxLength(10);

                entity.Property(e => e.ReadingTime)
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasDefaultValueSql("current_timestamp()");
            });

            modelBuilder.Entity<Bmp280>(entity =>
            {
                entity.ToTable("BMP280");

                entity.Property(e => e.Id).HasColumnType("int(6) unsigned");

                entity.Property(e => e.Pressure).HasMaxLength(10);

                entity.Property(e => e.ReadingTime)
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.Temperature).HasMaxLength(10);
            });

            modelBuilder.Entity<Hdc1080>(entity =>
            {
                entity.ToTable("HDC1080");

                entity.Property(e => e.Id).HasColumnType("int(6) unsigned");

                entity.Property(e => e.Moisture).HasMaxLength(10);

                entity.Property(e => e.ReadingTime)
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.Temperature).HasMaxLength(10);
            });

            modelBuilder.Entity<Sht31>(entity =>
            {
                entity.ToTable("SHT31");

                entity.Property(e => e.Id).HasColumnType("int(6) unsigned");

                entity.Property(e => e.Moisture).HasMaxLength(10);

                entity.Property(e => e.ReadingTime)
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.Temperature).HasMaxLength(10);
            });

            modelBuilder.Entity<Sht31test>(entity =>
            {
                entity.ToTable("SHT31TEST");

                entity.Property(e => e.Id).HasColumnType("int(6) unsigned");

                entity.Property(e => e.BatteryLevel).HasMaxLength(6);

                entity.Property(e => e.Moisture).HasMaxLength(10);

                entity.Property(e => e.ReadingTime)
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.Sensor).HasMaxLength(10);

                entity.Property(e => e.Temperature).HasMaxLength(10);
            });

            modelBuilder.Entity<SoilMoisture>(entity =>
            {
                entity.ToTable("SoilMoisture");

                entity.Property(e => e.Id).HasColumnType("int(6) unsigned");

                entity.Property(e => e.Moisture).HasMaxLength(10);

                entity.Property(e => e.ReadingTime)
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasDefaultValueSql("current_timestamp()");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
