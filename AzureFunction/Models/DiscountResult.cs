namespace AzureFunction.Models;

public class DiscountResult
{
    public decimal OriginalAmount { get; set; }
    public decimal FinalAmount { get; set; }
    public string AppliedDiscountType { get; set; }
}