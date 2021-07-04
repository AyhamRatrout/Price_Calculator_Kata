using System;
using Extension_Library;

namespace Price_Calculator_Classes
{
    /*
        This class represents a BeforeTaxRelativeDiscountCalculator type. It is used to calculate the amount of Relative Discounts
        that have a precendence (to be applied) before Tax is applied.

        To accomplish this, this class uses a List of all the Relative Discounts as well as a Filterer instance to find all the 
        Relative Discounts whose Precedence is Before Tax and apply them to the Product provided.

        Implements the IBeforeTaxCalculator interface and provides an implementation for its Calculate() method.

        Implements the IRelativeDiscountCalculator interface and provides implementations to its RelativeDiscountList property,
        RelativeDiscountListFilterer property, and its Validate() method.
    */
    public class BeforeTaxRelativeDiscountCalculator : IBeforeTaxCalculator, IRelativeDiscountCalculator
    {
        //Stores a List of all the RelativeDiscounts applied to a ShoppingCart instance. This List is provided by the user.        
        public RelativeDiscountList RelativeDiscountList { get; private set; }

        //Stores an instance of the RelativeDiscountListFilterer. Used to Filter RelativeDiscounts by Precedence.        
        public RelativeDiscountListFilterer Filterer { get; private set; }

        /*
            Class constructor initializes a BeforeTaxRelativeDiscountCalculator instance provided a 
            List of all the RelativeDiscounts applied to a ShoppingCart instance.

            Validates the provided RelativeDiscountList before initializing a new RelativeDiscountListFilterer 
            instance and creating a new instance of this class.
        */
        public BeforeTaxRelativeDiscountCalculator(RelativeDiscountList relativeDiscountList)
        {
            Validate(relativeDiscountList);
            this.Filterer = new RelativeDiscountListFilterer(relativeDiscountList);
            this.RelativeDiscountList = this.Filterer.BeforeTaxRelativeDiscountList;
        }

        /*
            Calculates and returns the RelativeDiscount amount to be applied to a Product before Tax.
            An implementation of IBeforeTaxCalculator's Calculate() method.
        */
        public double Calculate(Product product)
        {
            var relativeDiscountAmount = 0.00;
            foreach (var relativeDiscount in this.RelativeDiscountList)
            {
                relativeDiscountAmount += (product.Price * ArithmeticExtensions.PercentageToDecimal(relativeDiscount.Discount));
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