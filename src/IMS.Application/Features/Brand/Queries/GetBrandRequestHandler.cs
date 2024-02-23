using AutoMapper;
using IMS.Application.Shared;
using IMS.Domain.Primitives;
using IMS.Domain.Shared;
using IMS.Infrastructure.Data.Specifications.BrandSpecifications;
using MediatR;

namespace IMS.Application.Features.Brand.Queries;
internal sealed class GetBrandRequestHandler : IRequestHandler<GetBrandRequest, Result<GetBrandResponse, Error>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetBrandRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<GetBrandResponse, Error>> Handle(GetBrandRequest request, CancellationToken cancellationToken)
    {
        var spec = new GetBrandSpecification(request.BrandId);

        var brand = await _unitOfWork.Repository<BrandEntity>().GetAsync(spec);

        if (brand is null)
            return ApplicationErrors.Brand.NOTFOUND(request.BrandId);

        return _mapper.Map<GetBrandResponse>(brand);
    }
}
