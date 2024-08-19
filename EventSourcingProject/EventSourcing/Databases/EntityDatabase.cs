using EventSourcing.Events;
using EventSourcing.Models;

namespace EventSourcing.Databases;

public class EntityDatabase<T> where T : Entity,  new()
{
    private readonly Dictionary<Guid, T> _entities = new();

    internal T? Get(Guid productId)
    {
        return _entities.GetValueOrDefault(productId, null);
    }

    public void Append(Event @event)
    {
        T? entity = _entities!.GetValueOrDefault(@event.StreamId, null);

        if (entity is null) _entities[@event.StreamId] = new T() { EntityId = @event.StreamId };

        _entities[@event.StreamId]!.ApplyChange(@event);
    }
}
