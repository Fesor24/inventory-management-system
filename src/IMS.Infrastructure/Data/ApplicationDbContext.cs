using IMS.Domain.Entities;
using IMS.Domain.Entities.ProductAggregates;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace IMS.Infrastructure.Data;
public class ApplicationDbContext : DbContext
{
    internal const string DEFAULT_SCHEMA = "prd";

    internal const string DATABASE_CONNECTION = "DefaultConnection";

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
        
    }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Brand> Brands => Set<Brand>();
    public DbSet<Category> Categories => Set<Category>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}
