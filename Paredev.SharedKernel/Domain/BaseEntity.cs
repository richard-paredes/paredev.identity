namespace Paredev.SharedKernel.Domain;

public interface IEventEntity
{
    List<BaseDomainEvent> Events { get; }
}