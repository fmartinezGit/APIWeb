using Portal.Application.Interfaces;
using Portal.Domain.Entities;
using Portal.Infrastructure.Persistence;

namespace Portal.Infrastructure.Services;

public class InvoiceService : IInvoiceService
{
    private readonly InMemoryDataStore _dataStore;

    public InvoiceService(InMemoryDataStore dataStore)
    {
        _dataStore = dataStore;
    }

    public Task<Invoice> SubmitInvoiceAsync(Invoice invoice, CancellationToken cancellationToken = default)
    {
        invoice.Status = InvoiceStatus.PendingValidation;
        return _dataStore.AddInvoiceAsync(invoice, cancellationToken);
    }

    public Task<IEnumerable<Invoice>> GetInvoicesForSupplierAsync(Guid supplierId, CancellationToken cancellationToken = default)
        => _dataStore.GetInvoicesForSupplierAsync(supplierId, cancellationToken);

    public Task<Invoice?> GetInvoiceAsync(Guid id, CancellationToken cancellationToken = default)
        => _dataStore.GetInvoiceAsync(id, cancellationToken);
}
