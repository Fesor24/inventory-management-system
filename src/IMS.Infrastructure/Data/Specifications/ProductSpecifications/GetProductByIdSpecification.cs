using IMS.Domain.Entities.ProductAggregates;

namespace IMS.Infrastructure.Data.Specifications.ProductSpecifications;
public sealed class GetProductByIdSpecification : BaseSpecification<Product>
{
    public GetProductByIdSpecification(Guid id) : base(x => x.Id == id)
    {
        AddInclude(x => x.Category);
    }
}
