using IMS.Domain.Entities.ProductAggregates;
using IMS.Domain.Errors;
using IMS.Domain.Primitives;
using IMS.Domain.Shared;

namespace IMS.Domain.Entities;
public sealed class Category : BaseAuditableEntity<Guid>
{
    public Category()
    {
        
    }

    private Category(Guid id, string name, string description, Guid brandId) : base(id)
    {
        Name = name;
        Description = description;
        BrandId = brandId;
    }

    public static Result<Category, Error> Create(string name, string description, Guid brandId)
    {
        if (string.IsNullOrWhiteSpace(name))
            return DomainError.Category.InvalidName;

        if (name.Length > 100)
            return DomainError.Category.MaximumLengthExceeded("Name", 100);

        Category category = new(Guid.NewGuid(), name, description, brandId);

        return category;
    }

    public Result<Category, Error> Delete()
    {
        IsDeleted = true;

        return this;
    }

    public string Name { get; private set; }
    public string Description { get;private set; }
    public Guid BrandId { get; private set; }
    public Brand Brand { get; set; }
    public bool IsDeleted { get; private set; }
    public ICollection<Product> Products { get; }
}
