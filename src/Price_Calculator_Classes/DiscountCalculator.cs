using System;

namespace Price_Calculator_Classes
{
    /*
        This class defines a DiscountCalculator type. A DiscountCalculator is used to calculate the Total Discocunt Amounts applied to a given Product
        instance both Before and After Tax and either Multiplicatively or Additively, whichever the user chooses.

        To accomplish this, this class uses an IBeforeTaxDiscountCalculator instance and an IAfterTaxDiscountCalculator instance which can be initialized to
        become either Additive or Multiplicative Before/AfterTaxDiscountCalculators. The actual calculation happens inside the Calculate(Product) method, which
        calculates the BeforeTaxDiscounts and the AfterTaxDiscounts, adds the two together, and returns their result.
    */
    public class DiscountCalculator
    {
        //Stores an instance of an IBeforeTaxDiscountCalculator instance. Used to calculate Discounts to be applied before Tax.
        public IBeforeTaxDiscountCalculator BeforeTaxDiscountCalculator { get; private set; }

        //Stores an instance of an IAfterTaxDiscountCalculator. Used to calculate Discounts to be applied after Tax.
        public IAfterTaxDiscountCalculator AfterTaxDiscountCalculator { get; private set; }

        /*
            Class constructor initializes a DiscountCalculator instance provided a RelativeDiscountList instance, a SpecialDiscountList instance,
            and a DiscountCombining enumeration value.

            Validates both List instances before creating an IBeforeTaxDiscountCalculator instance with the the provided Discount Lists (depending 
            on the provided DiscountCombining enumeration value), and an IAfterTaxDiscountCalculator instance with the provided Discount List 
            (also depending on the provided DiscountCombining enumeration value).
        */
        public DiscountCalculator(RelativeDiscountList relativeDiscountList, SpecialDiscountList specialDiscountList, DiscountCombining discountCombining)
        {
            Validate(relativeDiscountList, specialDiscountList);
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
            Calculates and returns the Total Discocunt amounts (both Relative and Special, Before-Tax and After-Tax) applied to the given Product instance. 
            
            If the Total Discount amount is greater than the DiscountCapAmount applied to this Product, returns the DiscountCapAmount applied to the Product
            instance. Otherwise, the Total Discount Amount is returned.
        */
        public double Calculate(Product product)
        {
            var discountCapAmount = DiscountCapCalculator.GetDiscountCap(product);
            var totalDiscounts = this.BeforeTaxDiscountCalculator.Calculate(product);

            if (totalDiscounts > discountCapAmount)
            {
                return discountCapAmount;
            }

            else
            {
                totalDiscounts += this.AfterTaxDiscountCalculator.Calculate(product, product.Price - totalDiscounts);
                if (totalDiscounts > discountCapAmount)
                {
                    return discountCapAmount;
                }
            }
            return totalDiscounts;
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