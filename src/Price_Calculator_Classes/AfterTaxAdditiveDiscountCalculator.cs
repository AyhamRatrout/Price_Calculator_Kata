using System;

namespace Price_Calculator_Classes
{
    /*
        This class represents an AfterTaxAdditiveDiscountCalculator which is a calculator that calculates the Discount amount on a given product,
        Additively, after applying the Tax (and any before-tax discounts) to the Product instance.

        Implements the IAfterTaxDiscountCalculator interface and provides implementations for its following members:
            1. IRelativeDiscountCalculator property
            2. ISpecialDiscountCalculator property
            3. Calculate(Product, double) method
            4. Validate(RelativeDiscountList, SpecialDiscountList) method.

    */
    public class AfterTaxAdditiveDiscountCalculator : IAfterTaxDiscountCalculator
    {
        /*
            Property stores an AfterTaxAdditiveRelativeDiscocuntCalculator (a calculator that calculates the relative discounts 
            to be applied to a Product after tax, Additively). 
        */
        public IRelativeDiscountCalculator RelativeDiscountCalculator { get; private set; }

        /*
            Property stores an AfterTaxAdditiveSpecialDiscocuntCalculator (a calculator that calculates the special discounts 
            to be applied to a Product after tax, Additively). 
        */
        public ISpecialDiscountCalculator SpecialDiscountCalculator { get; private set; }

        /*
            Class constructor initializes an AfterTaxAdditiveDiscountCalculator instance provided a RelativeDiscountList instance and a SpecialDiscountList
            instance (a list containing the relative discounts and another containing all the special discounts).

            Does so by creating an AfterTaxAdditiveRrelativeDiscountCalculator instance (with the provided RelativeDiscountList) and an
            AfterTaxAdditiveSpecialDiscountCalculator instance (with the provided SpecialDiscountList).

            Validates both Lists (RelativeDiscountList and SpecialDiscocuntList) instance before creating an instance of this class.
        */
        public AfterTaxAdditiveDiscountCalculator(RelativeDiscountList relativeDiscountList, SpecialDiscountList specialDiscountList)
        {
            Validate(relativeDiscountList, specialDiscountList);
            this.RelativeDiscountCalculator = new AfterTaxAdditiveRelativeDiscountCalculator(relativeDiscountList);
            this.SpecialDiscountCalculator = new AfterTaxAdditiveSpecialDiscountCalculator(specialDiscountList);
        }

        /*
            Calculates and returns the total Discount amount to be applied to a Product after Tax, Additively.

            If the total Discount amount is greater than the Discount Cap amount applied to this product, it returns the Discount Cap amount.
            Otherwise, the total Discount amount is returned.
        */
        public double Calculate(Product product, double Price)
        {
            var discountCapAmount = DiscountCapCalculator.GetDiscountCap(product);
            var totalBeforeTaxDiscounts = Math.Round((this.RelativeDiscountCalculator.Calculate(product, Price) + this.SpecialDiscountCalculator.Calculate(product, Price)), 4);

            if (totalBeforeTaxDiscounts > discountCapAmount)
            {
                return discountCapAmount;
            }
            return totalBeforeTaxDiscounts;
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