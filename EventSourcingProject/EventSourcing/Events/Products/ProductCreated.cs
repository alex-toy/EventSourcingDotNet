
namespace EventSourcing.Events.Products;

public class ProductCreated : Event
{
    public Guid ProductId { get; set; }

    public override Guid StreamId => ProductId;

    public string Label { get; set; }
}
