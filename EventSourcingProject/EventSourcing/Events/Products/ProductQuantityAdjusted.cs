namespace EventSourcing.Events.Products;

public class ProductQuantityAdjusted : Event
{
    public Guid ProductId { get; set; }

    public override Guid StreamId => ProductId;

    public string Reason { get; set; }

    public int Quantity { get; set; }
}
