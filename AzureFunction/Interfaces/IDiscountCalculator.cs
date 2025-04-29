using AzureFunction.Models;

namespace AzureFunction.Interfaces;

// Interface Segregation Principle
public interface IDiscountCalculator
{
    bool CanApply(string customerType);
    DiscountResult ApplyDiscount(Invoice invoice);
}