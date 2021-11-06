using MediatR;

namespace Paredev.SharedKernel.Domain;

public abstract class BaseDomainEvent : INotification
{
    public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
}