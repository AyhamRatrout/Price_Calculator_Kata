using System;

namespace Price_Calculator_Classes
{
    /*
        This class defines an AdditionalCost type which can be added to a Product instance.
        Each AdditionalCost instance is defined by a Description, an Amount, and an Amount Type.
    */
    public class AdditionalCost
    {
        //Stores the Description of an AdditionalCost instance (the sort of cost an AdditionalCost represents).
        public string Description { get; private set; }

        //Stores the amount of an AdditionalCost instance. The amount could be absolute or a percentage.
        public double Amount { get; private set; }

        //Stores the type of the Amount field (whether the amount is a percentage or absolute).
        public AmountType AmountType { get; private set; }

        /*
            Class constructor initializes an AdditionalCost instance provided a Description (string), an Amount (double), and an AmountType.
            Validates the passed in parameters before creating the instance using the Validate helper method.
        */
        public AdditionalCost(string Description, double Amount, AmountType AmountType)
        {
            this.Description = Description;
            this.Amount = Amount;
            this.AmountType = AmountType;
            Validate();
        }

        //Helper method validates the fields of an AdditionalCost instance. Throws an ArgumentException if one or more if the fieldds are invalid.
        private void Validate()
        {
            if (String.IsNullOrWhiteSpace(this.Description) || this.Amount <= 0 || (this.AmountType == AmountType.Percentage && this.Amount > 100))
            {
                throw new ArgumentException("Invalid input! Please make sure that the description is not empty or whitespace, the additional cost amount is not less than or equal to zero, and the additional cost amount is not greater than 100% if you choose it to be a percentage!");
            }
        }
    }
}