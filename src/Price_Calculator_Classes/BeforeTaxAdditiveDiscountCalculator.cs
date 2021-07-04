using System;

namespace Price_Calculator_Classes
{
    /*
        This class represents a BeforeTaxAdditiveDiscountCalculator type, which is a calculator that calculates the Discounts to be applied
        to a given Product instance, Additively, before applying the Tax (helps make Tax amount lower) to the Product instance.

        Implements the IBeforeTaxDiscountCalculator interface and provides implementations for its following members:
            1. IRelativeDiscountCalculator property
            2. ISpecialDiscountCalculator property
            3. Calculate(Product) method
            4. Validate(RelativeDiscountList, SpecialDiscountList) method
    */
    public class BeforeTaxAdditiveDiscountCalculator : IBeforeTaxDiscountCalculator
    {
        /*
            Property stores a BeforeTaxAdditiveRelativeDiscocuntCalculator (a calculator that calculates the relative discounts 
            to be applied to a Product before Taxes or any other Discounts Additively). 
        */
        public IRelativeDiscountCalculator RelativeDiscountCalculator { get; private set; }

        /*
            Property stores a BeforeTaxAdditiveSpecialDiscocuntCalculator (a calculator that calculates the special discounts 
            to be applied to a Product before Taxes or any other Discounts Additively). 
        */
        public ISpecialDiscountCalculator SpecialDiscountCalculator { get; private set; }

        /*
            Class constructor initializes a BeforeTaxAdditiveDiscountCalculator instance provided a RelativeDiscountList instance and a SpecialDiscountList
            instance (a list containing the relative discounts and another containing all the special discounts).

            Does so by creating a BeforeTaxAdditiveRrelativeDiscountCalculator instance (with the provided RelativeDiscountList) and an
            AfterTaxAdditiveSpecialDiscountCalculator instance (with the provided SpecialDiscountList).

            Validates both Lists (RelativeDiscountList and SpecialDiscocuntList) instances before creating a BeforeTaxAdditiveDiscountCalculator instance.
        */
        public BeforeTaxAdditiveDiscountCalculator(RelativeDiscountList relativeDiscountList, SpecialDiscountList specialDiscountList)
        {
            Validate(relativeDiscountList, specialDiscountList);
            this.RelativeDiscountCalculator = new BeforeTaxAdditiveRelativeDiscountCalculator(relativeDiscountList);
            this.SpecialDiscountCalculator = new BeforeTaxAdditiveSpecialDiscountCalculator(specialDiscountList);
        }

        /*
            Calculates and returns the total amount to be Discounted from a Product's Price, Additively, before 
            applying any Taxes or other Discounts to the Product.
        */
        public double Calculate(Product product)
        {
            return (this.RelativeDiscountCalculator.Calculate(product, product.Price) + this.SpecialDiscountCalculator.Calculate(product, product.Price));
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