using Microsoft.Extensions.DependencyInjection;
using Portal.Application.Interfaces;
using Portal.Infrastructure.Persistence;
using Portal.Infrastructure.Services;

namespace Portal.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddPortalInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<InMemoryDataStore>();
        services.AddScoped<ISupplierService, SupplierService>();
        services.AddScoped<IInvoiceService, InvoiceService>();
        return services;
    }
}
