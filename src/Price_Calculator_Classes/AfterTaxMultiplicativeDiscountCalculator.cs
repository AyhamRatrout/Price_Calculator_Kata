using System;

namespace Price_Calculator_Classes
{
    /*
        This class represents an AfterTaxMultiplicativeDiscountCalculator which is a calculator that calculates the Discount amount on a given product
        Multiplicatively after applying the Tax (and any before-tax discounts) to the Product instance.

        Implements the IAfterTaxDiscountCalculator interface and provides implementations for its following members:
            1. IRelativeDiscountCalculator property
            2. ISpecialDiscountCalculator property
            3. Calculate(Product, double) method
            4. Validate(RelativeDiscountList, SpecialDiscountList) method.
    */
    public class AfterTaxMultiplicativeDiscountCalculator : IAfterTaxDiscountCalculator
    {
        /*
            Property stores an AfterTaxMultiplicativeRelativeDiscocuntCalculator (a calculator that calculates the relative discounts 
            to be applied to a Product after Tax, Multiplicatively). 
        */
        public IRelativeDiscountCalculator RelativeDiscountCalculator { get; private set; }

        /*
            Property stores an AfterTaxMultiplicativeSpecialDiscocuntCalculator (a calculator that calculates the special discounts 
            to be applied to a Product after Tax, Multiplicatively). 
        */
        public ISpecialDiscountCalculator SpecialDiscountCalculator { get; private set; }

        /*
            Class constructor initializes an AfterTaxMultiplicativeDiscountCalculator instance provided a RelativeDiscountList instance and a SpecialDiscountList
            instance (a list containing the relative discounts and another containing all the special discounts).

            Does so by creating an AfterTaxMultiplicativeRelativeDiscountCalculator instance (with the provided RelativeDiscountList) and an
            AfterTaxMultiplicativeSpecialDiscountCalculator instance (with the provided SpecialDiscountList).

            Validates both Lists (RelativeDiscountList and SpecialDiscocuntList) instance before creating an AfterTaxMultiplicativeDiscountCalculator instance.
        */
        public AfterTaxMultiplicativeDiscountCalculator(RelativeDiscountList relativeDiscountList, SpecialDiscountList specialDiscountList)
        {
            Validate(relativeDiscountList, specialDiscountList);
            this.RelativeDiscountCalculator = new AfterTaxAdditiveRelativeDiscountCalculator(relativeDiscountList);
            this.SpecialDiscountCalculator = new AfterTaxAdditiveSpecialDiscountCalculator(specialDiscountList);
        }

        /*
            Calculates and returns the total Discount amount to be applied to a Product after Tax, Multiplicatively.
        */
        public double Calculate(Product product, double Price)
        {
            var relativeDiscounts = this.RelativeDiscountCalculator.Calculate(product, Price);
            var remainingPrice = (Price - relativeDiscounts);
            var specialDiscounts = this.SpecialDiscountCalculator.Calculate(product, remainingPrice);
            return (relativeDiscounts + specialDiscounts);
        }

        //Validates the RelativeDiscountList and the SpecialDiscountList provided to the class cosntructor. Throws an ArgumentException if either is null.
        public void Validate(RelativeDiscountList relativeDiscountList, SpecialDiscountList specialDiscountList)
        {
            if (relativeDiscountList == null || specialDiscountList == null)
            {
                throw new ArgumentException("Invalid input! Please make sure that the RelativeDiscountList and the SpecialDiscountList you are providing are not null.");
            }
        }
    }
}