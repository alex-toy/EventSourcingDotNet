using EventSourcing.Events;
using EventSourcing.Models;

namespace EventSourcing.Databases;

public class StudentDatabase
{
    private readonly Dictionary<Guid, SortedList<DateTime, Event>> _studentEvents = new();
    private readonly Dictionary<Guid, Student> _students = new();

    public Student? GetStudentView(Guid studentId)
    {
        return _students.GetValueOrDefault(studentId);
    }

    internal Student? GetStudent(Guid studentId)
    {
        if (!_studentEvents.ContainsKey(studentId)) return null;

        SortedList<DateTime, Event>? events = _studentEvents.GetValueOrDefault(studentId);
        Student student = new() { StudentId = studentId };

        if (events is null) return student;

        foreach (KeyValuePair<DateTime, Event> entry in events)
        {
            student.Apply(entry.Value);
        }

        return student;
    }

    public void Append(Event @event)
    {
        var studentStream = _studentEvents!.GetValueOrDefault(@event.StreamId, null);

        if (studentStream is null)
        {
            _studentEvents[@event.StreamId] = new SortedList<DateTime, Event>();
        }

        @event.OccuredAt = DateTime.UtcNow;

        _studentEvents[@event.StreamId].Add(@event.OccuredAt, @event);

        Student? student = _students!.GetValueOrDefault(@event.StreamId, null);

        if (student is null) _students[@event.StreamId] = new Student() { StudentId = @event.StreamId };

        _students[@event.StreamId]!.Apply(@event);
    }
}
