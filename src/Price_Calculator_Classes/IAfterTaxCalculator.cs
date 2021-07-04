using System;

namespace Price_Calculator_Classes
{
    /*
        This interface defines the characteritics any AfterTaxCalculator type must have.

        Requires all AfterTaxCalculator types to implement its Calculate() method which takes two parameters: a Price (double) and a Product
    */
    public interface IAfterTaxCalculator
    {
        double Calculate(double Price, Product product);
    }
}