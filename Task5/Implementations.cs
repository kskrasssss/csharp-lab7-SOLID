namespace Lab_7;

public class MariadbCourseRepository : ICourseRepository
{
    public void BookCourseSeat(string courseCode, string studentId) =>
        Console.WriteLine($"[MariaDB Storage] Студента {studentId} зараховано на курс '{courseCode}'. Кількість місць зменшено.");
}

public class PdfInvoiceGenerator : IInvoiceGenerator
{
    public void GenerateRegistrationSlip(string studentId, string courseCode) =>
        Console.WriteLine($"[PDF Engine] Згенеровано PDF-повідомлення 'registration_{studentId}_{courseCode}.pdf'.");
}

public class UniversityEmailGateway : IEmailGateway
{
    public void SendOfficialMail(string email, string subject, string body) =>
        Console.WriteLine($"[University Mail Gateway] Лист на {email} | Тема: '{subject}'.");
}