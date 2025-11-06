using Portal.Domain.Entities;

namespace Portal.Application.Interfaces;

public interface IInvoiceService
{
    Task<Invoice> SubmitInvoiceAsync(Invoice invoice, CancellationToken cancellationToken = default);
    Task<IEnumerable<Invoice>> GetInvoicesForSupplierAsync(Guid supplierId, CancellationToken cancellationToken = default);
    Task<Invoice?> GetInvoiceAsync(Guid id, CancellationToken cancellationToken = default);
}
