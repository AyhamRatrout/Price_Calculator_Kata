using System;

namespace Price_Calculator_Classes
{
    /*
        This class defines a PriceCalculator type. This type is used to Calculate the Price of a Product instance after applying diffierent
        Discount types and Taxes to it.

        Does so by creating a TaxCalculator instance, a IBeforeTaxDiscountCalculator instance, and an IAfterTaxDiscountCalculator instance.

        Has one public method, the CalculatePrice() method whcih takes a Product as a parameter and calculates its price after applying all Discounts and Tax.
    */
    public class PriceCalculator
    {
        //Stores an instance of TaxCalculator. Used to calculate Tax applied to a Product.
        public TaxCalculator TaxCalculator { get; private set; }

        //Stores an instance of an IBeforeTaxDiscountCalculator instance. Used to calculate Discounts to be applied before Tax.
        public IBeforeTaxDiscountCalculator BeforeTaxDiscountCalculator { get; private set; }

        //Stores an instance of an IAfterTaxDiscountCalculator. Used to calculate Discounts to be applied after Tax.
        public IAfterTaxDiscountCalculator AfterTaxDiscountCalculator { get; private set; }

        /*
            Class constructor initializes a PriceCalculator instance provided a RelativeDiscountList instance, a SpecialDiscountList instance,
            and a DiscountCombining enumeration.

            Validates both List instances before creating a TaxCalculator instance with the default Tax value, a IBeforeTaxDiscountCalculator instance
            with the the provided Discount Lists (depending on the provided DiscountCombining enumeration value), and an IAfterTaxDiscountCalculator 
            instance with the provided Discount List (also depending on the provided DiscountCombining enumeration value).
        */
        public PriceCalculator(RelativeDiscountList relativeDiscountList, SpecialDiscountList specialDiscountList, DiscountCombining discountCombining)
        {
            Validate(relativeDiscountList, specialDiscountList);
            this.TaxCalculator = new TaxCalculator();

            //If DiscountCombining is Additive, Additive Discount Calculators get created. If not, Multiplicative ones get created.
            if (discountCombining == DiscountCombining.Additive)
            {
                this.BeforeTaxDiscountCalculator = new BeforeTaxAdditiveDiscountCalculator(relativeDiscountList, specialDiscountList);
                this.AfterTaxDiscountCalculator = new AfterTaxAdditiveDiscountCalculator(relativeDiscountList, specialDiscountList);
            }
            else
            {
                this.BeforeTaxDiscountCalculator = new BeforeTaxMultiplicativeDiscountCalculator(relativeDiscountList, specialDiscountList);
                this.AfterTaxDiscountCalculator = new AfterTaxMultiplicativeDiscountCalculator(relativeDiscountList, specialDiscountList);
            }
        }

        /*
            Class constructor initializes a PriceCalculator instance provided a Tax percentage, sRelativeDiscountList instance, a SpecialDiscountList 
            instance, and a DiscountCombining enumeration.

            Validates both List instances before creating a TaxCalculator instance with the provided Tax value, a IBeforeTaxDiscountCalculator instance
            with the the provided Discount Lists (depending on the provided DiscountCombining enumeration value), and an IAfterTaxDiscountCalculator 
            instance with the provided Discount List (also depending on the provided DiscountCombining enumeration value).
        */
        public PriceCalculator(double Tax, RelativeDiscountList relativeDiscountList, SpecialDiscountList specialDiscountList, DiscountCombining discountCombining)
        {
            Validate(relativeDiscountList, specialDiscountList);
            this.TaxCalculator = new TaxCalculator(Tax);

            //If DiscountCombining is Additive, Additive Discount Calculators get created. If not, Multiplicative ones get created.
            if (discountCombining == DiscountCombining.Additive)
            {
                this.BeforeTaxDiscountCalculator = new BeforeTaxAdditiveDiscountCalculator(relativeDiscountList, specialDiscountList);
                this.AfterTaxDiscountCalculator = new AfterTaxAdditiveDiscountCalculator(relativeDiscountList, specialDiscountList);
            }
            else
            {
                this.BeforeTaxDiscountCalculator = new BeforeTaxMultiplicativeDiscountCalculator(relativeDiscountList, specialDiscountList);
                this.AfterTaxDiscountCalculator = new AfterTaxMultiplicativeDiscountCalculator(relativeDiscountList, specialDiscountList);
            }
        }

        /*
            Calculates and returns the Price of a given Product instance.

            Does so by retrieving the Product's base Price, deducting any Before Tax Discounts from the Price, calculating the Tax to be paid on the remaining
            Price, calculating any additional Discounts to be applied to the remaining Price, and finally adding any Additional Costs to the Price
            of the Product. Adjusts the Price accordingly and returns it to the user.
        */
        public double CalculatePrice(Product product)
        {
            var Price = product.Price;
            var BeforeTaxDiscounts = this.BeforeTaxDiscountCalculator.Calculate(product);
            var Tax = this.TaxCalculator.CalculateTaxAmount(Price - BeforeTaxDiscounts);
            var AfterTaxDiscounts = this.AfterTaxDiscountCalculator.Calculate(product, Price - BeforeTaxDiscounts);
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