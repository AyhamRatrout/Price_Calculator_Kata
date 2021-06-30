using System;

namespace Price_Calculator_Classes
{
    public class PriceCalculator
    {
        //A PriceCalculator instance must have a TaxCalculator instance which takes care of calculating the Tax amount on a given project.
        public TaxCalculator TaxCalculator {get; private set;}
        
        //A PriceCalculator instance must have a DiscountCalculator instance which takes care of calculating the Discount amounts on a given product.
        public DiscountCalculator DiscountCalculator {get; private set;}

        /*
            Class constructor initializes a PriceCalculator instance using a TaxCalculator instance and a DiscountCalculator instance.
            Validates both input parameters before initializing a PriceCalculator instance.
        */
        public PriceCalculator(TaxCalculator TaxCalculator, DiscountCalculator DiscountCalculator)
        {
            this.TaxCalculator = TaxCalculator;
            this.DiscountCalculator = DiscountCalculator;
            Validate();
        }

        //Calculates the Price of a Product after applying Tax and any available Discounts to it.
        public double CalculatePrice(Product product)
        {
            var adjustments = this.TaxCalculator.CalculateTaxAmount(product) - this.DiscountCalculator.CalculateDiscountAmount(product);
            return Math.Round(product.Price + adjustments, 2);
        }

        /*
            Hlper method validates (checks) that a PriceCalculator instance TaxCalculator and DiscountCalculator properties aare not before
            creating a PriceCalculator instance. Throw an ArgumentException if either one of the two properties is null.
        */
        private void Validate()
        {
            if(this.TaxCalculator == null || this.DiscountCalculator == null)
            {
                throw new ArgumentException("Invalid input! Please make sure that you are not passing a null value when initializing an instance of this class.");
            }
        }        
    }
}