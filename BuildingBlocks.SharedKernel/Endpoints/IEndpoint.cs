using Microsoft.AspNetCore.Routing;

namespace BuildingBlocks.Common.Endpoints;

public interface IEndpoint
{
    void Register(IEndpointRouteBuilder endpointsBuilder);
}