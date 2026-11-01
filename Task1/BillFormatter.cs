using System.Text;

namespace Lab_7;

public class BillFormatter
{
    private const string Line = "==================================================";

    public string Format(BillResult bill)
    {
        var sb = new StringBuilder();
        sb.AppendLine(Line);
        sb.AppendLine("КВИТАНЦІЯ ПРО ОПЛАТУ КОМУНАЛЬНИХ ПОСЛУГ");
        sb.AppendLine($"Особовий рахунок: {bill.AccountNumber} | ПІБ: {bill.OwnerName}");
        sb.AppendLine($"Спожито електроенергії: {bill.ConsumptionKwh} кВт*год");
        sb.AppendLine($"Нараховано за тарифом: {bill.Cost:F2} грн");
        if (bill.HasSubsidy)
            sb.AppendLine($"Субсидія/Пільга ({bill.SubsidyPercent}%): -{bill.SubsidyDeduction:F2} грн");
        sb.AppendLine($"ДО СПЛАТИ: {bill.TotalToPay:F2} грн");
        sb.AppendLine(Line);
        return sb.ToString();
    }
}
