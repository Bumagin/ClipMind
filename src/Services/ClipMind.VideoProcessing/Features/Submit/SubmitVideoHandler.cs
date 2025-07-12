using MediatR;

namespace ClipMind.VideoProcessing.Features.Submit;

public record SubmitVideoCommand(SubmitVideoEndpoint.SubmitVideoRequest Request) :  IRequest<Guid>;

public class SubmitVideoHandler :  IRequestHandler<SubmitVideoCommand, Guid>
{
    public Task<Guid> Handle(SubmitVideoCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}