using EventSourcing.Events.Products;

namespace EventSourcing.Models;

public class Product : Entity
{
    public string? Label { get; set; }
    public int QuantityOnHand { get; set; }

    public void Apply(ProductCreated @event)
    {
        if (@event.Label == string.Empty) throw new InvalidDataException("Product should have a label");
        Label = @event.Label;
        QuantityOnHand = 0;
    }

    public void Apply(ProductShipped @event)
    {
        if (@event.Quantity > QuantityOnHand) throw new InvalidDataException("insufficient quantity on stock");
        QuantityOnHand -= @event.Quantity;
    }

    public void Apply(ProductReceived @event)
    {
        QuantityOnHand += @event.Quantity;
    }

    public void Apply(ProductQuantityAdjusted @event)
    {
        if (QuantityOnHand + @event.Quantity < 0) throw new InvalidDataException("negative quantity");
        QuantityOnHand += @event.Quantity;
    }
}
