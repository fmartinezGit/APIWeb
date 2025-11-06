using Portal.Domain.Entities;

namespace Portal.Infrastructure.Persistence;

public class InMemoryDataStore
{
    private readonly List<Supplier> _suppliers = new();
    private readonly List<Invoice> _invoices = new();

    public Task<Supplier> AddSupplierAsync(Supplier supplier, CancellationToken cancellationToken)
    {
        supplier.Id = Guid.NewGuid();
        _suppliers.Add(supplier);
        return Task.FromResult(supplier);
    }

    public Task<IEnumerable<Supplier>> GetSuppliersAsync(CancellationToken cancellationToken)
        => Task.FromResult(_suppliers.AsEnumerable());

    public Task<Supplier?> GetSupplierAsync(Guid id, CancellationToken cancellationToken)
        => Task.FromResult(_suppliers.FirstOrDefault(s => s.Id == id));

    public Task<Invoice> AddInvoiceAsync(Invoice invoice, CancellationToken cancellationToken)
    {
        invoice.Id = Guid.NewGuid();
        _invoices.Add(invoice);
        return Task.FromResult(invoice);
    }

    public Task<IEnumerable<Invoice>> GetInvoicesForSupplierAsync(Guid supplierId, CancellationToken cancellationToken)
        => Task.FromResult(_invoices.Where(i => i.SupplierId == supplierId));

    public Task<Invoice?> GetInvoiceAsync(Guid id, CancellationToken cancellationToken)
        => Task.FromResult(_invoices.FirstOrDefault(i => i.Id == id));
}
