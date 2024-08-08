using EventSourcing.Events;
using EventSourcing.Events.Products;
using System.Reflection.Emit;

namespace EventSourcing.Models;

public class Product
{
    public required Guid ProductId { get; set; }
    public string Label { get; set; }
    public int QuantityOnHand { get; set; }

    private readonly IList<Event> _events = new List<Event>();

    public void Apply(Event @event)
    {
        switch (@event)
        {
            case ProductCreated productCreated: Apply(productCreated); break;
            case ProductQuantityAdjusted productQuantityAdjusted: Apply(productQuantityAdjusted); break;
            case ProductShipped productShipped: Apply(productShipped); break;
            case ProductReceived productReceived: Apply(productReceived); break;
            default: throw new InvalidOperationException("unsupported event");
        }
    }

    private void Apply(ProductCreated @event)
    {
        if (@event.Label == string.Empty) throw new InvalidDataException("Product should have a label");
        Label = @event.Label;
        QuantityOnHand = 0;
        _events.Add(@event);
    }

    private void Apply(ProductShipped @event)
    {
        if (@event.Quantity > QuantityOnHand) throw new InvalidDataException("insufficient quantity on stock");
        QuantityOnHand -= @event.Quantity;
        _events.Add(@event);
    }

    private void Apply(ProductReceived @event)
    {
        QuantityOnHand += @event.Quantity;
        _events.Add(@event);
    }

    private void Apply(ProductQuantityAdjusted @event)
    {
        if (QuantityOnHand + @event.Quantity < 0) throw new InvalidDataException("negative quantity");
        QuantityOnHand += @event.Quantity;
        _events.Add(@event);
    }
}
