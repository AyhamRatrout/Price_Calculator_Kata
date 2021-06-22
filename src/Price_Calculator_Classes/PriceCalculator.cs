using System;

namespace Price_Calculator_Classes
{
    public static class TaxCalculator
    {
        private static double Tax = 0.20; //Field defines a default tax rate of 20% on all products
        
        //Extension method calculates the price of a product after applying the 20% default tax rate
        public static void CalculatePriceDefaultTax(this Product product)
        {
            product.PriceAfterTax = Math.Round(product.PriceBeforeTax * (1 + Tax), 2);
            PrintResults(product, Tax); //calls helper method that prints the results                               
        }

        //Extension method calculates the price of a product after applying a custom tax rate that the user decides. Throws
        //an ArgumentException if the user inputs an ivalid tax rate (i.e. less than zero or greater than 100)
        public static void CalculatePriceCustomTax(this Product product, double tax)
        {
            if(tax < 0 || tax > 100)
            {
                throw new ArgumentException("Invalid input. Please make sure that the tax applied is between 0 and 100.");
            }
            else
            {
                product.PriceAfterTax = Math.Round(product.PriceBeforeTax * (1 + tax / 100), 2);
                PrintResults(product, (tax / 100));
            }
        }

        //Helper method that prints the results of the above operations to the console every time either of the two operations above executes.
        private static void PrintResults(Product product, double tax)
        {
            Console.WriteLine($"Product name: {product.Name}, UPC: {product.UPC}, Base Price: {product.PriceBeforeTax :N2}");
            Console.WriteLine($"Product price reported as ${product.PriceBeforeTax :N2} before tax and ${product.PriceAfterTax :N2} after {tax * 100}% tax.");            
        }


    }
}