namespace Lab_7;

public static class Task1Demo
{
    public static void Run()
    {
        var service = new UtilityBillService();

        var account = new UtilityAccountData
        {
            AccountNumber = "ACC-1001",
            OwnerName = "Іван Петренко",
            OwnerPhone = "+380501112233",
            PreviousElectricityMeterReading = 1000,
            CurrentElectricityMeterReading = 1250,
            HasSubsidy = true,
            SubsidyDiscountPercent = 20m
        };

        service.ProcessMonthlyBill(account);

        Console.WriteLine("\n--- Перевірка валідації (некоректний рахунок) ---");
        try
        {
            account.CurrentElectricityMeterReading = 900;
            service.ProcessMonthlyBill(account);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Очікувана помилка: {ex.Message}");
        }
    }
}