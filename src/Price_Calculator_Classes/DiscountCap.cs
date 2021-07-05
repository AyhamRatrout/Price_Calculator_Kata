using System;

namespace Price_Calculator_Classes
{
    /*
        This class defines the DiscountCap type. A DiscountCap type sets a limit on how much can actually be discounted from the Price of a Product instance.

        A DiscountCap type is defined by two properties:
            1. Amount: defines the Cap amount and can be either a Percentage of the Price of a Product or an Absolute Cap amount.
            2. AmountType: defines whether the Amount property is intended to be a Percentage or Absolute.
    */
    public class DiscountCap
    {
        //Stores the DiscountCap amount (the maximum that can be discounted from a Product's Price). Can either be a Percentage or Absolute.
        public double Amount { get; private set; }

        //Stores an AmountType enumeration value. This indicates whether the Cap Amount provided is a Percentage or Absolute.
        public AmountType AmountType { get; private set; }

        /*
            Class constructor initializes a DiscountCap instance provided an Amount (doubel) and an Amount Type (AmountType).

            Validates the provided Amount for acceptability before creating an instance of this class.
        */
        public DiscountCap(double Amount, AmountType AmountType)
        {
            Validate(Amount, AmountType);
            this.AmountType = AmountType;
            this.Amount = Amount;
        }

        //Validates the provided Amount/AmountType combination for acceptability. Throws an ArgumentException for invalid value combinations. 
        private void Validate(double Amount, AmountType AmountType)
        {
            if (Amount < 0 || (AmountType == AmountType.Percentage && Amount > 100))
            {
                throw new ArgumentException("Invalid input! Please make sure that the Amount you are providing is no less than $0 if it is an Absolute amount, and that it is not less than 0% or greater than 100% if the Amount is a Percentage.");
            }
        }
    }
}