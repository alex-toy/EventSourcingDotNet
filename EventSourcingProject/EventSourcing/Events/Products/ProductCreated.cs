
namespace EventSourcing.Events.Products;

internal class ProductCreated : Event
{
    public Guid ProductId { get; set; }

    public override Guid StreamId => ProductId;

    public string Label { get; set; }
}
