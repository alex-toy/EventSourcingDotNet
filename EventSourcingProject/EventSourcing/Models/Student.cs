using EventSourcing.Events.Students;

namespace EventSourcing.Models;

public class Student : Entity
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public DateTime DateOfBirth { get; set; }
    public List<string> EnrolledCourses { get; set; } = new();

    public void Apply(StudentCreated @event)
    {
        EntityId = @event.StudentId;
        Name = @event.Name;
        Email = @event.Email;
        DateOfBirth = @event.DateOfBirth;
    }

    public void Apply(StudentUpdated @event)
    {
        Name = @event.Name;
        Email = @event.Email;
    }

    public void Apply(StudentEnrolled @event)
    {
        if (!EnrolledCourses.Contains(@event.CourseName)) EnrolledCourses.Add(@event.CourseName);
    }

    public void Apply(StudentUnenrolled @event)
    {
        EnrolledCourses.Remove(@event.CourseName);
    }
}
