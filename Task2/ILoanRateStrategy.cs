namespace Lab_7;

public interface ILoanRateStrategy
{
    LoanType Type { get; }
    decimal CalculateRate(LoanApplicant applicant);
}