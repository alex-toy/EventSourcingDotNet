namespace EventSourcing.Events;

public interface IEvents
{
    Guid StreamId { get; }
    DateTime OccuredAt { get; }
}
