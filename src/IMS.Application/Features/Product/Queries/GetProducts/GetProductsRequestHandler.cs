using AutoMapper;
using IMS.Application.Features.Product.Queries.GetProduct;
using IMS.Domain.Primitives;
using IMS.Domain.Shared;
using MediatR;

namespace IMS.Application.Features.Product.Queries.GetProducts;
internal sealed class GetProductsRequestHandler : IRequestHandler<GetProductsRequest,
    Result<IReadOnlyList<GetProductResponse>, Error>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetProductsRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<IReadOnlyList<GetProductResponse>, Error>> Handle(GetProductsRequest request, 
        CancellationToken cancellationToken)
    {
        var products = await _unitOfWork.Repository<ProductEntity>()
            .GetAllAsync(cancellationToken);

        var res = _mapper.Map<IReadOnlyList<GetProductResponse>>(products);

        return new(res);
    }
}
