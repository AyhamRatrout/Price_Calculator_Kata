using System;

namespace Price_Calculator_Classes
{
    /*
        This class represents a BeforeTaxDiscountCalculator which is a calculator that calculates the Discounts to be applied
        to a given Product instance before applying the Tax (helps make Tax amount lower) to the Product instance.

        It implements the IBeforeTaxCalculator interface (an interface implemented by every calculator that operates before the Tax calculator)
        and implements its Calculate() method.
    */
    public class BeforeTaxDiscountCalculator : IBeforeTaxCalculator
    {
        /*
            Property stores a BeforeTaxRelativeDiscocuntCalculator (a calculator that calculates the relative discounts 
            to be applied to a Product before Taxes or any other Discounts). 
        */
        public BeforeTaxRelativeDiscountCalculator RelativeDiscountCalculator { get; private set; }

        /*
            Property stores a BeforeTaxSpecialDiscocuntCalculator (a calculator that calculates the special discounts 
            to be applied to a Product before Taxes or any other Discounts). 
        */
        public BeforeTaxSpecialDiscountCalculator SpecialDiscountCalculator { get; private set; }

        /*
            Class constructor initializes a BeforeTaxDiscountCalculator instance provided a RelativeDiscountList instance and a SpecialDiscountList
            instance (a list containing the relative discounts and another containing all the special discounts).

            Does so by creating a BeforeTaxRrelativeDiscountCalculator instance (with the provided RelativeDiscountList) and an
            AfterTaxSpecialDiscountCalculator instance (with the provided SpecialDiscountList).

            Validates both Lists (RelativeDiscountList and SpecialDiscocuntList) instances before creating a BeforeTaxDiscountCalculator instance.
        */
        public BeforeTaxDiscountCalculator(RelativeDiscountList relativeDiscountList, SpecialDiscountList specialDiscountList)
        {
            Validate(relativeDiscountList, specialDiscountList);
            this.RelativeDiscountCalculator = new BeforeTaxRelativeDiscountCalculator(relativeDiscountList);
            this.SpecialDiscountCalculator = new BeforeTaxSpecialDiscountCalculator(specialDiscountList);
        }

        /*
            Calculates and returns the total amount to be Discounted from a Product's Price before 
            applying any Taxes or other Discounts to the Product.
            An implementation of IAfterTaxCalculator's Calculate() method.
        */
        public double Calculate(Product product)
        {
            return (this.RelativeDiscountCalculator.Calculate(product) + this.SpecialDiscountCalculator.Calculate(product));
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