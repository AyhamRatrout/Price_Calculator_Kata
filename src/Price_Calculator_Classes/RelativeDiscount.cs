using System;

namespace Price_Calculator_Classes
{
    /*
        This class represents a Relative Discount type. It allows the user to create Relative Discounts by
        providing the Discount percentage and the Precedence at which the Realtive Discount is applied.
    */
    public class RelativeDiscount
    {
        //Property stores and returns the Discount percentage associated with a RelativeDiscount instance.
        public double Discount { get; private set; }

        //Property stores and returns the Precedence at which a RelativeDiscount instance is applied. 
        public Precedence Precedence { get; private set; }

        /*
            Class constructor initializes a RelativeDiscount instance provided a Discount percentage and a 
            Precedence value.
            Validates the RelativeDiscount percentage before creating the RelativeDiscount instance.
        */
        public RelativeDiscount(double Discount, Precedence Precedence)
        {
            this.Discount = Discount;
            this.Precedence = Precedence;
            Validate(); //Validate method validates the given Discount percentage.
        }

        //Checks a RelativeDiscount's Discount percentage for validity. Throws an ArgumentException if invalid.
        private void Validate()
        {
            if (this.Discount < 0 || this.Discount > 100)
            {
                throw new ArgumentException("Invalid input! Please make sure that the Discount amount provided is greater than or equal to 0% and less than or equal to 100%");
            }
        }
    }
}