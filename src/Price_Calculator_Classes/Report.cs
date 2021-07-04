using System;
using Extension_Library;

namespace Price_Calculator_Classes
{
    /*
        This class represents a Report type which Generates and Prints/Displays a detialed Report (breakdown) of each 
        Price calculation made to each Product in a given ShoppingCart instance.

        This allows the user to view each Discount and its amount, each Tax and its amount, and each Additional cost and its amount
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
            GenerateHeader(); //Creates the Report header.

            //Enumerates over each Product in the provided ShoppingCart instance.
            foreach (var product in this.ShoppingCart)
            {
                //Prints a Product's name, UPC, and price to the console.
                Console.WriteLine($"Product Name: {product.Name}, Product UPC: {product.UPC}, Product Price: ${product.Price:N2}");

                GenerateBeforeTaxDiscountsReport(this.ShoppingCart.PriceCalculator.BeforeTaxDiscountCalculator, product);

                GenerateTaxReport(this.ShoppingCart.PriceCalculator.TaxCalculator, product.Price - this.ShoppingCart.PriceCalculator.BeforeTaxDiscountCalculator.Calculate(product));

                GenerateAfterTaxDiscountReport(this.ShoppingCart.PriceCalculator.AfterTaxDiscountCalculator, product.Price - this.ShoppingCart.PriceCalculator.BeforeTaxDiscountCalculator.Calculate(product), product);

                Console.WriteLine($"Total discounts applied to this product add up to: ${this.ShoppingCart.PriceCalculator.BeforeTaxDiscountCalculator.Calculate(product) + this.ShoppingCart.PriceCalculator.AfterTaxDiscountCalculator.Calculate(product.Price - this.ShoppingCart.PriceCalculator.BeforeTaxDiscountCalculator.Calculate(product), product)}");

                GenerateAdditionalCostsReport(product);

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

        //Helper method calculates and displays each Discount applied to a Product before Tax is applied (if any). Prints the results to the Console.
        private void GenerateBeforeTaxDiscountsReport(BeforeTaxDiscountCalculator beforeTaxDiscountCalculator, Product product)
        {
            //If no discounts are applied to the Product, displays a message to the user indicating the latter.
            if (beforeTaxDiscountCalculator.RelativeDiscountCalculator.RelativeDiscountList.Count == 0 && beforeTaxDiscountCalculator.SpecialDiscountCalculator.SpecialDiscountList.Count == 0)
            {
                Console.WriteLine("No before-tax discounts were applied to this product.");
            }

            else
            {
                //Enumerates over the RelativeDiscountList for a ShoppingCart. Calculates and prints the percentage and amount of each Discount applied to each Product.
                foreach (var relativeDiscount in beforeTaxDiscountCalculator.RelativeDiscountCalculator.RelativeDiscountList)
                {
                    Console.WriteLine($"Before-tax relative discount was reported at: {relativeDiscount.Discount}% which deducts ${beforeTaxDiscountCalculator.RelativeDiscountCalculator.Calculate(product):N2} from the product's price.");
                }

                //Enumerates over the SpecialDiscountList for a given ShoppingCart.
                foreach (var specialDiscount in beforeTaxDiscountCalculator.SpecialDiscountCalculator.SpecialDiscountList)
                {
                    //If a Product qualifies for a SpecialDiscount, calculates and prints the percentage and amount of the Discount applied to that Product.
                    if (beforeTaxDiscountCalculator.SpecialDiscountCalculator.SpecialDiscountList.Contains(product.UPC))
                    {
                        Console.WriteLine($"Congratulations! This product qualifies for a before-tax special discount of: {specialDiscount.Discount}% which deducts ${beforeTaxDiscountCalculator.SpecialDiscountCalculator.Calculate(product):N2} from the product's price.");
                    }
                }
                //Calcultes and prints the total amount of before-tax discounts applied to each Product in the ShoppingCart.
                Console.WriteLine($"Total before-tax discount amount comes out to: ${beforeTaxDiscountCalculator.Calculate(product):N2}");
            }
        }

        //Helper method calculates and displays the Tax percentage and amount applied to each product. Prints the results to the console.
        private void GenerateTaxReport(TaxCalculator taxCalculator, double Price)
        {
            Console.WriteLine($"Tax was reported at: {taxCalculator.Tax}% which adds ${taxCalculator.CalculateTaxAmount(Price):N2} to the product's price.");
        }

        //Helper method calculates and displays each Discount applied to each Product after Tax is applied (if any). Prints the results to the Console.        
        private void GenerateAfterTaxDiscountReport(AfterTaxDiscountCalculator afterTaxDiscountCalculator, double Price, Product product)
        {
            //If no discounts are applied to the Product, displays a message to the user indicating the latter.
            if (afterTaxDiscountCalculator.RelativeDiscountCalculator.RelativeDiscountList.Count == 0 && afterTaxDiscountCalculator.SpecialDiscountCalculator.SpecialDiscountList.Count == 0)
            {
                Console.WriteLine("No after-tax discounts were applied to this product.");
            }

            else
            {
                //Enumerates over the RelativeDiscountList for a given ShoppingCart. Calculates and prints the percentage and amount of each Discount applied to each Product in the Cart.
                foreach (var relativeDiscount in afterTaxDiscountCalculator.RelativeDiscountCalculator.RelativeDiscountList)
                {
                    Console.WriteLine($"After-tax relative discount was reported at: {relativeDiscount.Discount}% which deducts ${afterTaxDiscountCalculator.RelativeDiscountCalculator.Calculate(Price, product):N2} from the product's price.");
                }

                //Enumerates over the SpecialDiscountList for a given ShoppingCart.
                foreach (var specialDiscount in afterTaxDiscountCalculator.SpecialDiscountCalculator.SpecialDiscountList)
                {
                    //If a Product qualifies for a SpecialDiscount, calculates and prints the percentage and amount of the SpecialDiscount applied to that Product.                    
                    if (afterTaxDiscountCalculator.SpecialDiscountCalculator.SpecialDiscountList.Contains(product.UPC))
                    {
                        Console.WriteLine($"Congratulations! This product qualifies for a after-tax special discount of: {specialDiscount.Discount}% which deducts ${afterTaxDiscountCalculator.SpecialDiscountCalculator.Calculate(Price, product):N2} from the product's price.");
                    }
                }

                //Calcultes and prints the total amount of after-tax discounts applied to each Product in the ShoppingCart.                
                Console.WriteLine($"Total after-tax discount amount comes out to: ${afterTaxDiscountCalculator.Calculate(Price, product):N2}");
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