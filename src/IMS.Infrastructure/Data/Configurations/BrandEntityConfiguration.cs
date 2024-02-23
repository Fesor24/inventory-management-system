using IMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IMS.Infrastructure.Data.Configurations;
internal sealed class BrandEntityConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.ToTable(nameof(Brand), ApplicationDbContext.DEFAULT_SCHEMA);
        builder.Property(x => x.Name)
            .HasMaxLength(100);
        builder.Property(x => x.Description)
            .IsRequired(false);
        builder.HasMany(x => x.Categories)
            .WithOne(x => x.Brand)
            .HasForeignKey(x => x.BrandId);
        builder.Property(x => x.IsDeleted)
            .HasDefaultValue(false);
    }
}
