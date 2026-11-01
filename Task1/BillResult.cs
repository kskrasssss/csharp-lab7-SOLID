namespace Lab_7;

public record BillResult(
    string AccountNumber,
    string OwnerName,
    int ConsumptionKwh,
    decimal Cost,
    bool HasSubsidy,
    decimal SubsidyPercent,
    decimal SubsidyDeduction,
    decimal TotalToPay);