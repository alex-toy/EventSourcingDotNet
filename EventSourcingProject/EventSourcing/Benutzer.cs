using EventSourcing.Databases;
using EventSourcing.Events.Orders;
using EventSourcing.Events.Products;
using EventSourcing.Events.Students;
using EventSourcing.Models;

namespace EventSourcing;

public static class Benutzer
{
    public static void ProductUser()
    {
        EntityDatabase<Product> productDatabase = new();

        Guid productId = Guid.NewGuid();

        ProductCreated event1 = new() { Label = "iphone", ProductId = productId, OccuredAt = DateTime.Now };
        ProductQuantityAdjusted event2 = new() { Reason = "count", ProductId = productId, Quantity = 50, OccuredAt = DateTime.Now };
        ProductReceived event3 = new() { ProductId = productId, Quantity = 15, OccuredAt = DateTime.Now };
        ProductShipped event4 = new() { ProductId = productId, Quantity = 35, OccuredAt = DateTime.Now };

        productDatabase.Append(event1);
        productDatabase.Append(event2);
        productDatabase.Append(event3);
        productDatabase.Append(event4);

        Product? product1 = productDatabase.Get(productId);

        Guid productId2 = Guid.NewGuid();

        ProductCreated event12 = new() { Label = "iphone", ProductId = productId2, OccuredAt = DateTime.Now };
        ProductQuantityAdjusted event22 = new() { Reason = "count", ProductId = productId2, Quantity = 85, OccuredAt = DateTime.Now };
        ProductReceived event32 = new() { ProductId = productId2, Quantity = 34, OccuredAt = DateTime.Now };
        ProductShipped event42 = new() { ProductId = productId2, Quantity = 32, OccuredAt = DateTime.Now };

        productDatabase.Append(event12);
        productDatabase.Append(event22);
        productDatabase.Append(event32);
        productDatabase.Append(event42);

        Product? product2 = productDatabase.Get(productId2);

        Console.ReadKey();
    }

    public static void OrderUser()
    {
        EntityDatabase<Order> _db = new();

        Guid orderId = Guid.NewGuid();

        OrderCreated orderCreated = new() { StudentName = "alex", OrderId = orderId, OccuredAt = DateTime.Now };
        OrderProductAdded orderProductAdded = new() { OrderId = orderId, ProductName = "shoes", Quantity = 2, OccuredAt = DateTime.Now };
        OrderProductRemoved orderProductRemoved = new() { OrderId = orderId, ProductName = "shoes", OccuredAt = DateTime.Now };
        OrderProductAdded orderProductAdded2 = new() { OrderId = orderId, ProductName = "pants", Quantity = 3, OccuredAt = DateTime.Now };
        OrderProductAdded orderProductAdded3 = new() { OrderId = orderId, ProductName = "iphone", Quantity = 4, OccuredAt = DateTime.Now };

        _db.Append(orderCreated);
        _db.Append(orderProductAdded);
        _db.Append(orderProductRemoved);
        _db.Append(orderProductAdded2);
        _db.Append(orderProductAdded3);

        Order? order = _db.Get(orderId);
    }

    public static void StudentUser()
    {
        EntityDatabase<Student> studentDatabase = new();

        Guid studentId = Guid.NewGuid();

        StudentCreated studentCreated = new() { DateOfBirth = new DateTime(1980, 12, 23), Email = "alex@test.fr", Name = "alex", StudentId = studentId, OccuredAt = DateTime.Now };
        StudentEnrolled studentEnrolled = new() { CourseName = "math", StudentId = studentId, OccuredAt = DateTime.Now };
        StudentUnenrolled studentunEnrolled = new() { CourseName = "math", StudentId = studentId, OccuredAt = DateTime.Now };
        StudentUpdated studentUpdated = new() { Name = "seb", Email = "seb@test.com", StudentId = studentId, OccuredAt = DateTime.Now };

        studentDatabase.Append(studentCreated);
        studentDatabase.Append(studentEnrolled);
        studentDatabase.Append(studentunEnrolled);
        studentDatabase.Append(studentUpdated);

        Guid studentId2 = Guid.NewGuid();

        StudentCreated studentCreated2 = new() { DateOfBirth = new DateTime(1980, 12, 23), Email = "matt@test.fr", Name = "matt", StudentId = studentId2, OccuredAt = DateTime.Now };
        StudentEnrolled studentEnrolled2 = new() { CourseName = "science", StudentId = studentId2, OccuredAt = DateTime.Now };
        StudentUpdated studentUpdated2 = new() { Name = "joe", Email = "joe@test.com", StudentId = studentId2, OccuredAt = DateTime.Now };

        studentDatabase.Append(studentCreated2);
        studentDatabase.Append(studentEnrolled2);
        studentDatabase.Append(studentUpdated2);

        Student? student = studentDatabase.Get(studentId);
        Student? student2 = studentDatabase.Get(studentId2);

        Console.ReadKey();
    }
}
