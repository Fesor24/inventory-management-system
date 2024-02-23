using IMS.Domain.Errors;
using IMS.Domain.Primitives;
using IMS.Domain.Shared;

namespace IMS.Domain.Entities;
public sealed class Brand : BaseAuditableEntity<Guid>
{
    public Brand()
    {
        
    }

    private Brand(Guid id, string name, string description) : base(id)
    {
        Name = name;
        Description = description;
    }

    public static Result<Brand, Error> Create(string name, string description)
    {
        if (string.IsNullOrWhiteSpace(name))
            return DomainError.Brand.InvalidName;

        if (name.Length > 100)
            return DomainError.Brand.MaximumLengthExceeded("Name", 100);

        Brand brand = new(Guid.NewGuid(), name, description);

        return brand;
    }

    public Result<Brand, Error> Delete()
    {
        IsDeleted = true;

        return this;
    }

    public string Name { get; private set; }
    public string Description { get; private set; }
    public bool IsDeleted { get; private set; }
    public ICollection<Category> Categories { get; }
}
