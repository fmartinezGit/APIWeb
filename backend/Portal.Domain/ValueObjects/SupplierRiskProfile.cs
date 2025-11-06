namespace Portal.Domain.ValueObjects;

public class SupplierRiskProfile
{
    public decimal RiskScore { get; set; }
    public string RiskLevel => RiskScore switch
    {
        >= 80 => "High",
        >= 50 => "Medium",
        _ => "Low"
    };
    public string? Notes { get; set; }
}
