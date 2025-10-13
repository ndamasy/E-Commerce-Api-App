using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presistance.Data.Configurations
{
    public class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // 1. Relationship: Product -> ProductBrand (using BrandId)
            // We set this to RESTRICT to be safe and break one side of the potential cycle.
            builder.HasOne(p => p.ProductBrand)
                   .WithMany()
                   .HasForeignKey(p => p.BrandId)
                   .OnDelete(DeleteBehavior.Restrict); // <-- Restricted

            // 2. Relationship: Product -> ProductType (using TypeId)
            // The error explicitly names this constraint, so it MUST be restricted.
            builder.HasOne(p => p.ProductType)
                   .WithMany()
                   .HasForeignKey(p => p.TypeId)
                   .OnDelete(DeleteBehavior.Restrict); // <-- ADD/CHANGE THIS TO RESTRICT

            // Other Configurations
            builder.Property(p => p.Price).HasColumnType("Decimal (7,2)");
        }
    }
}