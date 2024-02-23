using IMS.Domain.Shared;
using MediatR;

namespace IMS.Application.Features.Category.Commands.CreateCategory;
public record CreateCategoryCommand(string Name, string Description, Guid BrandId) :
    IRequest<Result<Guid, Error>>;
