#nullable disable

namespace Lab_7.Legacy.Task5;

public class RegistrationRequest
{
    public string StudentId { get; set; }
    public string StudentEmail { get; set; }
    public string CourseCode { get; set; }
}

public class MariadbCourseRepository
{
    public void BookCourseSeat(string courseCode, string studentId)
    {
        Console.WriteLine($"[MariaDB Storage] Студента {studentId} зараховано на курс '{courseCode}'. Кількість місць зменшено.");
    }
}

public class PdfInvoiceGenerator
{
    public void GenerateRegistrationSlip(string studentId, string courseCode)
    {
        Console.WriteLine($"[PDF Engine] Згенеровано PDF-повідомлення 'registration_{studentId}_{courseCode}.pdf'.");
    }
}

public class UniversityEmailGateway
{
    public void SendOfficialMail(string email, string subject, string body)
    {
        Console.WriteLine($"[University Mail Gateway] Лист на {email} | Тема: '{subject}'.");
    }
}

public class CourseRegistrationService
{
    private readonly MariadbCourseRepository _courseRepository;
    private readonly PdfInvoiceGenerator _pdfGenerator;
    private readonly UniversityEmailGateway _emailGateway;

    public CourseRegistrationService()
    {
        _courseRepository = new MariadbCourseRepository();
        _pdfGenerator = new PdfInvoiceGenerator();
        _emailGateway = new UniversityEmailGateway();
    }

    public void RegisterStudent(RegistrationRequest request)
    {
        if (request == null || string.IsNullOrEmpty(request.StudentId) || string.IsNullOrEmpty(request.CourseCode))
        {
            throw new ArgumentException("Некоректна заявка на реєстрацію.");
        }

        _courseRepository.BookCourseSeat(request.CourseCode, request.StudentId);
        _pdfGenerator.GenerateRegistrationSlip(request.StudentId, request.CourseCode);
        _emailGateway.SendOfficialMail(request.StudentEmail, "Підтвердження реєстрації на курс", $"Вас успішно зараховано на курс {request.CourseCode}.");
    }
}