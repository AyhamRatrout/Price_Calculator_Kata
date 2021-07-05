using System;
using Extension_Library;

namespace Price_Calculator_Classes
{
    /*
        This class represents an AfterTaxAdditiveRelativeDiscountCalculator type. It is used to calculate the amount of Relative Discounts
        that have a precendence (to be applied) after Tax and that are being applied Additively.

        To accomplish this, this class uses a List of all the Relative Discounts as well as a Filterer instance to find all the 
        Relative Discounts whose Precedence is after Tax and apply them to the Product provided, Additively.

        Implements the IRelativeDiscountCalculator interface and provides implementations for its following members:
            1. RelativeDiscountList property.
            2. RelativeDiscountListFilterer property.
            3. Calulate(Product, double) method.
            4. Validate(RelativeDiscountList) method.

    */
    public class AfterTaxAdditiveRelativeDiscountCalculator : IRelativeDiscountCalculator
    {
        //Stores a List of all the RelativeDiscounts applied to a ShoppingCart instance. This List is provided by the user.
        public RelativeDiscountList RelativeDiscountList { get; private set; }

        //Stores an instance of the RelativeDiscountListFilterer. Used to Filter RelativeDiscounts by Precedence.
        public RelativeDiscountListFilterer Filterer { get; private set; }

        /*
            Class constructor initializes an AfterTaxAdditiveRelativeDiscountCalculator instance provided a 
            List of all the RelativeDiscounts applied to a ShoppingCart instance.

            Validates the provided RelativeDiscountList before initializing a new RelativeDiscountListFilterer 
            instance and creating a new instance of this class.
        */
        public AfterTaxAdditiveRelativeDiscountCalculator(RelativeDiscountList relativeDiscountList)
        {
            Validate(relativeDiscountList);
            this.Filterer = new RelativeDiscountListFilterer(relativeDiscountList);
            this.RelativeDiscountList = this.Filterer.AfterTaxRelativeDiscountList;
        }

        /*
            Calculates and returns the RelativeDiscount amount to be applied to a Product after Tax, Additively.

            If the RelativeDiscount amount is greater than the Discount Cap amount applied to this Product, returns the Discount 
            Cap amount. Otherwise, the RelativeDiscount amount is returned.
        */
        public double Calculate(Product product, double Price)
        {
            var relativeDiscountAmount = 0.00;
            var discountCapAmount = DiscountCapCalculator.GetDiscountCap(product);

            foreach (var relativeDiscount in this.RelativeDiscountList)
            {
                relativeDiscountAmount += Math.Round((Price * ArithmeticExtensions.PercentageToDecimal(relativeDiscount.Discount)), 4);
                if (relativeDiscountAmount > discountCapAmount)
                {
                    return discountCapAmount;
                }
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