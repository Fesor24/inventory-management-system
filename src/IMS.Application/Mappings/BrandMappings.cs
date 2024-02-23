using AutoMapper;
using IMS.Application.Features.Brand.Queries;

namespace IMS.Application.Mappings;
public class BrandMappings : Profile
{
    public BrandMappings()
    {
        CreateMap<BrandEntity, GetBrandResponse>()
            .ForMember(x => x.BrandId, o => o.MapFrom(s => s.Id));
    }
}
