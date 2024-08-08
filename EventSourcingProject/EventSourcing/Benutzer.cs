using EventSourcing.Databases;
using EventSourcing.Events.Products;
using EventSourcing.Events.Students;
using EventSourcing.Models;

namespace EventSourcing;

public static class Benutzer
{
    public static void ProductUser()
    {
        ProductDatabase productDatabase = new();

        Guid productId = Guid.NewGuid();

        ProductCreated event1 = new() { Label = "iphone", ProductId = productId };
        ProductQuantityAdjusted event2 = new() { Reason = "count", ProductId = productId, Quantity = 10, OccuredAt = DateTime.Now };
        ProductReceived event3 = new() { ProductId = productId, Quantity = 10, OccuredAt = DateTime.Now };
        ProductShipped event4 = new() { ProductId = productId, Quantity = 10, OccuredAt = DateTime.Now };

        productDatabase.Append(event1);
        productDatabase.Append(event2);
        productDatabase.Append(event3);
        productDatabase.Append(event4);

        Guid productId2 = Guid.NewGuid();

        ProductCreated event12 = new() { Label = "iphone", ProductId = productId2 };
        ProductQuantityAdjusted event22 = new() { Reason = "count", ProductId = productId2, Quantity = 10, OccuredAt = DateTime.Now };
        ProductReceived event32 = new() { ProductId = productId2, Quantity = 10, OccuredAt = DateTime.Now };
        ProductShipped event42 = new() { ProductId = productId2, Quantity = 10, OccuredAt = DateTime.Now };

        productDatabase.Append(event12);
        productDatabase.Append(event22);
        productDatabase.Append(event32);
        productDatabase.Append(event42);

        Product? produc2t = productDatabase.GetProduct(productId2);
        Product? productView2 = productDatabase.GetProductView(productId2);

        Console.ReadKey();
    }

    public static void StudentUser()
    {
        StudentDatabase studentDatabase = new();

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
    }
}
