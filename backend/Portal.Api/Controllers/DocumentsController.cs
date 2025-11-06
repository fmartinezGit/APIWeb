using Microsoft.AspNetCore.Mvc;
using Portal.Api.Services;

namespace Portal.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DocumentsController : ControllerBase
{
    private readonly DocumentIntelligenceService _documentService;
    private readonly IConfiguration _configuration;

    public DocumentsController(DocumentIntelligenceService documentService, IConfiguration configuration)
    {
        _documentService = documentService;
        _configuration = configuration;
    }

    [HttpPost("analyze")]
    [RequestSizeLimit(25 * 1024 * 1024)]
    public async Task<IActionResult> AnalyzeDocument([FromForm] IFormFile file, CancellationToken cancellationToken)
    {
        if (file.Length == 0)
        {
            return BadRequest("File is empty");
        }

        await using var stream = file.OpenReadStream();
        var modelId = _configuration["DocumentIntelligence:ModelId"] ?? "prebuilt-invoice";
        var result = await _documentService.AnalyzeInvoiceAsync(stream, modelId, cancellationToken);
        return Ok(result);
    }
}
