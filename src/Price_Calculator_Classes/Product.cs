using System;

namespace Price_Calculator_Classes
{
    public class Product
    {
        public string Name{get; private set;} //Each product has a name
        public int UPC{get; private set;} //Each product has a UPC
        public double Price{get; private set;} //Each product has a price

        //public double PriceAfterAdjustments{get;private set;}

        //Class constructor initializes a Product instance when provided a Name, UPC, and a Price
        public Product(string Name, int UPC, double Price)
        {
            this.Name = Name;
            this.UPC = UPC;
            this.Price = Math.Round(Price, 2);
            Validate(); //validates the values above before creating a Product instance
        }

        //Helper method checks a Products fields for validity. Throws an ArgumentException if not valid
        private void Validate()
        {
            if(!String.IsNullOrWhiteSpace(this.Name))
            {
                if(this.UPC > 0)
                {
                    if(this.Price > 0)
                    {
                        return;
                    }
                }
            }
            throw new ArgumentException("Invalid inputs! Please make sure that the product's name is not null, empty, or whitespace, the product's UPC is greater than zero, and the product's price is also greater than zero...");
        }
    }
}