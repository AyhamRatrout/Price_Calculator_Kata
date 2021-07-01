using System;

namespace Price_Calculator_Classes
{
    /*
        This class allows the user to define a SpecialDiscount instance using a UPC, Discount, and Precedence.
        Implements the IValidate interface and overrides its only method.
    */
    public class SpecialDiscount: IValidate
    {
        //Each SpecialDiscount instance must have a UPC that defines the Products this Discount applies to.
        public int UPC{get; private set;} 
        
        //Each SpecialDiscount instance must have a Discount value (percentage) associated with it.
        public double Discount{get; private set;}
        
        //Each SpecialDiscount instance must have a Precedence which defines when the Discount is applied.
        public Precedence Precedence{get; private set;}

        /*
            Class constructor initializes a SpecialDiscount instance by taking a UPC value, a Discount 
            percentage, and a Precedence indicator.
            Validates its inputs before creating a SpecialDisccount instance.
        */
        public SpecialDiscount(int UPC, double Discount, Precedence Precedence)
        {
            this.UPC = UPC;
            this.Discount = Discount;
            this.Precedence = Precedence;
            Validate(); //used to Validate the values received by the constructror before creating an instance.
        }

        //Validates a SpecialDiscount properties for acceptability. Throws an ArgumentException if invalid.
        public void Validate()
        {
            if(this.UPC <= 0 || this.Discount < 0 || this.Discount > 100)
            {
                throw new ArgumentException("Invalid input! Please make sure that the UPC value is greater than zero and that the Discount Value is greater then or equal to 0% and less than or equal to 100%");
            }       
        }
    }
}