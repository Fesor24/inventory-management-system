using IMS.Domain.Shared;
using MediatR;

namespace IMS.Application.Features.Product.Queries.GetProduct;
public record GetProductRequest(Guid ProductId) : IRequest<Result<GetProductResponse, Error>>;
