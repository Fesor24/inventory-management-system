using IMS.Domain.Primitives;
using IMS.Domain.Shared;
using IMS.Infrastructure.Data.Specifications.ProductSpecifications;
using MediatR;
using IMS.Application.Shared;
using AutoMapper;

namespace IMS.Application.Features.Product.Queries.GetProduct;
internal sealed class GetProductRequestHandler : IRequestHandler<GetProductRequest,
    Result<GetProductResponse, Error>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetProductRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<GetProductResponse, Error>> Handle(GetProductRequest request, 
        CancellationToken cancellationToken)
    {
        var spec = new GetProductByIdSpecification(request.ProductId);

        var product = await _unitOfWork.Repository<ProductEntity>()
            .GetAsync(spec, cancellationToken);

        if (product is null)
            return ApplicationErrors.Product.NOTFOUND(request.ProductId);

        return _mapper.Map<GetProductResponse>(product);
    }
}
