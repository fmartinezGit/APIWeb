using Portal.Domain.Entities;

namespace Portal.Application.Interfaces;

public interface ISupplierService
{
    Task<Supplier> RegisterSupplierAsync(Supplier supplier, CancellationToken cancellationToken = default);
    Task<IEnumerable<Supplier>> GetSuppliersAsync(CancellationToken cancellationToken = default);
    Task<Supplier?> GetSupplierAsync(Guid id, CancellationToken cancellationToken = default);
}
