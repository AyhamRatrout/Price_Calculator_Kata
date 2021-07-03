using System;

namespace Price_Calculator_Classes
{
    public interface IBeforeTaxCalculator
    {
        double Calculate(Product product);
    }
}