using System;
using Extension_Library;

namespace Price_Calculator_Classes
{
    /*
        This class represents an AfterTaxMultiplicativeSpecialDiscountCalculator type. It is used to calculate the amount of SpecialDiscounts
        that have a Precendence of (to be applied) after Tax and that are being applied to a Product Multiplicatively.

        To accomplish this, this class uses a List of all the SpecialDiscounts as well as a Filterer instance to find all the 
        SpecialDiscounts whose Precedence is after Tax and apply them to the Product provided Multiplicatively.

        Implements the ISpecialDiscountCalculator interface and provides implementations for its following members:
            1. SpecialDiscountList property.
            2. SpecialDiscountListFilterer property.
            3. Calulate(Product, double) method.
            4. Validate(SpecialDiscountList) method.
    */
    public class AfterTaxMultiplicativeSpecialDiscountCalculator : ISpecialDiscountCalculator
    {
        //Stores a List of all the SpecialDiscounts applied to a ShoppingCart instance. This List is provided by the user.        
        public SpecialDiscountList SpecialDiscountList { get; private set; }

        //Stores an instance of the SpecialDiscountListFilterer. Used to Filter SpecialDiscounts by Precedence.        
        public SpecialDiscountListFilterer Filterer { get; private set; }

        /*
            Class constructor initializes an AfterTaxMultiplicativeSpecialDiscountCalculator instance provided a 
            List of all the SpecialDiscounts applied to a ShoppingCart instance.

            Validates the provided SpecialDiscountList before initializing a new SpecialDiscountListFilterer 
            instance and creating a new instance of this class.
        */
        public AfterTaxMultiplicativeSpecialDiscountCalculator(SpecialDiscountList specialDiscountList)
        {
            Validate(specialDiscountList);
            this.Filterer = new SpecialDiscountListFilterer(specialDiscountList);
            this.SpecialDiscountList = this.Filterer.AfterTaxSpecialDiscountList;
        }

        /*
            Calculates and returns the SpecialDiscount amounts to be applied to a Product after Tax, Multiplicatively.

            If the SpecialDiscount amounts are greater than the Discount Cap amount applied to this Product, returns the Discount 
            Cap amount. Otherwise, the SpecialDiscount amount is returned.
        */
        public double Calculate(Product product, double Price)
        {
            var specialDiscountAmount = 0.00;
            var totalSpecialDiscountAmount = 0.00;
            var discocuntCapAmount = DiscountCapCalculator.GetDiscountCap(product);

            foreach (var specialDiscount in this.SpecialDiscountList)
            {
                if (specialDiscount.UPC == product.UPC)
                {
                    specialDiscountAmount = Math.Round((Price * ArithmeticExtensions.PercentageToDecimal(specialDiscount.Discount)), 4);
                    Price -= specialDiscountAmount;
                    totalSpecialDiscountAmount += specialDiscountAmount;

                    if (totalSpecialDiscountAmount > discocuntCapAmount)
                    {
                        return discocuntCapAmount;
                    }
                }
            }
            return Math.Round(totalSpecialDiscountAmount, 4);
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