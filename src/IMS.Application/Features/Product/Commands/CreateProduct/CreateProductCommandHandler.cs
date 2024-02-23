using IMS.Application.Shared;
using IMS.Domain.Primitives;
using IMS.Domain.Shared;
using IMS.Infrastructure.Data.Specifications.CategorySpecifications;
using MediatR;

namespace IMS.Application.Features.Product.Commands.CreateProduct;
internal sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommand,
    Result<Guid, Error>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateProductCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid, Error>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var res = ProductEntity.Create(request.Name, request.Description, request.Price,
            request.Quantity, request.Status, request.CategoryId, request.ImageUrl);

        if (res.IsFailure)
            return ApplicationErrors.Product.BADREQUEST(res.Error.Message);

        var categorySpec = new GetCategorySpecification(request.CategoryId);

        var category = await _unitOfWork.Repository<CategoryEntity>().GetAsync(categorySpec);

        if (category is null)
            return ApplicationErrors.Category.NOTFOUND(request.CategoryId);

        await _unitOfWork.Repository<ProductEntity>()
            .AddAsync(res.Value, cancellationToken);

        await _unitOfWork.Complete();

        return res.Value.Id;
    }
}
