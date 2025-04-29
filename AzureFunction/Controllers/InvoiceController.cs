using AzureFunction.Interfaces;
using AzureFunction.Models;
using Microsoft.AspNetCore.Mvc;

namespace AzureFunction.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InvoiceController : ControllerBase
{
    private readonly IInvoiceProcessor _invoiceProcessor;
    private readonly ILoggerService _logger;

    public InvoiceController(IInvoiceProcessor invoiceProcessor, ILoggerService logger)
    {
        _invoiceProcessor = invoiceProcessor;
        _logger = logger;
    }

    [HttpPost]
    public ActionResult<DiscountResult> Post([FromBody] Invoice? invoice)
    {
        if (invoice == null) return BadRequest("Invoice is required.");

        var result = _invoiceProcessor.ProcessInvoice(invoice);
        _logger.Log($"Invoice processed. Final amount: {result.FinalAmount}");

        return Ok(result);
    }
}