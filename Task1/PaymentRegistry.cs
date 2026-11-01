using System.Text;

namespace Lab_7;

public class PaymentRegistry
{
    private readonly string _filePath;

    public PaymentRegistry(string filePath = "utility_payments_db.csv")
    {
        _filePath = filePath;
    }

    public void Save(BillResult bill)
    {
        string line = $"{bill.AccountNumber};{bill.ConsumptionKwh};{bill.TotalToPay:F2};{DateTime.Now:yyyy-MM-dd}\n";
        File.AppendAllText(_filePath, line, Encoding.UTF8);
    }
}