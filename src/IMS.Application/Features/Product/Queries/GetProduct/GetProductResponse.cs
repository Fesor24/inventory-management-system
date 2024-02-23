using IMS.Application.Features.Category.Queries.GetCategory;

namespace IMS.Application.Features.Product.Queries.GetProduct;
public class GetProductResponse
{
    public Guid ProductId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public string Status { get; set; }
    public bool OutOfStock { get; set; }
    public DateTime CreatedAt { get; set; }
    public GetCategoryResponse Category { get; set; }
}
