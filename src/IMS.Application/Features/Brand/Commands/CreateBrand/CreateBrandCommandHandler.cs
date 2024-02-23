using IMS.Application.Shared;
using IMS.Domain.Primitives;
using IMS.Domain.Shared;
using MediatR;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleToAttribute("IMS.UnitTests")]

namespace IMS.Application.Features.Brand.Commands.CreateBrand;
internal sealed class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand,
    Result<Guid, Error>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateBrandCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid, Error>> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
    {
        var res = BrandEntity.Create(request.Name, request.Description);

        if (res.IsFailure)
            return ApplicationErrors.Brand.BADREQUEST(res.Error.Message);

        await _unitOfWork.Repository<BrandEntity>()
            .AddAsync(res.Value, cancellationToken);

        await _unitOfWork.Complete();

        return res.Value.Id;
    }
}
