using Portal.Domain.Entities;
using Portal.Infrastructure.Persistence;
using Portal.Infrastructure.Services;
using Xunit;

namespace Portal.Tests;

public class InvoiceServiceTests
{
    [Fact]
    public async Task SubmitInvoiceAsync_AssignsIdentifierAndPendingStatus()
    {
        var dataStore = new InMemoryDataStore();
        var service = new InvoiceService(dataStore);
        var invoice = new Invoice
        {
            SupplierId = Guid.NewGuid(),
            InvoiceNumber = "FAC-001",
            Amount = 1250.50m,
            Currency = "GTQ"
        };

        var submitted = await service.SubmitInvoiceAsync(invoice);

        Assert.NotEqual(Guid.Empty, submitted.Id);
        Assert.Equal(InvoiceStatus.PendingValidation, submitted.Status);
        Assert.Equal("FAC-001", submitted.InvoiceNumber);
    }

    [Fact]
    public async Task GetInvoicesForSupplierAsync_ReturnsInvoicesForRequestedSupplier()
    {
        var dataStore = new InMemoryDataStore();
        var service = new InvoiceService(dataStore);
        var supplierA = Guid.NewGuid();
        var supplierB = Guid.NewGuid();

        await service.SubmitInvoiceAsync(new Invoice { SupplierId = supplierA, InvoiceNumber = "A-1" });
        await service.SubmitInvoiceAsync(new Invoice { SupplierId = supplierB, InvoiceNumber = "B-1" });
        await service.SubmitInvoiceAsync(new Invoice { SupplierId = supplierA, InvoiceNumber = "A-2" });

        var supplierAInvoices = await service.GetInvoicesForSupplierAsync(supplierA);

        Assert.Collection(supplierAInvoices,
            first => Assert.Equal("A-1", first.InvoiceNumber),
            second => Assert.Equal("A-2", second.InvoiceNumber));
    }
}
