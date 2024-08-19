namespace EventSourcing.Events;

public abstract class Event
{
    public required DateTime OccuredAt {  get; set; }

    public abstract Guid StreamId { get; } 
}
