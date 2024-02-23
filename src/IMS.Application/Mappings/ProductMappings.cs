using AutoMapper;
using IMS.Application.Features.Product.Queries.GetProduct;

namespace IMS.Application.Mappings;
public class ProductMappings : Profile
{
    public ProductMappings()
    {
        CreateMap<ProductEntity, GetProductResponse>()
            .ForMember(x => x.ProductId, o => o.MapFrom(s => s.Id))
            .ForMember(x => x.Name, o => o.MapFrom(s => s.ProductInfo.Name))
            .ForMember(x => x.Description, o => o.MapFrom(s => s.ProductInfo.Description));
    }
}
