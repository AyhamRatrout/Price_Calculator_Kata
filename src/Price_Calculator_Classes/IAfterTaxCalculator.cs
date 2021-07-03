using System;

namespace Price_Calculator_Classes
{
    public interface IAfterTaxCalculator
    {
        double Calculate(double Price, Product product);
    }
}