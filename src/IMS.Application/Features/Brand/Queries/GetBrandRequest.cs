using IMS.Domain.Shared;
using MediatR;

namespace IMS.Application.Features.Brand.Queries;
public record GetBrandRequest(Guid BrandId) : IRequest<Result<GetBrandResponse, Error>>;
