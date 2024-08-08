using EventSourcing.Events;
using EventSourcing.Models;

namespace EventSourcing.Databases;

public class ProductDatabase
{
    private readonly Dictionary<Guid, IList<Event>> _productEvents = new();
    private readonly Dictionary<Guid, Product> _products = new();

    public Product? GetProductView(Guid studentId)
    {
        return _products.GetValueOrDefault(studentId);
    }

    internal Product? GetProduct(Guid productId)
    {
        if (!_productEvents.ContainsKey(productId)) return null;

        IList<Event>? events = _productEvents.GetValueOrDefault(productId);
        Product product = new() { ProductId = productId };

        if (events is null) return product;

        foreach (Event @event in events)
        {
            product.Apply(@event);
        }

        return product;
    }

    public void Append(Event @event)
    {
        var studentStream = _productEvents!.GetValueOrDefault(@event.StreamId, null);

        if (studentStream is null) _productEvents[@event.StreamId] = new List<Event>();

        _productEvents[@event.StreamId].Add(@event);

        Product? student = _products!.GetValueOrDefault(@event.StreamId, null);

        if (student is null) _products[@event.StreamId] = new Product() { ProductId = @event.StreamId };

        _products[@event.StreamId]!.Apply(@event);
    }
}
