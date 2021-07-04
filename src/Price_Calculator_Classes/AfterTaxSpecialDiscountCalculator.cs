using System;
using Extension_Library;

namespace Price_Calculator_Classes
{
    /*
        This class represents an AfterTaxSpecialDiscountCalculator type. It is used to calculate the amount of SpecialDiscounts
        that have a Precendence of (to be applied) after tax.

        To accomplish this, this class uses a List of all the SpecialDiscounts as well as a Filterer instance to find all the 
        SpecialDiscounts whose Precedence is after tax and apply them to the Product provided.

        Implements the IAfterTaxCalculator interface and provides an implementation for its Calculate() method.

        Implements the ISpecialDiscountCalculator interface and provides implementations to its SpecialDiscountList property,
        SpecialDiscountListFilterer property, and its Validate() method.
    */
    public class AfterTaxSpecialDiscountCalculator : IAfterTaxCalculator, ISpecialDiscountCalculator
    {
        //Stores a List of all the SpecialDiscounts applied to a ShoppingCart instance. This List is provided by the user.        
        public SpecialDiscountList SpecialDiscountList { get; private set; }

        //Stores an instance of the SpecialDiscountListFilterer. Used to Filter SpecialDiscounts by Precedence.        
        public SpecialDiscountListFilterer Filterer { get; private set; }

        /*
            Class constructor initializes an AfterTaxSpecialDiscountCalculator instance provided a 
            List of all the SpecialDiscounts applied to a ShoppingCart instance.

            Validates the provided SpecialDiscountList before initializing a new SpecialDiscountListFilterer 
            instance and creating a new instance of this class.
        */
        public AfterTaxSpecialDiscountCalculator(SpecialDiscountList specialDiscountList)
        {
            Validate(specialDiscountList);
            this.Filterer = new SpecialDiscountListFilterer(specialDiscountList);
            this.SpecialDiscountList = this.Filterer.AfterTaxSpecialDiscountList;
        }

        /*
            Calculates and returns the SpecialDiscount amounts to be applied to a Product after Tax.
            An implementation of IAfterTaxCalculator's Calculate() method.
        */
        public double Calculate(double Price, Product product)
        {
            var specialDiscountAmount = 0.00;
            foreach (var specialDiscount in this.SpecialDiscountList)
            {
                if (specialDiscount.UPC == product.UPC)
                {
                    specialDiscountAmount += (Price * ArithmeticExtensions.PercentageToDecimal(specialDiscount.Discount));
                }
            }
            return specialDiscountAmount;
        }

        //Validates a given SpecialDiscountList instance. Throws an ArgumentException if it is null.
        public void Validate(SpecialDiscountList specialDiscountList)
        {
            if (specialDiscountList == null)
            {
                throw new ArgumentException("Invalid input! Please make sure that the SpecialDiscountList you are providing is not null.");
            }
        }
    }
}