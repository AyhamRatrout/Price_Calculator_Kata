using System;
using Extension_Library;

namespace Price_Calculator_Classes
{
    public class TaxCalculator
    {
        //Property and backing field to keep track of the Tax percentage applied to a porduct
        private double _Tax;
        public double Tax
        {
            get {return this._Tax;} 
            set 
            {
                this._Tax = value;
                Validate(); //validates that the applied tax percentage is acceptable
            }
        }

        //Class constructor creates a TaxCalculator instance and initializes Tax to its default percentage.
        public TaxCalculator()
        {
            this._Tax = 20.00;
        }

        //Calculates and returns the tax amount on a product to two decimal places.
        public double CalculateTaxAmount(Product product)
        {
            return Math.Round((product.Price * ArithmeticExtensions.PercentageToDecimal(this._Tax)), 2);
        }

        //Helper method validates a Tax percentage for acceptability. Throws an ArgumentException if invalid.
        private void Validate()
        {
            if(this._Tax <= 0 || this._Tax > 100)
            {
                throw new ArgumentException("Invalid input! Please make sure that the tax amount is greater than 0% and less than or equal to 100%");
            }
        }
    }
}