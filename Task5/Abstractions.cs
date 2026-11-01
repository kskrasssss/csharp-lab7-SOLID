namespace Lab_7;

public interface ICourseRepository
{
    void BookCourseSeat(string courseCode, string studentId);
}

public interface IInvoiceGenerator
{
    void GenerateRegistrationSlip(string studentId, string courseCode);
}

public interface IEmailGateway
{
    void SendOfficialMail(string email, string subject, string body);
}