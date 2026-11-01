namespace Lab_7;

public class SubsidyCalculator
{
    public decimal CalculateDeduction(UtilityAccountData account, decimal cost)
    {
        if (!account.HasSubsidy || account.SubsidyDiscountPercent <= 0)
            return 0m;

        return cost * (account.SubsidyDiscountPercent / 100m);
    }
}