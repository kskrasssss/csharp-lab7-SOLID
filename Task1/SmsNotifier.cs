namespace Lab_7;

public class SmsNotifier
{
    private const string GatewayUrl = "http://sms-gateway.local/send";

    public void SendPaymentLink(string phone, string accountNumber, decimal totalToPay)
    {
        try
        {
            using var client = new HttpClient { Timeout = TimeSpan.FromSeconds(3) };

            string paymentUrl = $"http://pay.utility.local/bill?acc={accountNumber}&sum={totalToPay:F2}";
            string message = $"Рахунок за комунальні послуги: {totalToPay:F2} грн. Оплата онлайн: {paymentUrl}";

            var values = new[]
            {
                new KeyValuePair<string, string>("to", phone),
                new KeyValuePair<string, string>("message", message)
            };

            client.PostAsync(GatewayUrl, new FormUrlEncodedContent(values)).Wait();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка відправки SMS-посилання: {ex.GetBaseException().Message}");
        }
    }
}