using IMS.API.Abstractions;
using IMS.API.Extensions;
using IMS.Application.Features.Product.Commands.CreateProduct;
using IMS.Application.Features.Product.Commands.DeleteProduct;
using IMS.Application.Features.Product.Queries.GetProduct;
using IMS.Application.Features.Product.Queries.GetProducts;
using IMS.Application.Features.Product.Queries.GetProductsByCategory;
using MediatR;

namespace IMS.API.Endpoints;

public class ProductEndpoints : IEndpointRegistration
{
    public void RegisterEndpoint(WebApplication app)
    {
        const string ENDPOINT = "Product";

        app.MediatorGet<GetProductRequest, GetProductResponse>(ENDPOINT, "/");
        app.MediatorGet<GetProductsRequest, IReadOnlyList<GetProductResponse>>(ENDPOINT, "/list");
        app.MediatorGet<GetProductsByCategoryRequest, IReadOnlyList<GetProductResponse>>(ENDPOINT, "/category");
        app.MediatorPost<CreateProductCommand, Guid>(ENDPOINT, "/");
        app.MediatorDelete<DeleteProductCommand, Unit>(ENDPOINT, "/");
    }
}
