namespace EventSourcing.Events.Products;

public class ProductReceived : Event
{
    public Guid ProductId { get; set; }

    public override Guid StreamId => ProductId;

    public int Quantity { get; set; }
}
