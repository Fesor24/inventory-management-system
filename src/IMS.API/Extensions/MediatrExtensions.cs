using IMS.API.Shared;
using IMS.Application.Shared;
using IMS.Domain.Shared;
using MediatR;

namespace IMS.API.Extensions;

internal static class MediatrExtensions
{
    internal static void MediatorPost<TRequest, TResponse>(this WebApplication app, string endpointGroup, string route)
        where TRequest: IRequest<Result<TResponse, Error>>
    {
        route = "/api/" + endpointGroup + route;

        app.MapPost(route, HandlePostEndpointRequests<TRequest, TResponse>)
            .WithGroupName(endpointGroup);
    }

    internal static void MediatorGet<TRequest, TResponse>(this WebApplication app, string endpointGroup, string route)
        where TRequest : IRequest<Result<TResponse, Error>>
    {
        route = "/api/" + endpointGroup + route;

        app.MapGet(route, HandleGetEndpointRequests<TRequest, TResponse>)
            .WithGroupName(endpointGroup);
    }

    internal static void MediatorDelete<TRequest, TResponse>(this WebApplication app, string endpointGroup, string route)
        where TRequest : IRequest<Result<TResponse, Error>>
    {
        route = "/api/" + endpointGroup + route;

        app.MapDelete(route, HandleDeleteEndpointRequests<TRequest, TResponse>)
            .WithGroupName(endpointGroup);
    }

    private static async Task<IResult> HandleGetEndpointRequests<TRequest, TResponse>(ISender sender, 
        [AsParameters] TRequest request)
        where TRequest : IRequest<Result<TResponse, Error>>
    {
        var res = await sender.Send(request);

        return res.Match(value => Results.Ok(new ApiResponse<TResponse>(value)), HandleErrors);
    }

    private static async Task<IResult> HandlePostEndpointRequests<TRequest, TResponse>(ISender sender, TRequest request)
        where TRequest : IRequest<Result<TResponse, Error>>
    {
        var res = await sender.Send(request);

        return res.Match(value => Results.Ok(new ApiResponse<TResponse>(value)), HandleErrors);
    }

    private static async Task<IResult> HandleDeleteEndpointRequests<TRequest, TResponse>(ISender sender,
       [AsParameters] TRequest request)
       where TRequest : IRequest<Result<TResponse, Error>>
    {
        var res = await sender.Send(request);

        return res.Match(value => Results.NoContent(), HandleErrors);
    }

    private static IResult HandleErrors(Error error)
    {
        return error.Code switch
        {
            ApplicationStatusCodes.BAD_REQUEST => Results.BadRequest(new ApiResponse(error)),
            ApplicationStatusCodes.NOT_FOUND => Results.NotFound(new ApiResponse(error)),
            _ => Results.BadRequest(error)
        };
    }
}

