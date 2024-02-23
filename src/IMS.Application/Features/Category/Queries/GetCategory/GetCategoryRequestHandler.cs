using AutoMapper;
using IMS.Application.Shared;
using IMS.Domain.Primitives;
using IMS.Domain.Shared;
using IMS.Infrastructure.Data.Specifications.CategorySpecifications;
using MediatR;

namespace IMS.Application.Features.Category.Queries.GetCategory;
internal sealed class GetCategoryRequestHandler : IRequestHandler<GetCategoryRequest, Result<GetCategoryResponse, Error>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetCategoryRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<GetCategoryResponse, Error>> Handle(GetCategoryRequest request, 
        CancellationToken cancellationToken)
    {
        var spec = new GetCategorySpecification(request.CategoryId);

        var category = await _unitOfWork.Repository<CategoryEntity>().GetAsync(spec);

        if (category is null)
            return ApplicationErrors.Category.NOTFOUND(request.CategoryId);

        return _mapper.Map<GetCategoryResponse>(category);
    }
}
