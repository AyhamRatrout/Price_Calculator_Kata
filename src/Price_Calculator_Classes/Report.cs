using System;

namespace Price_Calculator_Classes
{
    //Allows a customer to generate a detailed report of their purchases to better understand the breakdown of the various price calculations.
    public static class Report
    {
        //Takes care of generating the detailed report of the price calculation breakdown for a custotmer's cart
        public static void GetReport(this PriceCalculator priceCalculator, Product product)
        {
            Console.WriteLine($"Product Name: {product.Name}, Product UPC: {product.UPC}, Product Price: ${product.Price :N2}" ); //prints product details
            
            //reports tax percentage and amount for each product in cart
            Console.WriteLine($"Tax was reported at: {priceCalculator.TaxCalculator.Tax}% which adds ${priceCalculator.TaxCalculator.CalculateTaxAmount(product) :N2} to the product's price.");

            GenerateDiscountReport(priceCalculator, product);

            //prints the adjusted price for a product
            Console.WriteLine($"Price after adjustments were applied: ${priceCalculator.CalculateAdjustedPrice(product)}");
            Console.WriteLine();
        }

        //Helper method takes care of generating a report of the various discounts applied to a product (if any).
        private static void GenerateDiscountReport(PriceCalculator priceCalculator, Product product)
        {
            //if no discounts are applied, informs the customer that none were applied
            if(priceCalculator.DiscountCalculator.Discount == 0.00 && Administrator.UPCDiscountList.Count == 0)
            {
                Console.WriteLine("No discounts were applied to your shopping cart.");
            }

            else
            {
                //informs the customer that a relative discount was applied to all the products in their cart.
                if(priceCalculator.DiscountCalculator.Discount != 0)
                {
                    Console.WriteLine($"Relative discount was reported at {priceCalculator.DiscountCalculator.Discount}% which deducts ${priceCalculator.DiscountCalculator.CalculateRelativeDiscountAmount(product) :N2} from this product's price.");
                }

                //if a product qualifies for further discounts, informs the user that this porduct qualifies for a special discount and its amount.
                if(Administrator.UPCDiscountList.ContainsKey(product.UPC))
                {
                    Console.WriteLine($"Congratulations! This product qualifies for a special discount of {Administrator.UPCDiscountList[product.UPC]}% which deducts ${priceCalculator.DiscountCalculator.CalculateUPCSpecificDiscountAmount(product) :N2} from this product's price.");
                }
            }

            //if any discount was applied to a product, notifies the customer of the total discount amount applied to that specific product 
            if(priceCalculator.DiscountCalculator.Discount != 0.00 || Administrator.UPCDiscountList.ContainsKey(product.UPC))
            {
                Console.WriteLine($"Total discounts applied to this product amount to ${priceCalculator.DiscountCalculator.CalculateTotalDiscountAmount(product) :N2}");                
            }
        }
    }
}