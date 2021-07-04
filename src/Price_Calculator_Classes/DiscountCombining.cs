
namespace Price_Calculator_Classes
{
    /*
        Enumeration type defines two constants: Additive and Multiplicative.

        This Enumeration type enables the user to decide the method of Combining Discount as either:
        
            1. Additive: discounts are all calculated from the original price and summed up.
            2. Multiplicative: each disocunt is calculated from the price after applying the previous one.
    */
    public enum DiscountCombining
    {
        Additive,
        Multiplicative
    }
}