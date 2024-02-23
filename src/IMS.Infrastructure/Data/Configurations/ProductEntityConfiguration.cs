using IMS.Domain.Entities.ProductAggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IMS.Infrastructure.Data.Configurations;
internal sealed class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable(nameof(Product), ApplicationDbContext.DEFAULT_SCHEMA);
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Price)
            .HasColumnType("MONEY");
        builder.OwnsOne(x => x.ProductInfo, productInfoBuilder =>
        {
            productInfoBuilder.Property(x => x.Name)
            .HasMaxLength(100);

            productInfoBuilder.Property(x => x.Description)
            .IsRequired(false);
        });
        builder.Property(x => x.Status)
            .HasConversion(p => p.ToString(),
            s => (ProductStatus)Enum.Parse(typeof(ProductStatus), s));
    }
}
