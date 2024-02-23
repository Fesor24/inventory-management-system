using IMS.Domain.Shared;
using MediatR;

namespace IMS.Application.Features.Product.Commands.DeleteProduct;
public record DeleteProductCommand(Guid ProductId) : IRequest<Result<Unit, Error>>;
