namespace Lab_7;

// Нова стратегія: калькулятор НЕ змінюється, змінюється лише цей файл
public class BusinessLoanRateStrategy : ILoanRateStrategy
{
    public const LoanType BusinessType = (LoanType)100;
    public LoanType Type => BusinessType;

    public decimal CalculateRate(LoanApplicant applicant) =>
        applicant.MonthlyIncome >= 5000m ? 0.130m : 0.160m;
}

public static class Task2Demo
{
    public static void Run()
    {
        var calculator = new LoanInterestCalculator(new ILoanRateStrategy[]
        {
            new MortgageRateStrategy(),
            new ConsumerLoanRateStrategy(),
            new AutoLoanRateStrategy(),
            new StudentLoanRateStrategy(),
            new BusinessLoanRateStrategy()   // розширення без зміни калькулятора
        });

        var applicant = new LoanApplicant
        {
            ApplicantId = "A-001", CreditScore = 780, MonthlyIncome = 3500m, RequestedAmount = 50000m
        };

        foreach (LoanType type in Enum.GetValues<LoanType>())
            calculator.CalculateInterestRate(applicant, type);

        calculator.CalculateInterestRate(applicant, BusinessLoanRateStrategy.BusinessType);
    }
}