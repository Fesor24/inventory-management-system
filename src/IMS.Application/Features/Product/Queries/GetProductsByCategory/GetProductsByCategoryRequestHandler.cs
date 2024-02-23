using AutoMapper;
using IMS.Application.Features.Product.Queries.GetProduct;
using IMS.Domain.Primitives;
using IMS.Domain.Shared;
using IMS.Infrastructure.Data.Specifications.ProductSpecifications;
using MediatR;

namespace IMS.Application.Features.Product.Queries.GetProductsByCategory;
internal sealed class GetProductsByCategoryRequestHandler : IRequestHandler<GetProductsByCategoryRequest,
    Result<IReadOnlyList<GetProductResponse>, Error>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetProductsByCategoryRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<IReadOnlyList<GetProductResponse>, Error>> Handle(GetProductsByCategoryRequest request, 
        CancellationToken cancellationToken)
    {
        var spec = new GetProductsSpecification(request.CategoryId);

        var products = await _unitOfWork.Repository<ProductEntity>()
            .GetAllAsync(spec);

        var res = _mapper.Map<IReadOnlyList<GetProductResponse>>(products);

        return new(res);
    }
}
