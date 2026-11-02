#nullable disable
using System.Text;

namespace Lab_7.Legacy.Task1;
public class UtilityAccountData
{
    public string AccountNumber { get; set; }
    public string OwnerName { get; set; }
    public string OwnerPhone { get; set; }
    public int PreviousElectricityMeterReading { get; set; }
    public int CurrentElectricityMeterReading { get; set; }
    public bool HasSubsidy { get; set; }
    public decimal SubsidyDiscountPercent { get; set; }
}

public class UtilityBillCalculator
{
    public void ProcessMonthlyBill(UtilityAccountData account)
    {
        // 1. Валідація показників приладів обліку
        // валідація
        if (string.IsNullOrWhiteSpace(account.AccountNumber))
        {
            throw new ArgumentException("Номер особового рахунку обов'язковий.");
        }

        if (account.CurrentElectricityMeterReading < account.PreviousElectricityMeterReading)
        {
            throw new InvalidOperationException("Поточні показники лічильника не можуть бути меншими за попередні.");
        }

        int consumptionKwh = account.CurrentElectricityMeterReading - account.PreviousElectricityMeterReading;

        if (consumptionKwh > 5000)
        {
            throw new ArgumentException("Аномально високе споживання електроенергії. Потрібна перевірка інспектора.");
        }

        // 2. Розрахунок тарифа та обчислення субсидії
        decimal cost = 0;
        if (consumptionKwh <= 100)
        {
            cost = consumptionKwh * 2.64m;
        }
        else
        {
            cost = (100 * 2.64m) + ((consumptionKwh - 100) * 4.32m);
        }

        decimal subsidyDeduction = 0;
        if (account.HasSubsidy && account.SubsidyDiscountPercent > 0)
        {
            subsidyDeduction = cost * (account.SubsidyDiscountPercent / 100.0m);
        }

        decimal totalToPay = cost - subsidyDeduction;

        // 3. Платіжна квитанції
        var billInvoice = new StringBuilder();
        billInvoice.AppendLine("==================================================");
        billInvoice.AppendLine("КВИТАНЦІЯ ПРО ОПЛАТУ КОМУНАЛЬНИХ ПОСЛУГ");
        billInvoice.AppendLine($"Особовий рахунок: {account.AccountNumber} | ПІБ: {account.OwnerName}");
        billInvoice.AppendLine($"Спожито електроенергії: {consumptionKwh} кВт*год");
        billInvoice.AppendLine($"Нараховано за тарифом: {cost:F2} грн");
        if (account.HasSubsidy)
        {
            billInvoice.AppendLine($"Субсидія/Пільга ({account.SubsidyDiscountPercent}%): -{subsidyDeduction:F2} грн");
        }
        billInvoice.AppendLine($"ДО СПЛАТИ: {totalToPay:F2} грн");
        billInvoice.AppendLine("==================================================");

        // 4. Запис у SCV
        string logLine = $"{account.AccountNumber};{consumptionKwh};{totalToPay:F2};{DateTime.Now:yyyy-MM-dd}\n";
        File.AppendAllText("utility_payments_db.csv", logLine, Encoding.UTF8);

        // 5. Відправка SMS з посиланням на онлайн-оплату
        try
        {
            using (var client = new HttpClient())
            {
                string paymentUrl = $"http://pay.utility.local/bill?acc={account.AccountNumber}&sum={totalToPay:F2}";
                string smsContent = $"Рахунок за комунальні послуги: {totalToPay:F2} грн. Оплата онлайн: {paymentUrl}";

                var values = new[]
                {
                    new KeyValuePair<string, string>("to", account.OwnerPhone),
                    new KeyValuePair<string, string>("message", smsContent)
                };

                client.PostAsync("http://sms-gateway.local/send", new FormUrlEncodedContent(values)).Wait();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка відправки SMS-посилання: {ex.Message}");
        }
    }
}