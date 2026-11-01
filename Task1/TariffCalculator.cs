namespace Lab_7;

public class TariffCalculator
{
    private const int PreferentialLimitKwh = 100;
    private const decimal LowRate = 2.64m;
    private const decimal HighRate = 4.32m;

    public decimal Calculate(int consumptionKwh)
    {
        if (consumptionKwh <= PreferentialLimitKwh)
            return consumptionKwh * LowRate;

        return PreferentialLimitKwh * LowRate
             + (consumptionKwh - PreferentialLimitKwh) * HighRate;
    }
}