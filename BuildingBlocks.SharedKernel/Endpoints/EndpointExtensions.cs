using System.Reflection;
using Microsoft.AspNetCore.Routing;

namespace BuildingBlocks.Common.Endpoints;

public static class EndpointExtensions
{
    public static IEndpointRouteBuilder RegisterEndpoints(this IEndpointRouteBuilder endpoints, Assembly assembly)
    {
        var endpointTypes = assembly
            .GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract && typeof(IEndpoint).IsAssignableFrom(t));
        
        foreach (var type in endpointTypes)
        {
            var endpoint = (IEndpoint)Activator.CreateInstance(type)!;
            endpoint.Register(endpoints);
        }
        
        return endpoints;
    }
}