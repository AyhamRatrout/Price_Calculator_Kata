using System;
using System.Collections;
using System.Collections.Generic;

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

        /*
            Class constructor initializes a ShoppingCart instance when provided a PriceCalculator instance as input.

            Does so by first Validating the provided PriceCalculator instance. If valid, creates an empty List of 
            Product and stores the provided PriceCalculator instance.
        */
        public ShoppingCart(PriceCalculator priceCalculator)
        {
            Validate(priceCalculator);
            this.ListOfProducts = new List<Product>();
            this.PriceCalculator = priceCalculator;
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
            this.Subtotal += product.Price;
            var BeforeTaxDiscounts = this.PriceCalculator.BeforeTaxDiscountCalculator.Calculate(product);
            this.TotalTax += this.PriceCalculator.TaxCalculator.CalculateTaxAmount(product.Price - BeforeTaxDiscounts);
            this.TotalDiscount += (BeforeTaxDiscounts + this.PriceCalculator.AfterTaxDiscountCalculator.Calculate(product.Price - BeforeTaxDiscounts, product));
            this.TotalAdditionalCosts += AdditionalCostsCalculator.CalculateAdditionalCosts(product);
            this.Total += this.PriceCalculator.CalculatePrice(product);
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
            this.Subtotal -= product.Price;
            var BeforeTaxDiscounts = this.PriceCalculator.BeforeTaxDiscountCalculator.Calculate(product);
            this.TotalTax -= this.PriceCalculator.TaxCalculator.CalculateTaxAmount(product.Price - BeforeTaxDiscounts);
            this.TotalDiscount -= BeforeTaxDiscounts + this.PriceCalculator.AfterTaxDiscountCalculator.Calculate(product.Price - BeforeTaxDiscounts, product);
            this.TotalAdditionalCosts -= AdditionalCostsCalculator.CalculateAdditionalCosts(product);
            this.Total -= this.PriceCalculator.CalculatePrice(product);
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
    }
}

