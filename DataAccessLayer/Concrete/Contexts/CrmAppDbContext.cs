using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Entities.Concrete;
using DataAccessLayer.Concrete.Configuration;

namespace DataAccessLayer.Concrete.Contexts
{
    public class CrmAppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=MFE\\SQLEXPRESS;initial catalog=CrmAppDb;integrated security=True;TrustServerCertificate=True;");
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Sale> Sales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CustomerEntityTypeBuilder());
            modelBuilder.ApplyConfiguration(new OfferEntityTypeBuilder());
            modelBuilder.ApplyConfiguration(new SaleEntityTypeBuilder());
        }
    }
}
