using EventSourcing.Events;
using EventSourcing.Events.Students;

namespace EventSourcing.Models;

public class Student
{
    public required Guid StudentId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime DateOfBirth { get; set; }
    public List<string> EnrolledCourses { get; set; } = new();

    public void Apply(Event @event)
    {
        switch (@event)
        {
            case StudentCreated studentCreated: Apply(studentCreated); break;
            case StudentUpdated studentUpdated: Apply(studentUpdated); break;
            case StudentEnrolled studentEnrolled: Apply(studentEnrolled); break;
            case StudentUnenrolled studentUnenrolled: Apply(studentUnenrolled); break;
        }
    }

    private void Apply(StudentCreated @event)
    {
        StudentId = @event.StudentId;
        Name = @event.Name;
        Email = @event.Email;
        DateOfBirth = @event.DateOfBirth;
    }

    private void Apply(StudentUpdated @event)
    {
        Name = @event.Name;
        Email = @event.Email;
    }

    private void Apply(StudentEnrolled @event)
    {
        if (!EnrolledCourses.Contains(@event.CourseName)) EnrolledCourses.Add(@event.CourseName);
    }

    private void Apply(StudentUnenrolled @event)
    {
        EnrolledCourses.Remove(@event.CourseName);
    }
}
