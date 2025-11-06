namespace Portal.Domain.Entities;

public class Supplier
{
    public Guid Id { get; set; }
    public string TaxId { get; set; } = string.Empty;
    public string LegalName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public SupplierRiskProfile RiskProfile { get; set; } = new();
    public ICollection<Document> Documents { get; set; } = new List<Document>();
    public ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
}
