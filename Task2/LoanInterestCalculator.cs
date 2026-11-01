namespace Lab_7;

public class LoanInterestCalculator
{
    private readonly Dictionary<LoanType, ILoanRateStrategy> _strategies;

    public LoanInterestCalculator(IEnumerable<ILoanRateStrategy> strategies)
    {
        _strategies = strategies.ToDictionary(s => s.Type);
    }

    public decimal CalculateInterestRate(LoanApplicant applicant, LoanType type)
    {
        if (!_strategies.TryGetValue(type, out var strategy))
            throw new ArgumentException($"Невідомий тип кредиту: {type}");

        decimal rate = strategy.CalculateRate(applicant);

        Console.WriteLine($"[LOAN] Заявка від {applicant.ApplicantId} (Скоринг: {applicant.CreditScore}): Продукт={type} -> Ставка: {rate * 100:F2}%");
        return rate;
    }
}