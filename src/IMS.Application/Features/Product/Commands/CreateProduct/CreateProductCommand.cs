using IMS.Domain.Entities.ProductAggregates;
using IMS.Domain.Shared;
using MediatR;

namespace IMS.Application.Features.Product.Commands.CreateProduct;
public record CreateProductCommand(
    string Name,
    string Description,
    int Quantity,
    ProductStatus Status,
    decimal Price,
    Guid CategoryId,
    string ImageUrl
    ) : IRequest<Result<Guid, Error>>;
