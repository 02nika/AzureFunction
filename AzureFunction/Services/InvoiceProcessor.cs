using AzureFunction.Interfaces;
using AzureFunction.Models;

namespace AzureFunction.Services;

// Open/Closed Principle: მხარ დაუჭერს ახალ ტიპებს ძველების ჩანაცვლების გარეშე (ინტერფეისის დახმარებით)
// Dependency Inversion Principle: ჩანს აბსტრაქციაზე დამოკიდებულება
public class InvoiceProcessor : IInvoiceProcessor
{
    private readonly IEnumerable<IDiscountCalculator> _calculators;

    public InvoiceProcessor(IEnumerable<IDiscountCalculator> calculators)
    {
        _calculators = calculators;
    }

    public DiscountResult ProcessInvoice(Invoice invoice)
    {
        var calculator = _calculators.FirstOrDefault(c => c.CanApply(invoice.CustomerType)) ??
                         throw new Exception("No applicable discount found.");

        return calculator.ApplyDiscount(invoice);
    }
}