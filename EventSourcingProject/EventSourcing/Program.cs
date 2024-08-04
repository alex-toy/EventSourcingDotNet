using EventSourcing;
using EventSourcing.Events;
using EventSourcing.Models;

StudentDatabase studentDatabase = new ();

Guid studentId = Guid.NewGuid();

StudentCreated studentCreated = new() { DateOfBirth = new DateTime(1980, 12, 23), Email = "alex@test.fr", Name = "alex", StudentId = studentId };
StudentEnrolled studentEnrolled = new() { CourseName = "math", StudentId = studentId };
StudentUnenrolled studentunEnrolled = new() { CourseName = "math", StudentId = studentId };
StudentUpdated studentUpdated = new() { Name = "seb", Email = "seb@test.com", StudentId = studentId };

studentDatabase.Append(studentCreated);
studentDatabase.Append(studentEnrolled);
studentDatabase.Append(studentunEnrolled);
studentDatabase.Append(studentUpdated);

Guid studentId2 = Guid.NewGuid();

StudentCreated studentCreated2 = new() { DateOfBirth = new DateTime(1980, 12, 23), Email = "matt@test.fr", Name = "matt", StudentId = studentId2 };
StudentEnrolled studentEnrolled2 = new() { CourseName = "science", StudentId = studentId2 };
StudentUpdated studentUpdated2 = new() { Name = "joe", Email = "joe@test.com", StudentId = studentId2 };

studentDatabase.Append(studentCreated2);
studentDatabase.Append(studentEnrolled2);
studentDatabase.Append(studentUpdated2);

Student? student = studentDatabase.GetStudent(studentId);
Student? studentView = studentDatabase.GetStudentView(studentId);
Student? student2 = studentDatabase.GetStudent(studentId2);
Student? student2View = studentDatabase.GetStudentView(studentId2);


Console.ReadKey();