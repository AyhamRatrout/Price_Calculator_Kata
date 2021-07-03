using System;
using System.Collections.Generic;

namespace Price_Calculator_Classes
{
    public class PriceCalculator
    {
        public TaxCalculator TaxCalculator{get; private set;}
        public BeforeTaxDiscountCalculator BeforeTaxDiscountCalculator{get; private set;}
        public AfterTaxDiscountCalculator AfterTaxDiscountCalculator{get; private set;}

        public PriceCalculator(double Tax, RelativeDiscountList relativeDiscountList, SpecialDiscountList specialDiscountList)
        {
            this.TaxCalculator = new TaxCalculator(Tax);
            this.BeforeTaxDiscountCalculator = new BeforeTaxDiscountCalculator(relativeDiscountList, specialDiscountList);
            this.AfterTaxDiscountCalculator = new AfterTaxDiscountCalculator(relativeDiscountList, specialDiscountList);
        }

        public double CalculatePrice(Product product)
        {
            var Price = product.Price;
            var BeforeTaxDiscounts = this.BeforeTaxDiscountCalculator.Calculate(product);
            var Tax = this.TaxCalculator.CalculateTaxAmount(Price - BeforeTaxDiscounts);
            var AfterTaxDiscounts = this.AfterTaxDiscountCalculator.Calculate(Price - BeforeTaxDiscounts, product);
            var AdditionalCosts = AdditionalCostsCalculator.CalculateAdditionalCosts(product);
            return (Price - BeforeTaxDiscounts + Tax - AfterTaxDiscounts + AdditionalCosts);
        }
    }

}