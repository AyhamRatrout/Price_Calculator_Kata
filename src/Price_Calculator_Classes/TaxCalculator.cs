using System;
using Extension_Library;

namespace Price_Calculator_Classes
{
    //This class deines a TaxCalculator type which calculates the TaxAmount to be applied to a given Product.
    public class TaxCalculator
    {
        //Stores the Tax percentage associated with a TaxCalculator instance.
        public double Tax { get; private set; }

        //Class constructor creates a TaxCalculator instance and initializes Tax to its default percentage value.
        public TaxCalculator()
        {
            this.Tax = 20.00;
        }

        //Class constructor accepts a Tax percentage as input. Validates the Tax percentage before creating a TaxCalculator instance with the provided Tax.
        public TaxCalculator(double Tax)
        {
            Validate(Tax);
            this.Tax = Tax;
        }

        //Calculates and returns the tax amount applied to a Product to two decimal places. Takes the Price (double) of the Product as input.
        public double CalculateTaxAmount(double Price)
        {
            return Math.Round((Price * ArithmeticExtensions.PercentageToDecimal(this.Tax)), 2);
        }

        //Helper method Validates a provided Tax percentage for acceptability. Throws an ArgumentException if invalid.
        private void Validate(double Tax)
        {
            if (Tax <= 0 || Tax > 100)
            {
                throw new ArgumentException("Invalid input! Please make sure that the tax amount is greater than 0% and less than or equal to 100%");
            }
        }
    }
}