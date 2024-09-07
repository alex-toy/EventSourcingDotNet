using EventSourcing.Events.Orders;

namespace EventSourcing.Models;

public class Order : Entity
{
    public string StudentName { get; set; } = string.Empty;
    public Dictionary<string, int> ProductsOrdered { get; set; } = new Dictionary<string, int>();

    public void Apply(OrderCreated @event)
    {
        EntityId = @event.OrderId;
        StudentName = @event.StudentName;
        // Add check for student existence
    }

    public void Apply(OrderProductAdded @event)
    {
        ProductsOrdered.Add(@event.ProductName, @event.Quantity);
        //Add check for product existence
    }

    public void Apply(OrderProductRemoved @event)
    {
        ProductsOrdered.Remove(@event.ProductName);
    }
}
