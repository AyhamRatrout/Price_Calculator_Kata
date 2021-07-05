using System;

namespace Price_Calculator_Classes
{
    /*
        This class defines a PriceCalculator type. This type is used to Calculate the Price of a Product instance after applying different
        Discount types and Taxes to it.

        Does so by creating a TaxCalculator instance (which calculates the Tax amount) and a DiscountCalculator instance (which calculates the 
        total Discount amount).

        Has one public method, CalculatePrice(Product), whcih takes a Product as a parameter and calculates its price after applying all Discounts and Taxes to it.
    */
    public class PriceCalculator
    {
        //Stores an instance of TaxCalculator. Used to calculate Tax applied to a Product.
        public TaxCalculator TaxCalculator { get; private set; }

        //Stores an instance of DiscountCalculator. Used to calculate the Total Discounts applied to a Product.
        public DiscountCalculator DiscountCalculator { get; private set; }

        /*
            Class constructor initializes a PriceCalculator instance provided a RelativeDiscountList instance, a SpecialDiscountList instance,
            and a DiscountCombining enumeration.

            Validates both List instances before creating a TaxCalculator instance with the default Tax value, and a DiscountCalculator
            instance using the provided RelativeDiscountList instance, SpecialDiscountList instance, and DiscountCombining enumeration value.
        */
        public PriceCalculator(RelativeDiscountList relativeDiscountList, SpecialDiscountList specialDiscountList, DiscountCombining discountCombining)
        {
            Validate(relativeDiscountList, specialDiscountList);
            this.TaxCalculator = new TaxCalculator();
            this.DiscountCalculator = new DiscountCalculator(relativeDiscountList, specialDiscountList, discountCombining);
        }

        /*
            Class constructor initializes a PriceCalculator instance provided a Tax percentage, a RelativeDiscountList instance, a SpecialDiscountList 
            instance, and a DiscountCombining enumeration.

            Validates both List instances before creating a TaxCalculator instance with the provided Tax value, and a DiscountCalculator
            instance using the provided RelativeDiscountList instance, SpecialDiscountList instance, and DiscountCombining enumeration value.
        */
        public PriceCalculator(double Tax, RelativeDiscountList relativeDiscountList, SpecialDiscountList specialDiscountList, DiscountCombining discountCombining)
        {
            Validate(relativeDiscountList, specialDiscountList);
            this.TaxCalculator = new TaxCalculator(Tax);
            this.DiscountCalculator = new DiscountCalculator(relativeDiscountList, specialDiscountList, discountCombining);
        }

        /*
            Calculates and returns the Price of a given Product instance after applying the Different Discounts and Taxes it qualifies for.

            Does so by retrieving the Product's base Price, deducting any Before Tax Discounts from the Price which are used in calculating the Tax 
            to be paid on the Remaining Price, calculating the total Amount of Discounts applied to the Product instance, and finally adding any 
            Additional Costs to the Price of the Product. Adjusts the Price accordingly and returns it to the user.
        */
        public double CalculatePrice(Product product)
        {
            var Price = product.Price;
            var BeforeTaxDiscounts = Math.Round(this.DiscountCalculator.BeforeTaxDiscountCalculator.Calculate(product), 4);
            var Tax = Math.Round(this.TaxCalculator.CalculateTaxAmount(Price - BeforeTaxDiscounts), 4);
            var TotalDiscount = Math.Round(this.DiscountCalculator.Calculate(product), 4);
            var AdditionalCosts = Math.Round(AdditionalCostsCalculator.CalculateAdditionalCosts(product), 4);
            return Math.Round((Price - TotalDiscount + Tax + AdditionalCosts), 4);
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