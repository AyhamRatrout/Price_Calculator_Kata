using System;
using Extension_Library;

namespace Price_Calculator_Classes
{
    //This class generates a detailed report/breakdown of each price calculation made to each Product in a ShoppingCart instance.
    public class Report
    {
        //Field that stores the ShoppingCart instance for a Report instance.
        private ShoppingCart ShoppingCart;

        /*
            Class constructor generates a Report for a given ShoppingCart instance (passed as input to the constructor).
            Validates the ShoppingCart input before generating the Report.
        */
        public Report(ShoppingCart shoppingCart)
        {
            this.ShoppingCart = shoppingCart;
            Validate();
        }

        //Allows the user to generate a Report for their purchases. Calls the GenerateReport method and displays the information to the console.
        public void Print()
        {
            GenerateReport();
        }

        /*
            Helper method generates a Report for a given ShoppingCart instance by making a series of calls to other helper methods in this class.
            Enumerates over each item in the ShoppingCart instance and generates the detailed Report breakdown for each Product.
            Writes all the results to the console.
        */
        private void GenerateReport()
        {
            GenerateHeader();

            foreach(var product in this.ShoppingCart.ListOfProducts)
            {
                //Prints a Product's name, UPC, and price to the console.
                Console.WriteLine($"Product Name: {product.Name}, Product UPC: {product.UPC}, Product Price: ${product.Price :N2}");
                
                GenerateTaxReport(this.ShoppingCart.PriceCalculator.TaxCalculator, product);

                GenerateDiscountReport(this.ShoppingCart.PriceCalculator.DiscountCalculator, product);

                Console.WriteLine($"Price after adjustments were applied: ${this.ShoppingCart.PriceCalculator.CalculatePrice(product)}");
                
                Console.WriteLine();
            }
        }

        //Helper method takes care of generating a header for a Report instance.
        private void GenerateHeader()
        {
            Console.WriteLine();
            Console.WriteLine();
            Formatter.AlignCenter("Purchases Report");
            Formatter.AlignCenter(DateTime.Now.ToString());
            Console.WriteLine();
        }

        //Helper method calculates and displays the Tax percentage and amount applied to each product. Prints the results to the console.
        private void GenerateTaxReport(TaxCalculator taxCalculator, Product product)
        {
            Console.WriteLine($"Tax was reported at: {taxCalculator.Tax}% which adds ${taxCalculator.CalculateTaxAmount(product) :N2} to the product's price.");
        }

        //Helper method takes care of generating a detailed report of the various discounts and their amounts applied to each product (if any).
        public void GenerateDiscountReport(DiscountCalculator discountCalculator, Product product)
        {
            //If no discounts are applied to a product, prints a message with this information to the console. 
            if(discountCalculator.RelativeDiscountCalculator.Discount == 0.00 && discountCalculator.SpecialDiscountCalculator.SpecialDiscountList.DiscountList.Count == 0)
            {
                Console.WriteLine("No discounts were applied to your shopping cart.");
            }

            else
            {
                //If a relative discount was applied to a ShoppingCart, it prints the amount discounted from each product in the cart to the console.
                if(discountCalculator.RelativeDiscountCalculator.Discount != 0)
                {
                    Console.WriteLine($"Relative discount was reported at {discountCalculator.RelativeDiscountCalculator.Discount}% which deducts ${discountCalculator.RelativeDiscountCalculator.CalculateDiscountAmount(product) :N2} from this product's price.");
                }

                //If a product qualifies for further discounts, prints to the console that this porduct qualifies for a special discount and the discount's amount.
                if(discountCalculator.SpecialDiscountCalculator.SpecialDiscountList.ContainsKey(product.UPC))
                {
                    Console.WriteLine($"Congratulations! This product qualifies for a special discount of {discountCalculator.SpecialDiscountCalculator.SpecialDiscountList.DiscountList[product.UPC]}% which deducts ${discountCalculator.SpecialDiscountCalculator.CalculateDiscountAmount(product) :N2} from this product's price.");
                }
            }

            //if any discounts were applied to a product, notifies the user by displaying a message of the total discount amount applied to that specific product to the console.
            if(discountCalculator.RelativeDiscountCalculator.Discount != 0.00 && discountCalculator.SpecialDiscountCalculator.SpecialDiscountList.DiscountList.Count != 0)
            {
                Console.WriteLine($"Total discounts applied to this product amount to ${discountCalculator.CalculateDiscountAmount(product) :N2}");                
            }            
        }

        //Helper method validataes the ShoppingCart instance passed to a Report instance. Throws an ArgumentException if the ShoppingCart is null.
        private void Validate()
        {
            if(this.ShoppingCart == null)
            {
                throw new ArgumentException("Invalid input! Please make sure that the ShoppingCart you are passing is NOT null.");
            }
        }
        
    }
}