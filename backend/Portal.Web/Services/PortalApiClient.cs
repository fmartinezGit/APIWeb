using System.Net.Http.Headers;
using System.Net.Http.Json;
using Portal.Web.ViewModels;

namespace Portal.Web.Services;

public class PortalApiClient
{
    private readonly HttpClient _httpClient;

    public PortalApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress ??= new Uri("https://localhost:5001/");
    }

    public async Task<IReadOnlyList<SupplierViewModel>> GetSuppliersAsync()
    {
        var result = await _httpClient.GetFromJsonAsync<List<SupplierViewModel>>("api/suppliers");
        return result ?? new List<SupplierViewModel>();
    }

    public async Task<SupplierViewModel?> RegisterSupplierAsync(SupplierViewModel supplier)
    {
        var response = await _httpClient.PostAsJsonAsync("api/suppliers", supplier);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<SupplierViewModel>();
    }

    public async Task<IReadOnlyList<InvoiceViewModel>> GetInvoicesAsync(Guid supplierId)
    {
        var result = await _httpClient.GetFromJsonAsync<List<InvoiceViewModel>>($"api/invoices/supplier/{supplierId}");
        return result ?? new List<InvoiceViewModel>();
    }

    public async Task<Dictionary<string, string>> AnalyzeDocumentAsync(MultipartFormDataContent content)
    {
        var response = await _httpClient.PostAsync("api/documents/analyze", content);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Dictionary<string, string>>() ?? new Dictionary<string, string>();
    }
}
