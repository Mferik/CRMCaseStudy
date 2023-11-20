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
    public class SaleEntityTypeBuilder : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("Sales");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id).HasColumnName("Id");
            builder.Property(s => s.Price).HasColumnName("Price").IsRequired();
            builder.Property(s => s.Date).HasColumnName("Date").IsRequired();
            builder.Property(s => s.CustomerId).HasColumnName("CustomerId").IsRequired();

            builder.HasOne(s => s.Customer)
                .WithMany(c => c.Sales)
                .HasForeignKey(s => s.CustomerId);
        }
    }
}
