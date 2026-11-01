namespace Lab_7;

public class MeterReadingValidator
{
    public const int MaxConsumptionKwh = 5000;

    public int ValidateAndGetConsumption(UtilityAccountData account)
    {
        if (string.IsNullOrWhiteSpace(account.AccountNumber))
            throw new ArgumentException("Номер особового рахунку обов'язковий.");

        if (account.CurrentElectricityMeterReading < account.PreviousElectricityMeterReading)
            throw new InvalidOperationException("Поточні показники лічильника не можуть бути меншими за попередні.");

        int consumption = account.CurrentElectricityMeterReading - account.PreviousElectricityMeterReading;

        if (consumption > MaxConsumptionKwh)
            throw new ArgumentException("Аномально високе споживання електроенергії. Потрібна перевірка інспектора.");

        return consumption;
    }
}