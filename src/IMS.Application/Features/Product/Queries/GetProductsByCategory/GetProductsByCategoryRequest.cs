using IMS.Application.Features.Product.Queries.GetProduct;
using IMS.Domain.Shared;
using MediatR;

namespace IMS.Application.Features.Product.Queries.GetProductsByCategory;
public record GetProductsByCategoryRequest(Guid CategoryId) : 
    IRequest<Result<IReadOnlyList<GetProductResponse>, Error>>;
