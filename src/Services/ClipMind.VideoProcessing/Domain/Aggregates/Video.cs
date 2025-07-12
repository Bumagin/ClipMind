using BuildingBlocks.Common.Models;
using ClipMind.VideoProcessing.Domain.Enums;
using ClipMind.VideoProcessing.Domain.Events;

namespace ClipMind.VideoProcessing.Domain.Aggregates;

public class Video : Entity, IAggregateRoot
{
    public Video(string url)
    {
        Url = url;
        Status = VideoStatus.Processing;
    }
    
    public string Url { get; } 
    public string FilePath { get; private set; }
    public string? FailReason { get; private set; }
    public VideoStatus Status { get; private set; }

    public void CompleteProcessing(string filePath)
    {
        Status = VideoStatus.Completed;
        FilePath = filePath;
        RegisterDomainEvent(new VideoCompletedProcessingEvent());
    }

    public void FailProcessing(string reason)
    {
        FailReason = reason;
        Status = VideoStatus.Failed;
    }
}