using System;
using Extension_Library;

namespace Price_Calculator_Classes
{
    //This class takes care of calculating Tax amount applied to a given Product.
    public class TaxCalculator
    {
        //Property stores the Tax percentage associated with a TaxCalculator instance.
        public double Tax {get; private set;}

        //Class constructor creates a TaxCalculator instance and initializes Tax to its default percentage.
        public TaxCalculator()
        {
            this.Tax = 20.00;
        }

        //Class constructor takes in a Tax percentage as input. Validates the Tax percentage before creating a TaxCalculator instance with this Tax.
        public TaxCalculator(double Tax)
        {
            Validate(Tax);
            this.Tax = Tax;
        }

        //Calculates and returns the tax amount on a product to two decimal places.
        public double CalculateTaxAmount(Product product)
        {
            return Math.Round((product.Price * ArithmeticExtensions.PercentageToDecimal(this.Tax)), 2);
        }

        //Helper method validates a Tax percentage for acceptability. Throws an ArgumentException if invalid.
        private void Validate(double Tax)
        {
            if(Tax <= 0 || Tax > 100)
            {
                throw new ArgumentException("Invalid input! Please make sure that the tax amount is greater than 0% and less than or equal to 100%");
            }
        }
    }
}