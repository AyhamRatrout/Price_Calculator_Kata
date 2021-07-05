using System;

namespace Price_Calculator_Classes
{
    /*
        This class represents a BeforeTaxMultiplicativeDiscountCalculator which is a calculator that calculates the Discounts to be applied
        to a given Product instance, Multiplicatively, before applying the Tax (helps make Tax amount lower) to the Product instance.

        Implements the IBeforeTaxDiscountCalculator interface and provides implementations for its following members:
            1. IRelativeDiscountCalculator property
            2. ISpecialDiscountCalculator property
            3. Calculate(Product) method
            4. Validate(RelativeDiscountList, SpecialDiscountList) method
    */
    public class BeforeTaxMultiplicativeDiscountCalculator : IBeforeTaxDiscountCalculator
    {
        /*
            Property stores a BeforeTaxMultiplicativeRelativeDiscocuntCalculator (a calculator that calculates the relative discounts 
            to be applied to a Product before Taxes or any other Discounts Multiplicatively). 
        */
        public IRelativeDiscountCalculator RelativeDiscountCalculator { get; private set; }

        /*
            Property stores a BeforeTaxMultiplicativeSpecialDiscocuntCalculator (a calculator that calculates the special discounts 
            to be applied to a Product before Taxes or any other Discounts Multiplicatively). 
        */
        public ISpecialDiscountCalculator SpecialDiscountCalculator { get; private set; }

        /*
            Class constructor initializes a BeforeTaxMultiplicativeDiscountCalculator instance provided a RelativeDiscountList instance and a SpecialDiscountList
            instance (a list containing the relative discounts and another containing all the special discounts).

            Does so by creating a BeforeTaxMultiplicativeRelativeDiscountCalculator instance (with the provided RelativeDiscountList) and an
            AfterTaxMultiplicativeSpecialDiscountCalculator instance (with the provided SpecialDiscountList).

            Validates both Lists (RelativeDiscountList and SpecialDiscocuntList) instances before creating a BeforeTaxMultiplicativeDiscountCalculator instance.
        */
        public BeforeTaxMultiplicativeDiscountCalculator(RelativeDiscountList relativeDiscountList, SpecialDiscountList specialDiscountList)
        {
            Validate(relativeDiscountList, specialDiscountList);
            this.RelativeDiscountCalculator = new BeforeTaxMultiplicativeRelativeDiscountCalculator(relativeDiscountList);
            this.SpecialDiscountCalculator = new BeforeTaxMultiplicativeSpecialDiscountCalculator(specialDiscountList);
        }

        /*
            Calculates and returns the total amount to be Discounted from a Product's Price before 
            applying any Taxes or other Discounts to the Product, Multiplicatively.

            If the total Discount amount is greater than the Discount Cap amount applied to this product, returns the Discount Cap amount. 
            Otherwise, the total Discount amount is returned.
        */
        public double Calculate(Product product)
        {
            var discountCapAmount = DiscountCapCalculator.GetDiscountCap(product);
            var relativeDiscounts = this.RelativeDiscountCalculator.Calculate(product, product.Price);
            var remainingPrice = (product.Price - relativeDiscounts);
            var specialDiscounts = this.SpecialDiscountCalculator.Calculate(product, remainingPrice);

            if ((relativeDiscounts + specialDiscounts) > discountCapAmount)
            {
                return discountCapAmount;
            }
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