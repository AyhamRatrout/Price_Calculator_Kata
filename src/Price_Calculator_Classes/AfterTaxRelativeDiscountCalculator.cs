using System;
using Extension_Library;

namespace Price_Calculator_Classes
{
    /*
        This class represents an AfterTaxRelativeDiscountCalculator type. It is used to calculate the amount of relative Discounts
        that have a precendence (to be applied) after tax.

        To accomplish this, this class uses a List of all the relative discounts as well as a Filterer instance to find all the 
        Relative Discounts whose Precedence is after tax and apply them to the Product provided.

        Implements the IAfterTaxCalculator interface and provides an implementation for its Calculate() method.

        Implements the IRelativeDiscountCalculator interface and provides implementations to its RelativeDiscountList property,
        RelativeDiscountListFilterer property, and its Validate() method.
    */
    public class AfterTaxRelativeDiscountCalculator : IAfterTaxCalculator, IRelativeDiscountCalculator
    {
        //Stores a List of all the RelativeDiscounts applied to a ShoppingCart instance. This List is provided by the user.
        public RelativeDiscountList RelativeDiscountList { get; private set; }

        //Stores an instance of the RelativeDiscountListFilterer. Used to Filter RelativeDiscounts by Precedence.
        public RelativeDiscountListFilterer Filterer { get; private set; }

        /*
            Class constructor initializes an AfterTaxRelativeDiscountCalculator instance provided a 
            List of all the RelativeDiscounts applied to a ShoppingCart instance.

            Validates the provided RelativeDiscountList before initializing a new RelativeDiscountListFilterer 
            instance and creating a new instance of this class.
        */
        public AfterTaxRelativeDiscountCalculator(RelativeDiscountList relativeDiscountList)
        {
            Validate(relativeDiscountList);
            this.Filterer = new RelativeDiscountListFilterer(relativeDiscountList);
            this.RelativeDiscountList = this.Filterer.AfterTaxRelativeDiscountList;
        }

        /*
            Calculates and returns the RelativeDiscount amount to be applied to a Product after Tax.
            An implementation of IAfterTaxCalculator's Calculate() method.
        */
        public double Calculate(double Price, Product product)
        {
            var relativeDiscountAmount = 0.00;
            foreach (var relativeDiscount in this.RelativeDiscountList)
            {
                relativeDiscountAmount += (Price * ArithmeticExtensions.PercentageToDecimal(relativeDiscount.Discount));
            }
            return relativeDiscountAmount;
        }

        //Validates a given RelativeDiscountList instance. Throws an ArgumentException if it is null.
        public void Validate(RelativeDiscountList relativeDiscountList)
        {
            if (relativeDiscountList == null)
            {
                throw new ArgumentException("Invalid input! Please make sure that the RelativeDiscountList you are providing is not null.");
            }
        }
    }
}