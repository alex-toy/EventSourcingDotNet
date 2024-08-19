using EventSourcing.Events;
using System.Reflection;

namespace EventSourcing.Models;

public abstract class Entity
{
    public Guid EntityId { get; set; }

    protected IList<Event> _events = new List<Event>();

    public void ApplyChange(Event @event)
    {
        MethodInfo? method = GetType().GetMethod("Apply", new Type[] { @event.GetType() });

        if (method is null)
        {
            throw new ArgumentNullException(nameof(method), $"The Apply method was not found in the aggregate for {@event.GetType().Name}!");
        }

        method.Invoke(this, new object[] { @event });

        _events.Add(@event);
    }
}
