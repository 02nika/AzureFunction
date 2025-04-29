using AzureFunction.Interfaces;
using AzureFunction.Models;

namespace AzureFunction.Services;

// Single Responsibility Principle: ეს კლასი ორიენტირებულია percentage discount-ზე 
// Open/Closed Principle: ახალი კალკულატორის შექმნა შესაძლებელია არსებულ კლასში კოდის შეცვლის გარეშე
public class PercentageDiscountCalculator : IDiscountCalculator
{
    public bool CanApply(string customerType) => customerType == "vip";

    public DiscountResult ApplyDiscount(Invoice invoice)
    {
        var discount = invoice.Amount * 0.2m;
        return new DiscountResult
        {
            OriginalAmount = invoice.Amount,
            FinalAmount = invoice.Amount - discount,
            AppliedDiscountType = "Percentage (20%)"
        };
    }
}