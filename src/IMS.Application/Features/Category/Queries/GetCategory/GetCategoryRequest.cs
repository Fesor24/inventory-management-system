using IMS.Domain.Shared;
using MediatR;

namespace IMS.Application.Features.Category.Queries.GetCategory;
public record GetCategoryRequest(Guid CategoryId) : IRequest<Result<GetCategoryResponse, Error>>;
