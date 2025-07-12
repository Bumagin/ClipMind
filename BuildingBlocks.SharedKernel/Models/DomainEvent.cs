using MediatR;

namespace BuildingBlocks.Common.Models;

public abstract class DomainEvent : INotification
{
    public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
}