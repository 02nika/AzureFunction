using AzureFunction.Interfaces;
using AzureFunction.Models;

namespace AzureFunction.Services;

// Single Responsibility Principle: ეს კლასი ორიენტირებულია fixed discount-ზე 
// Open/Closed Principle: ახალი კალკულატორის შექმნა შესაძლებელია არსებულ კლასში ჩარევის კოდის შეცვლის გარეშე
public class FixedDiscountCalculator : IDiscountCalculator
{
    public bool CanApply(string customerType) => customerType == "regular";

    public DiscountResult ApplyDiscount(Invoice invoice)
    {
        const decimal discount = 10m;
        return new DiscountResult
        {
            OriginalAmount = invoice.Amount,
            FinalAmount = invoice.Amount - discount,
            AppliedDiscountType = "Fixed ($10)"
        };
    }
}