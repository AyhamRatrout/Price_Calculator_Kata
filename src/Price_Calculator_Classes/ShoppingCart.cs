using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Price_Calculator_Classes
{
    /*
        This class represents a custom Collection of Product items (i.e. represents a ShoppingCart IRL).

        The underlying structure to this Collection type is List<Product> and this class implements 
        the IEnumerable<Product> interface in order for it to become Enumerable.

        This class has some, but not all, of the List type capabilities (methods and properties) but it is 
        designed to serve this project only.
    */
    public class ShoppingCart : IEnumerable<Product>
    {
        //Private field of type List of SepcialDiscount represents the underlying structure to this custom Collection.
        private List<Product> ListOfProducts;

        //Stores the PriceCalculator instance provided to the ShoppingCart instance through its constructor.
        public PriceCalculator PriceCalculator { get; private set; }

        //Keeps track of the total price of all the Products in a ShoppingCart instance before any adjustments are made.        
        public double Subtotal { get; private set; }

        //Keeps track of the total Tax to be paid on the Products of a ShoppingCart instance.        
        public double TotalTax { get; private set; }

        //Keeps track of the total Discount amounts applied to a ShoppingCart instance.        
        public double TotalDiscount { get; private set; }

        //Keeps track of all the AdditionalCosts of all the Products in a ShoppingCart instance.
        public double TotalAdditionalCosts { get; private set; }

        //Keeps track of the Total amount to be paid on a ShoppingCart instance after adjustments (Discounts, Costs, and Taxes) have been applied.        
        public double Total { get; private set; }

        //Property exposes the number of items in a ShoppingCart instance.
        public int Count
        {
            get { return this.ListOfProducts.Count; }
        }

        //Stores the Currency ISO-3 Code in which the ShoppingCart's transactions (operations) are happening. Each ShoppingCart instance must have a Currency ISO-3 Code.
        public string Currency_ISO3_Code { get; private set; }

        /*
            Class constructor initializes a ShoppingCart instance when provided a PriceCalculator instance and a Currency ISO-3 Code (string) as inputs.

            Does so by first Validating both the provided PriceCalculator instance and the Currency ISO-3 Code value. If valid, creates an empty List of 
            Product, stores the provided PriceCalculator instance, and stores the provided Currency ISO-3 Code.
        */
        public ShoppingCart(PriceCalculator priceCalculator, string Currency_ISO3_Code)
        {
            Validate(priceCalculator);
            Validate(Currency_ISO3_Code.ToUpper());
            this.ListOfProducts = new List<Product>();
            this.PriceCalculator = priceCalculator;
            this.Currency_ISO3_Code = Currency_ISO3_Code.ToUpper();
        }

        /*
            Adds the given Product instance to the ShoppingCart instance and updates (increments) the ShoppingCart's Total fields.
            Throws an ArgumentException if the given Product is null.
        */
        public void Add(Product product)
        {
            if (product == null)
            {
                throw new ArgumentException("Operation failed! Cannot add a null product to your shopping cart.");
            }
            else
            {
                this.ListOfProducts.Add(product);
                IncrementTotals(product);
            }
        }

        //Helper method increments the five Total fields when called. Gets called every time a Product is added to the ShoppingCart.
        private void IncrementTotals(Product product)
        {
            this.Subtotal += Math.Round(product.Price, 4);
            var BeforeTaxDiscounts = Math.Round(this.PriceCalculator.DiscountCalculator.BeforeTaxDiscountCalculator.Calculate(product), 4);
            this.TotalTax += Math.Round(this.PriceCalculator.TaxCalculator.CalculateTaxAmount(product.Price - BeforeTaxDiscounts), 4);
            this.TotalDiscount += Math.Round(this.PriceCalculator.DiscountCalculator.Calculate(product), 4);
            this.TotalAdditionalCosts += Math.Round(AdditionalCostsCalculator.CalculateAdditionalCosts(product), 4);
            this.Total += Math.Round(this.PriceCalculator.CalculatePrice(product), 4);
        }

        /*
            Removes the given Product from the ShoppingCart instance if the Product exists and updates (decrements) the ShoppingCart's total fields.
            Prints an error message if the product does not exist in the ShoppingCart isnatance.
        */
        public void Remove(Product product)
        {
            if (this.ListOfProducts.Contains(product))
            {
                this.ListOfProducts.Remove(product);
                DecrementTotals(product);
            }
            else
            {
                Console.WriteLine("Operation failed! The product you are trying to remove is not in your shopping cart...");
            }
        }

        //Helper method decrements the five Total fields when called. Gets called every time a Product is removed from the ShoppingCart.        
        private void DecrementTotals(Product product)
        {
            this.Subtotal -= Math.Round(product.Price, 4);
            var BeforeTaxDiscounts = Math.Round(this.PriceCalculator.DiscountCalculator.BeforeTaxDiscountCalculator.Calculate(product), 4);
            this.TotalTax -= Math.Round(this.PriceCalculator.TaxCalculator.CalculateTaxAmount(product.Price - BeforeTaxDiscounts), 4);
            this.TotalDiscount -= Math.Round(this.PriceCalculator.DiscountCalculator.Calculate(product), 4);
            this.TotalAdditionalCosts -= Math.Round(AdditionalCostsCalculator.CalculateAdditionalCosts(product), 4);
            this.Total -= Math.Round(this.PriceCalculator.CalculatePrice(product), 4);
        }

        //Clears all the Product items from the ShoppingCart instance.        
        public void Clear()
        {
            this.ListOfProducts.Clear();
        }

        /*
            Checks if the ShoppingCart instance contains the provided Product instance. 
            Returns true if it does or false if it does not.
        */
        public bool Contains(Product product)
        {
            if (this.ListOfProducts.Contains(product))
            {
                return true;
            }
            return false;
        }

        //Implementation of the IEnumerable<Product> GetEnumerator() method.        
        public IEnumerator<Product> GetEnumerator()
        {
            return this.ListOfProducts.GetEnumerator();
        }

        //Implementation of the IEnumerbale IEnumerable.GetEnumerator() method.        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        //Validates a given PriceCalculator instance. Throws an ArgumentException if the PriceCalculator instance is null.
        private void Validate(PriceCalculator priceCalculator)
        {
            if (priceCalculator == null)
            {
                throw new ArgumentException("Operation failed! Please make sure that the PriceCalculator you are providing is not null.");
            }
        }

        /*
            Validates the provided Currency ISO-3 Code string value. 
            
            Throws an ArgumentException if the string is null or if the Currency ISO-3 Code is not an internationally recognized code (not in the iso3_codes.csv file). 
        */
        private void Validate(string Currency_ISO3_Code)
        {
            if (Currency_ISO3_Code == null)
            {
                throw new ArgumentException("Invalid input! Please make sure that the Currency ISO-3 Code you are providing is not null.");
            }

            //where the file is stored on my local computer but feel free to change the path should you choose to form my project.
            var path = @"C:\Users\aiham\Price_Calculator_Kata\iso3_codes.csv";

            //Uses LINQ to enumerate over the query in the CSV file and look for any Currency ISO-3 Code matching the provided one.
            var hasCurrencyISO = File.ReadAllLines(path).Where(ISOCode => ISOCode.Equals(Currency_ISO3_Code)).Any();

            //If no matches were found, throws an ArgumentException guiding the user to the link containing all internationally recognized Currency Codes.
            if (!hasCurrencyISO)
            {
                throw new ArgumentException("Invalid input! Please make sure that the Currency ISO-3 Code you are passing is an internationally recognized code. Visit https://datahub.io/core/currency-codes#resource-codes-all for a complete list of all the internationally recognized Currency ISO-3 Codes.");
            }
        }
    }
}

