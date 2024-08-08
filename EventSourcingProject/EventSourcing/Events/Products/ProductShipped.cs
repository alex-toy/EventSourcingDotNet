namespace EventSourcing.Events.Products;

public class ProductShipped : Event
{
    public Guid ProductId { get; set; }

    public override Guid StreamId => ProductId;

    public int Quantity { get; set; }
}
