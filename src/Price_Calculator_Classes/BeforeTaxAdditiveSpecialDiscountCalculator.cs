using System;
using Extension_Library;

namespace Price_Calculator_Classes
{
    /*
        This class represents a BeforeTaxAdditiveSpecialDiscountCalculator type. It is used to calculate the amount of SpecialDiscounts
        that have a Precendence of (to be applied) before Tax or any other Discounts and that are being applied Additively.

        To accomplish this, this class uses a List of all the SpecialDiscounts as well as a Filterer instance to find all the 
        SpecialDiscounts whose Precedence is before Tax and apply them to the Product provided Additively.

        Implements the ISpecialDiscountCalculator interface and provides implementations for its following members:
            1. SpecialDiscountList property.
            2. SpecialDiscountListFilterer property.
            3. Calulate(Product, double) method.
            4. Validate(SpecialDiscountList) method.      
    */
    public class BeforeTaxAdditiveSpecialDiscountCalculator : ISpecialDiscountCalculator
    {
        //Stores a List of all the SpecialDiscounts applied to a ShoppingCart instance. This List is provided by the user.                
        public SpecialDiscountList SpecialDiscountList { get; private set; }

        //Stores an instance of the SpecialDiscountListFilterer. Used to Filter SpecialDiscounts by Precedence.               
        public SpecialDiscountListFilterer Filterer { get; private set; }

        /*
            Class constructor initializes a BeforeTaxAdditiveSpecialDiscountCalculator instance provided a 
            List of all the SpecialDiscounts applied to a ShoppingCart instance.

            Validates the provided SpecialDiscountList before initializing a new SpecialDiscountListFilterer 
            instance and creating a new instance of this class.
        */
        public BeforeTaxAdditiveSpecialDiscountCalculator(SpecialDiscountList specialDiscountList)
        {
            Validate(specialDiscountList);
            this.Filterer = new SpecialDiscountListFilterer(specialDiscountList);
            this.SpecialDiscountList = this.Filterer.BeforeTaxSpecialDiscountList;
        }

        /*
            Calculates and returns the SpecialDiscount amounts to be applied to a Product before Tax, Additively.

            If the SpecialDiscount amounts are greater than the Discount Cap amount applied to this Product, returns the Discount 
            Cap amount. Otherwise, the SpecialDiscount amount is returned.
        */
        public double Calculate(Product product, double Price)
        {
            var specialDiscountAmount = 0.00;
            var discountCapAmount = DiscountCapCalculator.GetDiscountCap(product);

            foreach (var specialDiscount in this.SpecialDiscountList)
            {
                if (specialDiscount.UPC == product.UPC)
                {
                    specialDiscountAmount += Math.Round((Price * ArithmeticExtensions.PercentageToDecimal(specialDiscount.Discount)), 4);
                    if (specialDiscountAmount > discountCapAmount)
                    {
                        return discountCapAmount;
                    }
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