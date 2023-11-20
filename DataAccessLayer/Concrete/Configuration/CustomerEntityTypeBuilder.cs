using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Configuration
{
    public class CustomerEntityTypeBuilder : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).HasColumnName("Id");
            builder.Property(c => c.FirstName).HasColumnName("FirstName").IsRequired().HasMaxLength(50);
            builder.Property(c => c.LastName).HasColumnName("LastName").IsRequired().HasMaxLength(50);
            builder.Property(c => c.Email).HasColumnName("Email").IsRequired().HasMaxLength(100);
            builder.Property(c => c.PhoneNumber).HasColumnName("PhoneNumber").IsRequired().HasMaxLength(20);

            builder.HasMany(c => c.Offers)
                .WithOne(o => o.Customer)
                .HasForeignKey(o => o.CustomerId);

            builder.HasMany(c => c.Sales)
                .WithOne(s => s.Customer)
                .HasForeignKey(s => s.CustomerId);
        }
    }
}
