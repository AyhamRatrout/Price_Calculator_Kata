using System;
using Extension_Library;

namespace Price_Calculator_Classes
{
    /*
        This class defines an AdditionalCostsCalculator type which is used to calculate all the Additional Costs associated with a Product instance.
        This class has one method (CalculateAdditionalCosts) which calculates and returns a Product's Additional Costs.
    */
    public class AdditionalCostsCalculator
    {
        //Calculates and returns the sum of all the Additional Costs associated with a Product instance.
        public static double CalculateAdditionalCosts(Product product)
        {
            var additionalCosts = 0.00;
            foreach(var additionalCost in product.ListOfCosts)
            {
                if(additionalCost.AmountType == AmountType.Percentage)
                {
                    //If the amount is a percentage of Price, this calculates the absolute amount then adds it to the sum of Additional Costs.
                    additionalCosts += (product.Price * ArithmeticExtensions.PercentageToDecimal(additionalCost.Amount));
                }
                else
                {
                    additionalCosts += additionalCost.Amount;
                }
            }
            return additionalCosts;
        }
    }
}