using System;

namespace Price_Calculator_Classes
{
    public class PriceCalculator
    {
        //A PriceCalculator needs a TaxCalculator instance to calculate tax.
        public TaxCalculator TaxCalculator{get; private set;} 
        
        //A PriceCalculator needs a DiscountCalculator instance to calculate discounts.
        public DiscountCalculator DiscountCalculator{get; private set;}

        //Class constructor initializes a PriceCalculator instance by initializing a TaxCalculator and a DiscountCalculator instances.
        public PriceCalculator()
        {
            this.TaxCalculator = new TaxCalculator();
            this.DiscountCalculator = new DiscountCalculator();
        }

        //When a customer applies a tax amount, this method is invoked which in turn changes the Tax field in the TaxCalculator class.
        public void ApplyTax(double Tax)
        {
            this.TaxCalculator.Tax = Tax;
        }

        //When a customer applies a discount amount, this method is invoked which in turn changes the Discount field in the DiscountCalculator class.
        public void ApplyDiscount(double Discount)
        {
            this.DiscountCalculator.Discount = Discount;
        }

        //Calculates and returns the price of a product after applying adding tax and subtracting any discounts. Returns price to two decimals.
        public double CalculateAdjustedPrice(Product product)
        {
            var adjustments = this.TaxCalculator.CalculateTaxAmount(product) - this.DiscountCalculator.CalculateTotalDiscountAmount(product);
            return Math.Round(product.Price + adjustments, 2);
        }
        
    }
}