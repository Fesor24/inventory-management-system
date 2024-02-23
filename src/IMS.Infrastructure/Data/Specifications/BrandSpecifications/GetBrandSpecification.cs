using IMS.Domain.Entities;

namespace IMS.Infrastructure.Data.Specifications.BrandSpecifications;
public sealed class GetBrandSpecification : BaseSpecification<Brand>
{
    public GetBrandSpecification(Guid brandId) : base(x => x.Id == brandId)
    {
        
    }
}
