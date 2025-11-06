namespace Portal.Web.ViewModels;

public class InvoiceViewModel
{
    public Guid Id { get; set; }
    public Guid SupplierId { get; set; }
    public string InvoiceNumber { get; set; } = string.Empty;
    public string PurchaseOrderNumber { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public DateTime InvoiceDate { get; set; }
    public string Status { get; set; } = string.Empty;
}
