using IMS.Domain.Entities;

namespace IMS.Infrastructure.Data.Specifications.CategorySpecifications;
public class GetCategorySpecification : BaseSpecification<Category>
{
    public GetCategorySpecification(Guid categoryId) : base(x => x.Id == categoryId)
    {
        
    }
}
