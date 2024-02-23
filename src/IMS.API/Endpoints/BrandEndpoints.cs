using IMS.API.Abstractions;
using IMS.API.Extensions;
using IMS.Application.Features.Brand.Commands.CreateBrand;
using IMS.Application.Features.Brand.Commands.DeleteBrand;
using IMS.Application.Features.Brand.Queries;
using MediatR;

namespace IMS.API.Endpoints;

public class BrandEndpoints : IEndpointRegistration
{
    public void RegisterEndpoint(WebApplication app)
    {
        const string ENDPOINT = "brand";

        app.MediatorPost<CreateBrandCommand, Guid>(ENDPOINT, "/");
        app.MediatorGet<GetBrandRequest, GetBrandResponse>(ENDPOINT, "/");
        app.MediatorDelete<DeleteBrandCommand, Unit>(ENDPOINT, "/");
    }
}
