using IMS.Application.Shared;
using IMS.Domain.Primitives;
using IMS.Domain.Shared;
using IMS.Infrastructure.Data.Specifications.BrandSpecifications;
using MediatR;

namespace IMS.Application.Features.Brand.Commands.DeleteBrand;
internal sealed class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, Result<Unit, Error>>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteBrandCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Unit, Error>> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
    {
        var spec = new GetBrandSpecification(request.BrandId);

        var brand = await _unitOfWork.Repository<BrandEntity>().GetAsync(spec);

        if (brand is null)
            return ApplicationErrors.Brand.NOTFOUND(request.BrandId);

        var res = brand.Delete();

        if (res.IsFailure)
            return ApplicationErrors.Brand.BADREQUEST("An error occurred!!");

        _unitOfWork.Repository<BrandEntity>().Update(res.Value);

        await _unitOfWork.Complete();

        return Unit.Value;
    }
}
