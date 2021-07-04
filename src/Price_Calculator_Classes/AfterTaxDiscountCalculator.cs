using System;

namespace Price_Calculator_Classes
{
    /*
        This class represents an AfterTaxDiscountCalculator which is a calculator that calculates the Discount amount on a given product
        after applying the Tax (and any before-tax discounts) to the Product instance.

        It implements the IAfterTaxCalculator interface (an interface implemented by every calculator that operates after the Tax calculator)
        and implements its Calculate() method.
    */
    public class AfterTaxDiscountCalculator : IAfterTaxCalculator
    {
        /*
            Property stores an AfterTaxRelativeDiscocuntCalculator (a calculator that calculates the relative discounts 
            to be applied to a Product after tax). 
        */
        public AfterTaxRelativeDiscountCalculator RelativeDiscountCalculator { get; private set; }

        /*
            Property stores an AfterTaxSpecialDiscocuntCalculator (a calculator that calculates the special discounts 
            to be applied to a Product after tax). 
        */
        public AfterTaxSpecialDiscountCalculator SpecialDiscountCalculator { get; private set; }

        /*
            Class constructor initializes an AfterTaxDiscountCalculator instance provided a RelativeDiscountList instance and a SpecialDiscountList
            instance (a list containing the relative discounts and another containing all the special discounts).

            Does so by creating an AfterTaxRrelativeDiscountCalculator instance (with the provided RelativeDiscountList) and an
            AfterTaxSpecialDiscountCalculator instance (with the provided SpecialDiscountList).

            Validates both Lists (RelativeDiscountList and SpecialDiscocuntList) instance before creating an AfterTaxDiscountCalculator instance.
        */
        public AfterTaxDiscountCalculator(RelativeDiscountList relativeDiscountList, SpecialDiscountList specialDiscountList)
        {
            Validate(relativeDiscountList, specialDiscountList);
            this.RelativeDiscountCalculator = new AfterTaxRelativeDiscountCalculator(relativeDiscountList);
            this.SpecialDiscountCalculator = new AfterTaxSpecialDiscountCalculator(specialDiscountList);
        }

        /*
            Calculates and returns the total Discount amount to be applied to a Product after Tax.
            An implementation of IAfterTaxCalculator's Calculate() method.
        */
        public double Calculate(double Price, Product product)
        {
            return (this.RelativeDiscountCalculator.Calculate(Price, product) + this.SpecialDiscountCalculator.Calculate(Price, product));
        }

        //Validates the RelativeDiscountList and the SpecialDiscountList provided to the class cosntructor. Throws an ArgumentException if either is null.
        private void Validate(RelativeDiscountList relativeDiscountList, SpecialDiscountList specialDiscountList)
        {
            if (relativeDiscountList == null || specialDiscountList == null)
            {
                throw new ArgumentException("Invalid input! Please make sure that the RelativeDiscountList and the SpecialDiscountList you are providing are not null.");
            }
        }
    }
}