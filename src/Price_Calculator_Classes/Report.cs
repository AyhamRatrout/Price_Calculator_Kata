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
            Validate(shoppingCart);
            this.ShoppingCart = shoppingCart;
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

            foreach(var product in this.ShoppingCart)
            {
                //Prints a Product's name, UPC, and price to the console.
                Console.WriteLine($"Product Name: {product.Name}, Product UPC: {product.UPC}, Product Price: ${product.Price :N2}");
                
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

        private void GenerateBeforeTaxDiscountsReport(BeforeTaxDiscountCalculator beforeTaxDiscountCalculator, Product product)
        {
            if(beforeTaxDiscountCalculator.RelativeDiscountCalculator.RelativeDiscountList.Count == 0 && beforeTaxDiscountCalculator.SpecialDiscountCalculator.SpecialDiscountList.Count == 0)
            {
                Console.WriteLine("No before-tax discounts were applied to this product.");
            }
            else
            {
                foreach(var relativeDiscount in beforeTaxDiscountCalculator.RelativeDiscountCalculator.RelativeDiscountList)
                {
                    Console.WriteLine($"Before-tax relative discount was reported at: {relativeDiscount.Discount}% which deducts ${beforeTaxDiscountCalculator.RelativeDiscountCalculator.Calculate(product) :N2} from the product's price.");
                }
                foreach(var specialDiscount in beforeTaxDiscountCalculator.SpecialDiscountCalculator.SpecialDiscountList)
                {
                    if(beforeTaxDiscountCalculator.SpecialDiscountCalculator.SpecialDiscountList.Contains(product.UPC))
                    {
                        Console.WriteLine($"Congratulations! This product qualifies for a before-tax special discount of: {specialDiscount.Discount}% which deducts ${beforeTaxDiscountCalculator.SpecialDiscountCalculator.Calculate(product) :N2} from the product's price.");
                    }
                }
                Console.WriteLine($"Total before-tax discount amount comes out to: ${beforeTaxDiscountCalculator.Calculate(product) :N2}");
            }
        }

        //Helper method calculates and displays the Tax percentage and amount applied to each product. Prints the results to the console.
        private void GenerateTaxReport(TaxCalculator taxCalculator, double Price)
        {
            Console.WriteLine($"Tax was reported at: {taxCalculator.Tax}% which adds ${taxCalculator.CalculateTaxAmount(Price) :N2} to the product's price.");
        }

        private void GenerateAfterTaxDiscountReport(AfterTaxDiscountCalculator afterTaxDiscountCalculator, double Price, Product product)
        {
            if(afterTaxDiscountCalculator.RelativeDiscountCalculator.RelativeDiscountList.Count == 0 && afterTaxDiscountCalculator.SpecialDiscountCalculator.SpecialDiscountList.Count == 0)
            {
                Console.WriteLine("No after-tax discounts were applied to this product.");
            }
            else
            {
                foreach(var relativeDiscount in afterTaxDiscountCalculator.RelativeDiscountCalculator.RelativeDiscountList)
                {
                    Console.WriteLine($"After-tax relative discount was reported at: {relativeDiscount.Discount}% which deducts ${afterTaxDiscountCalculator.RelativeDiscountCalculator.Calculate(Price, product) :N2} from the product's price.");
                }
                foreach(var specialDiscount in afterTaxDiscountCalculator.SpecialDiscountCalculator.SpecialDiscountList)
                {
                    if(afterTaxDiscountCalculator.SpecialDiscountCalculator.SpecialDiscountList.Contains(product.UPC))
                    {
                        Console.WriteLine($"Congratulations! This product qualifies for a after-tax special discount of: {specialDiscount.Discount}% which deducts ${afterTaxDiscountCalculator.SpecialDiscountCalculator.Calculate(Price, product) :N2} from the product's price.");
                    }
                }
                Console.WriteLine($"Total after-tax discount amount comes out to: ${afterTaxDiscountCalculator.Calculate(Price, product) :N2}");
            }            
        }

        private void GenerateAdditionalCostsReport(Product product)
        {
            if(product.ListOfCosts.Count != 0)
            {
                Console.WriteLine("Additional costs on this product include:");
                foreach(var additionalCost in product.ListOfCosts)
                {
                    if(additionalCost.AmountType == AmountType.Absolute)
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
            if(shoppingCart == null)
            {
                throw new ArgumentException("Invalid input! Please make sure that you are not providing a null ShoppingCart.");
            }
        }
        
    }
}