using System;

namespace Price_Calculator_Classes
{
    public static class PriceCalculator
    {
        private static double Tax = 0.20; //Field defines a default tax rate of 20% on all products
        private static double Discount = 0; //Field stores the relative discount amount chosen by the customer

        //Allows the customer to pass in a discount amount which will be applied to all the Products they buy
        public static void ApplyDiscount(double discount)
        {
            if (discount < 0 || discount > 100)
            {
                throw new ArgumentException("Invalid input. Please make sure that the discount applied is between 0% and 100%");
            }
            else
            {
                Discount = discount / 100;
            }
        }

        //Extension method calculates the price of a product after applying the 20% default tax rate and the customer-chosen discount amount
        public static void CalculateAdjustedPriceDefaultTax(this Product product)
        {
            product.PriceAfterAdjustments = CalculateAndFormatPriceAfterAdjustment(product, Tax, Discount);
            PrintResults(product, Tax); //calls helper method that prints the results                               
        }

        //Extension method calculates the price of a product after applying a custom tax rate that the user decides as well as the
        //customer-chosen discount amount. Throws an ArgumentException if the user inputs an ivalid tax rate (i.e. less than zero or greater than 100)
        public static void CalculateAdjustedPriceCustomTax(this Product product, double tax)
        {
            if (tax < 0 || tax > 100)
            {
                throw new ArgumentException("Invalid input. Please make sure that the tax applied is between 0% and 100%");
            }
            else
            {
                tax = (tax / 100);
                product.PriceAfterAdjustments = CalculateAndFormatPriceAfterAdjustment(product, tax, Discount);
                PrintResults(product, tax);
            }
        }

        //Helper method returns the calculated/formatted Price of a Product after tax and discounts have been applied
        private static double CalculateAndFormatPriceAfterAdjustment(Product product, double tax, double discount)
        {
            double priceAfterAdjustments = (product.PriceBeforeAdjustments + CalculateTaxAmount(product, tax) - CalculateDiscountAmount(product));
            return (Math.Round(priceAfterAdjustments, 2));
        }

        //Helper method returns the amount to be discounted from the price of a product by applying the customer-chosen relative discount amount
        private static double CalculateDiscountAmount(Product product)
        {
            double discountAmount = product.PriceBeforeAdjustments * Discount;
            return discountAmount;
        }

        //Helper method that calculates/returns the amount of tax on a Product
        private static double CalculateTaxAmount(Product product, double tax)
        {
            double taxAmount = product.PriceBeforeAdjustments * (tax);
            return taxAmount;
        }

        //Helper method that prints the results of the above operations to the console every time whenever an operation is called.
        private static void PrintResults(Product product, double tax)
        {
            Console.WriteLine($"Product name: {product.Name}, UPC: {product.UPC}, Price before adjustments: ${product.PriceBeforeAdjustments:N2}");
            Console.WriteLine($"Tax = {tax * 100}%, Discount = {Discount * 100}%");
            Console.WriteLine($"Tax amount = ${CalculateTaxAmount(product, tax) :N2}, Discount amount = ${CalculateDiscountAmount(product) :N2}");
            Console.WriteLine($"Product price reported as ${product.PriceBeforeAdjustments:N2} before tax and discounts and ${product.PriceAfterAdjustments:N2} after tax and discounts");
        }


    }
}