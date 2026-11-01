#nullable disable

namespace Lab_7.Legacy.Task2;

public enum LoanType
{
    Mortgage,
    ConsumerLoan,
    AutoLoan,
    StudentLoan
}

public class LoanApplicant
{
    public string ApplicantId { get; set; }
    public int CreditScore { get; set; } // Скоринговий бал 300-850
    public decimal MonthlyIncome { get; set; }
    public decimal RequestedAmount { get; set; }
}

public class LoanInterestCalculator
{
    public decimal CalculateInterestRate(LoanApplicant applicant, LoanType type)
    {
        decimal baseRate = 0m;

        switch (type)
        {
            case LoanType.Mortgage:
                // Іпотека: Базово 7.5%, скидка 1.0% якщо скоринг > 750, інакше надбавка 1.5%
                baseRate = 0.075m;
                if (applicant.CreditScore > 750)
                {
                    baseRate -= 0.010m;
                }
                else if (applicant.CreditScore < 650)
                {
                    baseRate += 0.015m;
                }
                break;

            case LoanType.ConsumerLoan:
                // Споживчий кредит: Базово 18.0%, скидка 2% для високого доходу ($3000+)
                baseRate = 0.180m;
                if (applicant.MonthlyIncome >= 3000m)
                {
                    baseRate -= 0.020m;
                }
                if (applicant.CreditScore < 600)
                {
                    baseRate += 0.040m;
                }
                break;

            case LoanType.AutoLoan:
                // Автокредит: Базово 11.0%, скидка 1.5% при скорингу 700+
                baseRate = 0.110m;
                if (applicant.CreditScore >= 700)
                {
                    baseRate -= 0.015m;
                }
                break;

            case LoanType.StudentLoan:
                // Студентський кредит: Фіксована соціальна ставка 4.5%
                baseRate = 0.045m;
                break;

            default:
                throw new ArgumentException($"Невідомий тип кредиту: {type}");
        }

        Console.WriteLine($"[LOAN] Заявка від {applicant.ApplicantId} (Скоринг: {applicant.CreditScore}): Продукт={type} -> Ставка: {baseRate * 100:F2}%");
        return baseRate;
    }
}