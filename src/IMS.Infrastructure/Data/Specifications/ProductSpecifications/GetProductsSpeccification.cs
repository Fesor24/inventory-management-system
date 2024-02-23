using IMS.Domain.Entities.ProductAggregates;

namespace IMS.Infrastructure.Data.Specifications.ProductSpecifications;
public class GetProductsSpecification : BaseSpecification<Product>
{
    public GetProductsSpecification()
    {
        
    }

    public GetProductsSpecification(Guid categoryId) : base(x => x.CategoryId == categoryId)
    {
        SetOrderByDesc(x => x.CreatedAt);
    }
}
