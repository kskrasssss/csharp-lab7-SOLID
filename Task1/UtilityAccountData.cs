namespace Lab_7;

public class UtilityAccountData
{
    public string AccountNumber { get; set; } = string.Empty;
    public string OwnerName { get; set; } = string.Empty;
    public string OwnerPhone { get; set; } = string.Empty;
    public int PreviousElectricityMeterReading { get; set; }
    public int CurrentElectricityMeterReading { get; set; }
    public bool HasSubsidy { get; set; }
    public decimal SubsidyDiscountPercent { get; set; }
}