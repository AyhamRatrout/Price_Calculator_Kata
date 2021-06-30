using System;
using Extension_Library;

namespace Price_Calculator_Classes
{
    //This class is responsible for generating a purchase receipt for a given ShoppingCart instance.
    public class Receipt 
    {
        //Field that stores the ShoppingCart instance for a Receipt instance.
        private ShoppingCart ShoppingCart;

        /*
            Class constructor initializes a Receipt instance given a ShoppingCart instance as input.
            Validates the ShoppingCart instance before initializing a Receipt instance. 
        */
        public Receipt(ShoppingCart shoppingCart)
        {
            this.ShoppingCart = shoppingCart;
            Validate();
        }

        //Generates and prints the Receipt instance by calling the GenerateReceipt helper method.
        public void Print()
        {
            GenerateReceipt();
        }

        /*
            Helper method generates a Receipt by making a series of calls to various other helper methods that either generate a specific section
            of the receipt or do some formatting operations for aesethetic purposes.
        */
        private void GenerateReceipt()
        {
            GenerateHeader();
            Formatter.AddLine();
            Formatter.AddLine();
            GenerateColumns();
            Formatter.AddLine();
            GenerateTotals();
        }

        /*
            Helper method generates and displays the header portion of the Receipt. Calls the Formatter extension's AlignCenter method
            to align the header items in the center of the Console Window depending on its size.
        */
        private void GenerateHeader()
        {
            Formatter.AlignCenter("Foothill Technology Solutions' Stores");
            Formatter.AlignCenter("Customer Receipt");
            Formatter.AlignCenter(DateTime.Now.ToString());
        }

        /*
            Helper method generates and displays the Product and Price columns of the Receipt.
            Does this by enumerating over each item in the ShoppingCart and printing each product's Name and Price.
            Uses a the Formatter extension's AlignLeftRight method which aligns the product's name to the left of the Console Window and the 
            product's price to the right of the Console Window.
        */
        private void GenerateColumns()
        {
            Formatter.AlignLeftRight("Product", "Price");
            Formatter.AddLine();

            foreach(var product in this.ShoppingCart.ListOfProducts)
            {
                Formatter.AlignLeftRight(product.Name, "$" + product.Price.ToString());
            }
        }

       /*
            Helper method generates and displays the totals section of the Receipt.
            Does this by retrieving the various total properties in the ShoppingCart class.
            Ususes the Formatter extensions's AlignLeftRight method.
       */
       private void GenerateTotals()
        {
            Formatter.AlignLeftRight("Subtotal:", "$" + Math.Round(this.ShoppingCart.Subtotal, 2).ToString());
            Formatter.AlignLeftRight("Total Tax Amount:", "$" + Math.Round(this.ShoppingCart.TotalTax, 2).ToString());
            Formatter.AlignLeftRight("Total Discount Amount:", "$" + Math.Round(this.ShoppingCart.TotalDiscount, 2).ToString());
            Formatter.AlignLeftRight("Total:", "$" + Math.Round(this.ShoppingCart.Total, 2).ToString());
        }

        //Helper method validates that a Receipt's ShoppingCart field (provided by user) is not null. Throws an ArgumentException if it is.
        private void Validate()
        {
            if(this.ShoppingCart == null)
            {
                throw new NullReferenceException("Invalid input! Please make sure that the ShoppingCart you are passing is NOT null.");
            }
        }
    }
}