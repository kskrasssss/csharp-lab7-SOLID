namespace Lab_7;

public class InMemoryCourseRepository : ICourseRepository
{
    public List<(string Course, string Student)> Bookings { get; } = new();

    public void BookCourseSeat(string courseCode, string studentId)
    {
        Bookings.Add((courseCode, studentId));
        Console.WriteLine($"[InMemory] Бронювання збережено в пам'яті: {studentId} -> {courseCode}");
    }
}

public class NullInvoiceGenerator : IInvoiceGenerator
{
    public void GenerateRegistrationSlip(string studentId, string courseCode) { }
}

public class ConsoleEmailGateway : IEmailGateway
{
    public void SendOfficialMail(string email, string subject, string body) =>
        Console.WriteLine($"[MockMail] -> {email}: {subject}");
}