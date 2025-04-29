using AzureFunction.Models;

namespace AzureFunction.Interfaces;

// Interface Segregation Principle (ISP)
public interface IInvoiceProcessor
{
    DiscountResult ProcessInvoice(Invoice invoice);
}