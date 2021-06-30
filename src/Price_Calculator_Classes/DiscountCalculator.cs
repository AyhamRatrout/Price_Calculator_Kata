using System;

namespace Price_Calculator_Classes
{
    public class DiscountCalculator: IDiscountCalculator
    {
        
        //A DiscountCalculator instance must have a RelativeDiscountCalculator instance to calculate the relative discount applied to a product.
        public RelativeDiscountCalculator RelativeDiscountCalculator {get; private set;}

        //A DiscountCalculator instance must have a SpecialDiscountCalculator instance to calculate any special discounts applied to a product.
        public SpecialDiscountCalculator SpecialDiscountCalculator {get; private set;}

        /*
            Class constructor takes in a RelativeDiscountCalculator instance and a SpecialDiscountCalculator instance as input parameters.
            Validates that neither of those two input parameters are null before initializing a DiscountCalculator instance.
        */
        public DiscountCalculator(RelativeDiscountCalculator relativeDiscountCalculator, SpecialDiscountCalculator specialDiscountCalculator)
        {
            this.RelativeDiscountCalculator = relativeDiscountCalculator;
            this.SpecialDiscountCalculator = specialDiscountCalculator;
            Validate();
        }
        
        //Calculates and returns the total amount to be discounted from the price of a product.
        public double CalculateDiscountAmount(Product product)
        {
            return Math.Round((this.RelativeDiscountCalculator.CalculateDiscountAmount(product) + this.SpecialDiscountCalculator.CalculateDiscountAmount(product)), 2);
        }

        /*
            Helper method validates (checks) that a DiscountCalculator instance RelativeDiscountCalculator and the SpecialDiscountCalculator 
            properties are not null. Throws an ArgumentException if either one of those properties is null. 
        */
        private void Validate()
        {
            if(this.RelativeDiscountCalculator == null || this.SpecialDiscountCalculator == null)
            {
                throw new ArgumentException("Invalid input! Please make sure that you are not passing a null value when initializing an instance of this class.");
            }
        }
    }
}