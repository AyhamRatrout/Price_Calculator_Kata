using System;
using Extension_Library;

namespace Price_Calculator_Classes
{
    /*
        The DiscountCapCalculator type represents a helper class whose only reponsibility is to Calculate the DiscountCap
        Amount associated with a given Product instance. It uses its static method GetDiscountCap(Product) to accomplish this.
    */
    public class DiscountCapCalculator
    {
        /*
            Static method calculates and returns the DiscountCap Amount associated with a given Product instance.

            If the Product's DiscountCap's AmountType is Absolute, the DiscountCap's Amount is returned. If the Product's
            DiscountCap's AmountType is Percentage, the Amount's Absolute equivalent is calculated then returned.
        */
        public static double GetDiscountCap(Product product)
        {
            if (product.DiscountCap.AmountType == AmountType.Percentage)
            {
                return Math.Round((product.Price * ArithmeticExtensions.PercentageToDecimal(product.DiscountCap.Amount)), 4);
            }

            return Math.Round(product.DiscountCap.Amount, 4);
        }
    }
}