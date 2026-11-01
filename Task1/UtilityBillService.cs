namespace Lab_7;

public class UtilityBillService
{
    private readonly MeterReadingValidator _validator = new();
    private readonly TariffCalculator _tariff = new();
    private readonly SubsidyCalculator _subsidy = new();
    private readonly BillFormatter _formatter = new();
    private readonly PaymentRegistry _registry = new();
    private readonly SmsNotifier _sms = new();

    public void ProcessMonthlyBill(UtilityAccountData account)
    {
        int consumption = _validator.ValidateAndGetConsumption(account);
        decimal cost = _tariff.Calculate(consumption);
        decimal deduction = _subsidy.CalculateDeduction(account, cost);

        var bill = new BillResult(
            account.AccountNumber, account.OwnerName, consumption, cost,
            account.HasSubsidy, account.SubsidyDiscountPercent, deduction, cost - deduction);

        Console.WriteLine(_formatter.Format(bill));
        _registry.Save(bill);
        _sms.SendPaymentLink(account.OwnerPhone, account.AccountNumber, bill.TotalToPay);
    }
}

// тут оркестратор сам створює залежності через new. Це навмисно: порушення DIP в Завданні 1 не розглядається, а DIP показаний у Завданні 5. Якщо викладач спитає, відповідь: «Тут фокус на SRP, DIP демонструємо окремо в Завданні 5».