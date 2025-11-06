using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portal.Application.Interfaces;
using Portal.Domain.Entities;

namespace Portal.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InvoicesController : ControllerBase
{
    private readonly IInvoiceService _invoiceService;

    public InvoicesController(IInvoiceService invoiceService)
    {
        _invoiceService = invoiceService;
    }

    [HttpGet("supplier/{supplierId:guid}")]
    public async Task<ActionResult<IEnumerable<Invoice>>> GetInvoices(Guid supplierId, CancellationToken cancellationToken)
    {
        var invoices = await _invoiceService.GetInvoicesForSupplierAsync(supplierId, cancellationToken);
        return Ok(invoices);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Invoice>> GetInvoice(Guid id, CancellationToken cancellationToken)
    {
        var invoice = await _invoiceService.GetInvoiceAsync(id, cancellationToken);
        return invoice is null ? NotFound() : Ok(invoice);
    }

    [HttpPost]
    public async Task<ActionResult<Invoice>> SubmitInvoice([FromBody] Invoice invoice, CancellationToken cancellationToken)
    {
        var created = await _invoiceService.SubmitInvoiceAsync(invoice, cancellationToken);
        return CreatedAtAction(nameof(GetInvoice), new { id = created.Id }, created);
    }
}
