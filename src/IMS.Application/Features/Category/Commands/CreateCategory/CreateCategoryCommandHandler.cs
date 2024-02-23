using IMS.Application.Shared;
using IMS.Domain.Primitives;
using IMS.Domain.Shared;
using MediatR;

namespace IMS.Application.Features.Category.Commands.CreateCategory;
internal sealed class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand,
    Result<Guid, Error>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateCategoryCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid, Error>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var res = CategoryEntity.Create(request.Name, request.Description, request.BrandId);

        if (res.IsFailure)
            return ApplicationErrors.Brand.BADREQUEST(res.Error.Message);

        await _unitOfWork.Repository<CategoryEntity>()
            .AddAsync(res.Value, cancellationToken);

        await _unitOfWork.Complete();

        return res.Value.Id;
    }
}
