using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portal.Application.Interfaces;
using Portal.Domain.Entities;

namespace Portal.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SuppliersController : ControllerBase
{
    private readonly ISupplierService _supplierService;

    public SuppliersController(ISupplierService supplierService)
    {
        _supplierService = supplierService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Supplier>>> GetSuppliers(CancellationToken cancellationToken)
    {
        var suppliers = await _supplierService.GetSuppliersAsync(cancellationToken);
        return Ok(suppliers);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Supplier>> GetSupplier(Guid id, CancellationToken cancellationToken)
    {
        var supplier = await _supplierService.GetSupplierAsync(id, cancellationToken);
        return supplier is null ? NotFound() : Ok(supplier);
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<ActionResult<Supplier>> RegisterSupplier([FromBody] Supplier supplier, CancellationToken cancellationToken)
    {
        var created = await _supplierService.RegisterSupplierAsync(supplier, cancellationToken);
        return CreatedAtAction(nameof(GetSupplier), new { id = created.Id }, created);
    }
}
