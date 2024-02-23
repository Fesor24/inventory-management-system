using IMS.Application.Features.Product.Queries.GetProduct;
using IMS.Domain.Shared;
using MediatR;

namespace IMS.Application.Features.Product.Queries.GetProducts;
public record GetProductsRequest() : IRequest<Result<IReadOnlyList<GetProductResponse>, Error>>;
