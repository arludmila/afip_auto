using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class AFIPContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }

        public AFIPContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                var folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                var appSubfolder = System.IO.Path.Combine(folder, "AFIP Auto");
                if (!System.IO.Directory.Exists(appSubfolder))
                {
                    System.IO.Directory.CreateDirectory(appSubfolder);
                }

                var dbPath = System.IO.Path.Combine(appSubfolder, "afip_auto.db");

                optionsBuilder.UseSqlite($"Data Source={dbPath}");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Client>()
                .HasKey(c => new { c.CUIT, c.PhoneNumber });

            modelBuilder.Entity<Client>()
                .Property(c => c.CUIT)
                .IsRequired()
                .HasMaxLength(11);

            modelBuilder.Entity<Client>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Client>()
                .Property(c => c.PhoneNumber)
                .IsRequired()
                .HasMaxLength(10);
        }
    }
}
