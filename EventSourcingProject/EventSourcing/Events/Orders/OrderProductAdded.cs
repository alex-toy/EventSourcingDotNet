namespace EventSourcing.Events.Orders;

public class OrderProductAdded : Event
{
    public required Guid OrderId { get; init; }
    public required string ProductName { get; set; }
    public required int Quantity { get; set; }

    public override Guid StreamId => OrderId;
}
