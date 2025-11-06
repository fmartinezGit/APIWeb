namespace Portal.Domain.Entities;

public class Document
{
    public Guid Id { get; set; }
    public Guid SupplierId { get; set; }
    public string FileName { get; set; } = string.Empty;
    public string BlobUri { get; set; } = string.Empty;
    public string DocumentType { get; set; } = string.Empty;
    public DocumentStatus Status { get; set; } = DocumentStatus.Pending;
    public string? ValidationSummary { get; set; }
    public DateTime UploadedOn { get; set; } = DateTime.UtcNow;
}

public enum DocumentStatus
{
    Pending,
    Validated,
    Rejected
}
