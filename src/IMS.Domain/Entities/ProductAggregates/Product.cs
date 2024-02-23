using IMS.Domain.Errors;
using IMS.Domain.Primitives;
using IMS.Domain.Shared;

namespace IMS.Domain.Entities.ProductAggregates;
public sealed class Product : BaseAuditableEntity<Guid>
{
    public Product()
    {

    }

    private Product(Guid id, string name, string description, decimal price,
        int quantity, ProductStatus status, Guid categoryId, string imageUrl) : base(id)
    {
        Price = price;
        Quantity = quantity;
        CategoryId = categoryId;
        ProductInfo = new(name, description);
        Status = status;
        ImageUrl = imageUrl;
    }

    public static Result<Product, Error> Create(string name, string description,
        decimal price, int quantity, ProductStatus status, Guid categoryId, string imageUrl)
    {
        if (string.IsNullOrWhiteSpace(name))
            return DomainError.Product.InvalidName;

        if (name.Length > 100)
            return DomainError.Product.MaximumLengthExceeded("Name", 100);

        if (quantity < 0)
            return DomainError.Product.InvalidQuantity;

        if (price < 0)
            return DomainError.Product.InvalidPrice;

        if (!Enum.IsDefined(typeof(ProductStatus), status))
            return DomainError.Product.InvalidStatus;

        Product product = new(Guid.NewGuid(), name, description, price, quantity, status, 
            categoryId, imageUrl);

        return product;
    }

    public ProductInfo ProductInfo { get; private set; }
    public decimal Price { get; private set; }
    public int Quantity { get; private set; }
    public bool OutOfStock => Quantity == 0;
    public string ImageUrl { get; private set; }
    public ProductStatus Status { get; private set; }
    public Guid CategoryId { get; private set; }
    public Category Category { get; set; }
}
