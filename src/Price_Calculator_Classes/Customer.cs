using System;
using System.Collections.Generic;

namespace Price_Calculator_Classes
{
    public class Customer
    {
        //A PriceCalculator to calculate each customer's total purchases.
        public PriceCalculator PriceCalculator{get; private set;}
        
        //Represents a customer's shopping cart which they can add products to.
        public List<Product> ShoppingCart{get; private set;}


        //Class constructor creates a PriceCalculator instance and a List<Product> (shopping cart) instance when initializing a Customer instance.
        public Customer()
        {
            this.PriceCalculator = new PriceCalculator();
            this.ShoppingCart = new List<Product>();
        }

        //Adds a product to a customer's shopping cart.
        public void AddToCart(Product product)
        {
            this.ShoppingCart.Add(product);
        }

        //Removes a product from a cutomer's shopping if it exits in the cart.
        public void RemoveFromCart(Product product)
        {
            if(ShoppingCart.Contains(product))
            {
                ShoppingCart.Remove(product);
            }
            else
            {
                Console.WriteLine("Operation failed! The product you are trying to remove is not in your shopping cart...");
            }

        }

        //Enables a customer to apply a discount on all the items in their cart.
        public void ApplyDiscount(double Discount)
        {
            this.PriceCalculator.ApplyDiscount(Discount);
        }

        //Enables a customer to apply a custom tax amount to all the items in their cart.
        public void ApplyTax(double Tax)
        {
            this.PriceCalculator.ApplyTax(Tax);
        }

        //Generates a detailed report for every product in a customer's cart (detailing the product's name, UPC, price, tax amount, any discounts, and total after all adjustments).
        public void GenerateReport()
        {
            if(CartIsEmpty())
            {
                Console.WriteLine("Your shopping cart is empty!");
            }
            else
            {
                foreach(var product in this.ShoppingCart)
                {
                    this.PriceCalculator.GetReport(product);
                }
            }
        }

        //Prints a receipt for each item in a customer's shopping cart.
        public void PrintReceipt()
        {
            if(CartIsEmpty())
            {
                Console.WriteLine("Your shopping cart is empty!");
            }
            else
            {
                var receipt = new Receipt();
                receipt.GenerateReceipt(this);
            }                
        }

        //Checks if a customer's cart is empty. Returns true if it is or false if it is not empty.
        private bool CartIsEmpty()
        {
            if(this.ShoppingCart.Count == 0)
            {
                return true;                
            }
            return false;
        }
    }
}