namespace Lab_7;

public static class Task5Demo
{
    public static void Run()
    {
        var request = new RegistrationRequest
        {
            StudentId = "S-42", StudentEmail = "student@univ.edu", CourseCode = "CS-101"
        };

        Console.WriteLine("--- Production-збірка ---");
        var production = new CourseRegistrationService(
            new MariadbCourseRepository(),
            new PdfInvoiceGenerator(),
            new UniversityEmailGateway());
        production.RegisterStudent(request);

        Console.WriteLine("\n--- Mock-збірка (підміна реалізацій) ---");
        var mockRepo = new InMemoryCourseRepository();
        var mock = new CourseRegistrationService(
            mockRepo,
            new NullInvoiceGenerator(),
            new ConsoleEmailGateway());
        mock.RegisterStudent(request);

        Console.WriteLine($"Бронювань у mock-репозиторії: {mockRepo.Bookings.Count}");
    }
}