namespace Lab_7;

public class MortgageRateStrategy : ILoanRateStrategy
{
    public LoanType Type => LoanType.Mortgage;

    public decimal CalculateRate(LoanApplicant applicant) => applicant.CreditScore switch
    {
        > 750 => 0.075m - 0.010m,
        < 650 => 0.075m + 0.015m,
        _ => 0.075m
    };
}

public class ConsumerLoanRateStrategy : ILoanRateStrategy
{
    public LoanType Type => LoanType.ConsumerLoan;

    public decimal CalculateRate(LoanApplicant applicant)
    {
        decimal rate = 0.180m;
        if (applicant.MonthlyIncome >= 3000m) rate -= 0.020m;
        if (applicant.CreditScore < 600) rate += 0.040m;
        return rate;
    }
}

public class AutoLoanRateStrategy : ILoanRateStrategy
{
    public LoanType Type => LoanType.AutoLoan;

    public decimal CalculateRate(LoanApplicant applicant) =>
        applicant.CreditScore >= 700 ? 0.110m - 0.015m : 0.110m;
}

public class StudentLoanRateStrategy : ILoanRateStrategy
{
    public LoanType Type => LoanType.StudentLoan;

    public decimal CalculateRate(LoanApplicant applicant) => 0.045m;
}