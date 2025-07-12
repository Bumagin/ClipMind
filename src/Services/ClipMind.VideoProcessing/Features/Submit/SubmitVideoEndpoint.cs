using BuildingBlocks.Common.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClipMind.VideoProcessing.Features.Submit;

public record SubmitVideoRequest(string VideoUrl);

public class SubmitVideoEndpoint : IEndpoint
{
    public void Register(IEndpointRouteBuilder app)
    {
        app.MapPost("api/video", async (
            [FromBody] SubmitVideoRequest request,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            if (string.IsNullOrEmpty(request.VideoUrl))
                return Results.BadRequest("Video URL is required");

            var processingId = await mediator.Send(new SubmitVideoCommand(request), cancellationToken);
            
            return Results.Ok(processingId);
        });
    }
}