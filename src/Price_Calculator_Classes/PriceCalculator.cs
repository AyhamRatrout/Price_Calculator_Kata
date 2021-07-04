using System;
using System.Collections.Generic;

namespace Price_Calculator_Classes
{
    /*
        This class defines a PriceCalculator type. This type is used to Calculate the Price of a Product instance after applying diffierent
        Discount types and Taxes to it.

        Does so by creating a TaxCalculator instance, a BeforeTaxDiscountCalculator instance, and an AfterTaxDiscountCalculator instance.

        Has one method, the CalculatePrice() method whcih takes a Product as a parameter and calculates its price after applying all Discounts and Tax.
    */
    public class PriceCalculator
    {
        //Stores an instance of TaxCalculator. Used to calculate Tax applied to a Product.
        public TaxCalculator TaxCalculator { get; private set; }

        //Stores an instance of a BeforeTaxDiscountCalculator instance. Used to calculate Discounts to be applied before Tax.
        public BeforeTaxDiscountCalculator BeforeTaxDiscountCalculator { get; private set; }

        //Stores an instance of an AfterTaxDiscountCalculator. Used to calculate Discounts to be applied after Tax.
        public AfterTaxDiscountCalculator AfterTaxDiscountCalculator { get; private set; }

        /*
            Class constructor initializes a PriceCalculator instance provided a RelativeDiscountList instance and a SpecialDiscountList instance.

            Validates both instances before creating a TaxCalculator instance with the default Tax value, a BeforeTaxDiscountCalculator instance
            with the the provided Discount Lists, and an AfterTaxDiscountCalculator instance with the provided Discount Lists.
        */
        public PriceCalculator(RelativeDiscountList relativeDiscountList, SpecialDiscountList specialDiscountList)
        {
            Validate(relativeDiscountList, specialDiscountList);
            this.TaxCalculator = new TaxCalculator();
            this.BeforeTaxDiscountCalculator = new BeforeTaxDiscountCalculator(relativeDiscountList, specialDiscountList);
            this.AfterTaxDiscountCalculator = new AfterTaxDiscountCalculator(relativeDiscountList, specialDiscountList);
        }

        /*
            Class constructor initializes a PriceCalculator instance provided a Tax percentage, RelativeDiscountList instance, and a SpecialDiscountList instance.

            Validates both instances before creating a TaxCalculator instance with the provided Tax value, a BeforeTaxDiscountCalculator instance
            with the the provided Discount Lists, and an AfterTaxDiscountCalculator instance with the provided Discount Lists.
        */
        public PriceCalculator(double Tax, RelativeDiscountList relativeDiscountList, SpecialDiscountList specialDiscountList)
        {
            Validate(relativeDiscountList, specialDiscountList);
            this.TaxCalculator = new TaxCalculator(Tax);
            this.BeforeTaxDiscountCalculator = new BeforeTaxDiscountCalculator(relativeDiscountList, specialDiscountList);
            this.AfterTaxDiscountCalculator = new AfterTaxDiscountCalculator(relativeDiscountList, specialDiscountList);
        }

        /*
            Calculates and returns the Price of a given Product instance.

            Does so by retrieving the Product's base Price, deducting any Before Tax Discounts from the Price, calculating the Tax to be paid on the remaining
            Price, then calculating any additional Discounts to be applied to the remaining Price. Adjusts the Price and returns it to the user.
        */
        public double CalculatePrice(Product product)
        {
            var Price = product.Price;
            var BeforeTaxDiscounts = this.BeforeTaxDiscountCalculator.Calculate(product);
            var Tax = this.TaxCalculator.CalculateTaxAmount(Price - BeforeTaxDiscounts);
            var AfterTaxDiscounts = this.AfterTaxDiscountCalculator.Calculate(Price - BeforeTaxDiscounts, product);
            var AdditionalCosts = AdditionalCostsCalculator.CalculateAdditionalCosts(product);
            return (Price - BeforeTaxDiscounts + Tax - AfterTaxDiscounts + AdditionalCosts);
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