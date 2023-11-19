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
    public class OfferEntityTypeBuilder : IEntityTypeConfiguration<Offer>
    {
        public void Configure(EntityTypeBuilder<Offer> builder)
        {
            builder.ToTable("Offers");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.Id).HasColumnName("OfferId");
            builder.Property(o => o.Price).HasColumnName("Price").IsRequired();
            builder.Property(o => o.Date).HasColumnName("Date").IsRequired();
            builder.Property(o => o.CustomerId).HasColumnName("CustomerId").IsRequired();

            builder.HasOne(o => o.Customer)
                .WithMany(c => c.Offers)
                .HasForeignKey(o => o.CustomerId);
        }
    }
}
