using IMS.API.Abstractions;
using System.Reflection;

namespace IMS.API.Extensions;

public static class EndpointExtensions
{
    public static void RegisterEndpoints(this WebApplication app)
    {
        var endpoints = Assembly.GetExecutingAssembly()
            .GetExportedTypes()
            .Where(x => x.IsAssignableTo(typeof(IEndpointRegistration)) && !x.IsAbstract && !x.IsInterface)
            .Select(Activator.CreateInstance)
            .Cast<IEndpointRegistration>()
            .ToList();

        foreach (var endpoint in endpoints)
            endpoint.RegisterEndpoint(app);
    }
}
