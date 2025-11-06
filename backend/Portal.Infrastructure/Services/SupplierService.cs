using Portal.Application.Interfaces;
using Portal.Domain.Entities;
using Portal.Infrastructure.Persistence;

namespace Portal.Infrastructure.Services;

public class SupplierService : ISupplierService
{
    private readonly InMemoryDataStore _dataStore;

    public SupplierService(InMemoryDataStore dataStore)
    {
        _dataStore = dataStore;
    }

    public Task<Supplier> RegisterSupplierAsync(Supplier supplier, CancellationToken cancellationToken = default)
    {
        supplier.RiskProfile.RiskScore = Random.Shared.Next(0, 100);
        return _dataStore.AddSupplierAsync(supplier, cancellationToken);
    }

    public Task<IEnumerable<Supplier>> GetSuppliersAsync(CancellationToken cancellationToken = default)
        => _dataStore.GetSuppliersAsync(cancellationToken);

    public Task<Supplier?> GetSupplierAsync(Guid id, CancellationToken cancellationToken = default)
        => _dataStore.GetSupplierAsync(id, cancellationToken);
}
