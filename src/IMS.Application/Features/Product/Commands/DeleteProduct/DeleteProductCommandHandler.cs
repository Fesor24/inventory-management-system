using IMS.Application.Shared;
using IMS.Domain.Primitives;
using IMS.Domain.Shared;
using IMS.Infrastructure.Data.Specifications.ProductSpecifications;
using MediatR;

namespace IMS.Application.Features.Product.Commands.DeleteProduct;
internal sealed class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Result<Unit, Error>>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteProductCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Unit, Error>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var spec = new GetProductByIdSpecification(request.ProductId);

        var product = await _unitOfWork.Repository<ProductEntity>().GetAsync(spec);

        if (product is null)
            return ApplicationErrors.Product.NOTFOUND(request.ProductId);

        _unitOfWork.Repository<ProductEntity>().Delete(product);

        await _unitOfWork.Complete();

        return Unit.Value;
    }
}
