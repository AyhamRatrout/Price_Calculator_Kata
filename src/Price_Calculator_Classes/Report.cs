using System;
using Extension_Library;

namespace Price_Calculator_Classes
{
    /*
        This class represents a Report type which Generates and Prints/Displays a detialed Report (breakdown) of each 
        Price calculation made to each Product in a given ShoppingCart instance.

        This allows the user to view Discounts applied to a Product and and their amount, Tax and its amount, and each Additional cost and its amount
        which have been applied to each Product in their ShoppingCart
    */
    public class Report
    {
        //Stores the ShoppingCart instance provided to a Report instance.
        private ShoppingCart ShoppingCart;

        /*
            Class constructor generates a Report for a given ShoppingCart instance (passed as input to the constructor).
            Validates the ShoppingCart input before storing it in the ShoppingCart field.
        */
        public Report(ShoppingCart shoppingCart)
        {
            Validate(shoppingCart);
            this.ShoppingCart = shoppingCart;
        }

        //Allows the user to Print a Report of their purchases. Calls the GenerateReport method and displays the information to the Console.
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
            //variables needed inside the foreach loop.
            var taxCalculator = this.ShoppingCart.PriceCalculator.TaxCalculator;
            var discountCalculator = this.ShoppingCart.PriceCalculator.DiscountCalculator;
            
            GenerateHeader(); //Creates the Report header.

            //Enumerates over each Product in the provided ShoppingCart instance.
            foreach (var product in this.ShoppingCart)
            {
                //Stores the Price of a Product that remains after applying the Before-Tax Discounts.
                var remainingPrice = (product.Price - this.ShoppingCart.PriceCalculator.DiscountCalculator.BeforeTaxDiscountCalculator.Calculate(product));

                //Prints a Product's name, UPC, and Price to the console.
                Console.WriteLine($"Product Name: {product.Name}, Product UPC: {product.UPC}, Product Price: ${product.Price:N2}");

                GenerateTaxReport(taxCalculator, remainingPrice);

                GenerateTotalDiscountReport(discountCalculator, product);
                
                GenerateAdditionalCostsReport(product);

                //Prints to the Console the final Price of the Product after all Discounts, Taxes, and Costs have been applied.
                Console.WriteLine($"Price after adjustments were applied: ${this.ShoppingCart.PriceCalculator.CalculatePrice(product)}");

                Formatter.AddLine();
                
                Formatter.AddLine();
            }
        }

        //Helper method takes care of generating a header for a Report instance.
        private void GenerateHeader()
        {
            Formatter.AddLine();
            Formatter.AddLine();
            Formatter.AlignCenter("Purchases Report");
            Formatter.AlignCenter(DateTime.Now.ToString());
            Formatter.AddLine();
        }

        //Helper method calculates and displays the Tax percentage and amount applied to each product. Prints the results to the console.
        private void GenerateTaxReport(TaxCalculator taxCalculator, double Price)
        {
            Console.WriteLine($"Tax was reported at: {taxCalculator.Tax}% which adds ${taxCalculator.CalculateTaxAmount(Price):N2} to the product's price.");
        }

        //Helper method calculates and displays the Total Discount amount applied to each Product instance. Informs the user whether or not a Discount Cap was applied.
        private void GenerateTotalDiscountReport(DiscountCalculator discountCalculator, Product product)
        {
            var totalDiscountAmount = discountCalculator.Calculate(product);

            if(totalDiscountAmount == DiscountCapCalculator.GetDiscountCap(product))
            {
                Console.WriteLine($"This product has a discount cap applied to it! Therefore, total discounts applied to this product were capped at: ${totalDiscountAmount}");
            }
            
            else
            {
                Console.WriteLine($"Total discounts applied to this product add up to: ${totalDiscountAmount}");
            }
        }

        //Helper method caluclates and displays each AdditionalDiscount applied to a given Product in the ShoppingCart. Prints the results to the Console.
        private void GenerateAdditionalCostsReport(Product product)
        {
            if (product.ListOfCosts.Count != 0)
            {
                Console.WriteLine("Additional costs on this product include:");

                //Enumerates over the AdditionalDiscountList for the given Product (if it's not empty) and Prints the Cost Description and its Amount.
                foreach (var additionalCost in product.ListOfCosts)
                {
                    if (additionalCost.AmountType == AmountType.Absolute)
                    {
                        Console.WriteLine($"\t{additionalCost.Description}: ${additionalCost.Amount}");
                    }
                    else
                    {
                        Console.WriteLine($"\t{additionalCost.Description}: ${Math.Round(product.Price * ArithmeticExtensions.PercentageToDecimal(additionalCost.Amount), 2)}");
                    }
                }
            }
        }

        //Helper method validataes the ShoppingCart instance passed to a Report instance. Throws an ArgumentException if the ShoppingCart is null.
        private void Validate(ShoppingCart shoppingCart)
        {
            if (shoppingCart == null)
            {
                throw new ArgumentException("Invalid input! Please make sure that you are not providing a null ShoppingCart.");
            }
        }

    }
}