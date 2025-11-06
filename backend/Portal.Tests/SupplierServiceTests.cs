using Portal.Domain.Entities;
using Portal.Infrastructure.Persistence;
using Portal.Infrastructure.Services;
using Xunit;

namespace Portal.Tests;

public class SupplierServiceTests
{
    [Fact]
    public async Task RegisterSupplierAsync_AssignsIdentifierAndRiskScore()
    {
        var dataStore = new InMemoryDataStore();
        var service = new SupplierService(dataStore);
        var supplier = new Supplier
        {
            TaxId = "1234567-8",
            LegalName = "Proveedor Demo",
            Email = "proveedor@example.com",
            Phone = "+50212345678"
        };

        var registered = await service.RegisterSupplierAsync(supplier);

        Assert.NotEqual(Guid.Empty, registered.Id);
        Assert.InRange(registered.RiskProfile.RiskScore, 0, 99);
        Assert.Equal("Proveedor Demo", registered.LegalName);
    }

    [Fact]
    public async Task GetSuppliersAsync_ReturnsRegisteredSuppliers()
    {
        var dataStore = new InMemoryDataStore();
        var service = new SupplierService(dataStore);

        await service.RegisterSupplierAsync(new Supplier { TaxId = "1", LegalName = "A" });
        await service.RegisterSupplierAsync(new Supplier { TaxId = "2", LegalName = "B" });

        var suppliers = await service.GetSuppliersAsync();

        Assert.Collection(suppliers,
            first => Assert.Equal("A", first.LegalName),
            second => Assert.Equal("B", second.LegalName));
    }
}
