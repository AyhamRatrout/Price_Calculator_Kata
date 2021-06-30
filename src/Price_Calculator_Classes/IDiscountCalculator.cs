using System;

namespace Price_Calculator_Classes
{
    /*
        All Discount Calculators must implement the IDiscountCalculator interface and override its lone method. 
        Defines one method which calculates and returns the discount amount applied to a Product.
    */
    public interface IDiscountCalculator
    {
        double CalculateDiscountAmount(Product product);
    }
}