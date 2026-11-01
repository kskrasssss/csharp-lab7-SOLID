namespace Lab_7;

public class LoanApplicant
{
    public string ApplicantId { get; set; } = string.Empty;
    public int CreditScore { get; set; }
    public decimal MonthlyIncome { get; set; }
    public decimal RequestedAmount { get; set; }
}