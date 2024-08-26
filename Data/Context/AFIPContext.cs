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
            //IDEA: deberia cambiarlo por una base de datos local mejor, sqlite?
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=afip_auto;Trusted_Connection=True;TrustServerCertificate=True;");
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
