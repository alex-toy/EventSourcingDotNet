namespace EventSourcing.Events;

public abstract class Event
{
    public DateTime OccuredAt {  get; set; }

    public abstract Guid StreamId { get; } 
}
