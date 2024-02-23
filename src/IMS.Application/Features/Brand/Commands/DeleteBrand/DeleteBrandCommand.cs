using IMS.Domain.Shared;
using MediatR;

namespace IMS.Application.Features.Brand.Commands.DeleteBrand;
public record DeleteBrandCommand(Guid BrandId) : IRequest<Result<Unit, Error>>;
