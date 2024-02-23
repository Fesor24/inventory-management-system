using AutoMapper;
using IMS.Application.Features.Category.Queries.GetCategory;

namespace IMS.Application.Mappings;
public class CategoryMappings : Profile
{
    public CategoryMappings()
    {
        CreateMap<CategoryEntity, GetCategoryResponse>()
            .ForMember(d => d.CategoryId, o => o.MapFrom(s => s.Id));
    }
}
