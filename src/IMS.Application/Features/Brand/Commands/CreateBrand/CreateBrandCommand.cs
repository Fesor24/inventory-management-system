using IMS.Domain.Shared;
using MediatR;

namespace IMS.Application.Features.Brand.Commands.CreateBrand;
public record CreateBrandCommand(string Name, string Description) : IRequest<Result<Guid, Error>>;
