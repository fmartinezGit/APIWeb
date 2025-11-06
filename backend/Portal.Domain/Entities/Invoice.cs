namespace Portal.Domain.Entities;

public class Invoice
{
    public Guid Id { get; set; }
    public Guid SupplierId { get; set; }
    public string InvoiceNumber { get; set; } = string.Empty;
    public string PurchaseOrderNumber { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public DateTime InvoiceDate { get; set; }
    public InvoiceStatus Status { get; set; } = InvoiceStatus.PendingValidation;
    public ICollection<InvoiceLine> Lines { get; set; } = new List<InvoiceLine>();
    public string Currency { get; set; } = "USD";
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
}

public class InvoiceLine
{
    public Guid Id { get; set; }
    public string ItemNumber { get; set; } = string.Empty;
    public decimal Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}

public enum InvoiceStatus
{
    PendingValidation,
    Validated,
    Rejected,
    RegisteredInErp
}
