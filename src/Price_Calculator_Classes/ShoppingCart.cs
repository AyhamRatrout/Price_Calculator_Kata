using System;
using System.Collections.Generic;

namespace Price_Calculator_Classes
{
    //This class represents a shopping cart which a buyer can add products to or remove exisitng products from.
    public class ShoppingCart
    {

        //List of Product that keeps track of the Products in a shopping cart instance.
        public List<Product> ListOfProducts {get; private set;}

        //A ShoppingCart instance needs a PriceCalculator instance to updates the total when a Product is added to or removed from the cart.
        public PriceCalculator PriceCalculator{get; private set;}

        //Keeps track of the total price of all the products in a shopping cart instance before any adjustments are made.
        public double Subtotal{get; private set;}
        
        //Keeps track of the total tax to be paid on a ShoppingCart's products.
        public double TotalTax{get; private set;}
        
        //Keeps track of the total discount amounts applied to a ShoppingCart's products.
        public double TotalDiscount{get; private set;}
        
        //Keeps track of the Total amount to be paid on a ShoppingCart instance after adjustments have been applied.
        public double Total{get; private set;}

        /*
            Class constructor initializes a ShoppingCart instance by taking in a PriceCalculator instance as input and creating an empty List of
            Products. Validates the PriceCalculator instance before creating the ShoppingCart instance.
        */
        public ShoppingCart(PriceCalculator priceCalculator)
        {
            this.PriceCalculator = priceCalculator;
            ValidateCalculator();
            this.ListOfProducts = new List<Product>();
        }

        /*
            Adds a product to a shopping cart instance and updates the ShoppingCart's Total fields.
            Throws an ArgumentException if the product is null.
        */
        public void Add(Product product)
        {
            if(product == null)
            {
                throw new ArgumentException("Operation failed! Cannot add a null product to your shopping cart.");
            }
            else
            {
                this.ListOfProducts.Add(product);
                IncrementTotals(product);
            }
        }

        /*
            Removes a product from a shopping cart instance if the product exists and updates the ShoppingCart's total fields.
            Prints an error message if the product does not exist.
        */
        public void Remove(Product product)
        {
            if(this.ListOfProducts.Contains(product))
            {
                this.ListOfProducts.Remove(product);
                DecrementTotals(product);
            }
            else
            {
                Console.WriteLine("Operation failed! The product you are trying to remove is not in your shopping cart...");
            }
        }

        //Helper method increments the four Total fields when called. Gets called every time a Product is added to the ShoppingCart.
        private void IncrementTotals(Product product)
        {
            this.Subtotal += product.Price;
            this.TotalTax += this.PriceCalculator.TaxCalculator.CalculateTaxAmount(product);
            this.TotalDiscount += this.PriceCalculator.DiscountCalculator.CalculateDiscountAmount(product);
            this.Total += this.PriceCalculator.CalculatePrice(product);

        }

        //Helper method decrements the four Total fields when called. Gets called every time a Product is removed from the ShoppingCart.
        private void DecrementTotals(Product product)
        {
            this.Subtotal -= product.Price;
            this.TotalTax -= this.PriceCalculator.TaxCalculator.CalculateTaxAmount(product);
            this.TotalDiscount -= this.PriceCalculator.DiscountCalculator.CalculateDiscountAmount(product);
            this.Total -= this.PriceCalculator.CalculatePrice(product);
        }

        /*
            Helper method validates the PriceCalculator instance passed in to a ShoppingCart instance before creating one.
            Throws an ArgumentException if the PriceCalculator is null.
        */
        private void ValidateCalculator()
        {
            if(this.PriceCalculator == null)
            {
                throw new ArgumentException("Operation failed! Please make sure that you are not providing a null PriceCalculator instance.");
            }
        }
    }
}