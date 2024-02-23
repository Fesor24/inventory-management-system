using IMS.API.Abstractions;
using IMS.API.Extensions;
using IMS.Application.Features.Category.Commands.CreateCategory;
using IMS.Application.Features.Category.Commands.DeleteCategory;
using IMS.Application.Features.Category.Queries.GetCategory;
using MediatR;

namespace IMS.API.Endpoints;

public class CategoryEndpoints : IEndpointRegistration
{
    public void RegisterEndpoint(WebApplication app)
    {
        const string ENDPOINT = "category";

        app.MediatorPost<CreateCategoryCommand, Guid>(ENDPOINT, "/");
        app.MediatorDelete<DeleteCategoryCommand, Unit>(ENDPOINT, "/");
        app.MediatorGet<GetCategoryRequest, GetCategoryResponse>(ENDPOINT, "/");
    }
}
