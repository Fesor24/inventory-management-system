using IMS.Application.Shared;
using IMS.Domain.Primitives;
using IMS.Domain.Shared;
using IMS.Infrastructure.Data.Specifications.CategorySpecifications;
using MediatR;

namespace IMS.Application.Features.Category.Commands.DeleteCategory;
internal sealed class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand,
    Result<Unit, Error>>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCategoryCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Unit, Error>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var spec = new GetCategorySpecification(request.CategoryId);

        var category = await _unitOfWork.Repository<CategoryEntity>().GetAsync(spec);

        if (category is null)
            return ApplicationErrors.Category.NOTFOUND(request.CategoryId);

        var res = category.Delete();

        if (res.IsFailure)
            return ApplicationErrors.Category.BADREQUEST("An error occurred!!");

        _unitOfWork.Repository<CategoryEntity>().Update(res.Value);

        await _unitOfWork.Complete();

        return Unit.Value;
    }
}
