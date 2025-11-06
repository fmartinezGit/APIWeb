namespace Portal.Web.ViewModels;

public class SupplierViewModel
{
    public Guid Id { get; set; }
    public string TaxId { get; set; } = string.Empty;
    public string LegalName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public decimal RiskScore { get; set; }
    public string RiskLevel { get; set; } = string.Empty;
}
