using System;

namespace Price_Calculator_Classes
{
    /*
        This interface defines the characteritics any BeforeTaxCalculator type must have.

        Requires all BeforeTaxCalculator types to implement its Calculate() method which takes a Product as a parameter.
    */
    public interface IBeforeTaxCalculator
    {
        double Calculate(Product product);
    }
}