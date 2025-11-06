using Azure;
using Azure.AI.FormRecognizer.DocumentAnalysis;

namespace Portal.Api.Services;

public class DocumentIntelligenceService
{
    private readonly DocumentAnalysisClient _client;

    public DocumentIntelligenceService(IConfiguration configuration)
    {
        var endpoint = new Uri(configuration["DocumentIntelligence:Endpoint"]!);
        var credential = new AzureKeyCredential(configuration["DocumentIntelligence:Key"]!);
        _client = new DocumentAnalysisClient(endpoint, credential);
    }

    public async Task<IDictionary<string, string>> AnalyzeInvoiceAsync(Stream document, string modelId, CancellationToken cancellationToken)
    {
        AnalyzeDocumentOperation operation = await _client.AnalyzeDocumentAsync(WaitUntil.Completed, modelId, document, cancellationToken);
        var result = operation.Value;
        return result.Documents.FirstOrDefault()?.Fields.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Content ?? string.Empty)
               ?? new Dictionary<string, string>();
    }
}
