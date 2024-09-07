namespace EventSourcing.Events.Orders;

public class OrderCreated : Event
{
    public required Guid OrderId { get; init; }
    public required string StudentName { get; init; }

    public override Guid StreamId => OrderId;
}
