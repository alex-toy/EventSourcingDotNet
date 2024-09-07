namespace EventSourcing.Events.Orders;

public class OrderProductRemoved : Event
{
    public required Guid OrderId { get; init; }
    public required string ProductName { get; init; }

    public override Guid StreamId => OrderId;
}
