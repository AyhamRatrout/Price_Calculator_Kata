using System;

namespace Price_Calculator_Classes
{
    public class Product
    {
        public string Name{get; set;}
        public int UPC{get; set;}
        public double PriceBeforeTax{get; set;}
        public double PriceAfterTax{get; set;}

        //Initializes a Product instance by passing in a Name (string), UPC (int), and Price (double)
        public Product(string Name, int UPC, double PriceBeforeTax)
        {
            this.Name = Name;
            this.UPC = UPC;
            this.PriceBeforeTax = Math.Round(ValidatePrice(PriceBeforeTax), 2); //Validates the price the user passes then rounds it to two decimal digits if valid
        }

        //Helper method validates the price the user passes for a product. If the price is invalid, throws an ArgumentException
        private double ValidatePrice(double Price)
        {
            if(Price <= 0)
            {
                throw new ArgumentException("Invalid input! All products must have a price greater than zero...");
            }

            return Price;

        }
    }
}