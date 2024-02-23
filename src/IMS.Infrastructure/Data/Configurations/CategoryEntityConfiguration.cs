using IMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IMS.Infrastructure.Data.Configurations;
internal sealed class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable(nameof(Category), ApplicationDbContext.DEFAULT_SCHEMA);
        builder.Property(x => x.Name)
            .HasMaxLength(100);

        builder.Property(x => x.Description)
            .IsRequired(false);

        builder.HasMany(x => x.Products)
            .WithOne(x => x.Category)
            .HasForeignKey(x => x.CategoryId);
        builder.Property(x => x.IsDeleted)
            .HasDefaultValue(false);
    }
}
