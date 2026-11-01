namespace Lab_7;

public class CourseRegistrationService
{
    private readonly ICourseRepository _courseRepository;
    private readonly IInvoiceGenerator _invoiceGenerator;
    private readonly IEmailGateway _emailGateway;

    public CourseRegistrationService(
        ICourseRepository courseRepository,
        IInvoiceGenerator invoiceGenerator,
        IEmailGateway emailGateway)
    {
        _courseRepository = courseRepository ?? throw new ArgumentNullException(nameof(courseRepository));
        _invoiceGenerator = invoiceGenerator ?? throw new ArgumentNullException(nameof(invoiceGenerator));
        _emailGateway = emailGateway ?? throw new ArgumentNullException(nameof(emailGateway));
    }

    public void RegisterStudent(RegistrationRequest request)
    {
        if (request is null || string.IsNullOrEmpty(request.StudentId) || string.IsNullOrEmpty(request.CourseCode))
            throw new ArgumentException("Некоректна заявка на реєстрацію.");

        _courseRepository.BookCourseSeat(request.CourseCode, request.StudentId);
        _invoiceGenerator.GenerateRegistrationSlip(request.StudentId, request.CourseCode);
        _emailGateway.SendOfficialMail(
            request.StudentEmail,
            "Підтвердження реєстрації на курс",
            $"Вас успішно зараховано на курс {request.CourseCode}.");
    }
}