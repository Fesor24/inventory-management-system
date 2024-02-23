using IMS.Domain.Shared;
using MediatR;

namespace IMS.Application.Features.Category.Commands.DeleteCategory;
public record DeleteCategoryCommand(Guid CategoryId) : IRequest<Result<Unit, Error>>;
