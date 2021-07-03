using System;

namespace Price_Calculator_Classes
{
    public class BeforeTaxDiscountCalculator: IBeforeTaxCalculator
    {
        public BeforeTaxRelativeDiscountCalculator RelativeDiscountCalculator{get; private set;}
        public BeforeTaxSpecialDiscountCalculator SpecialDiscountCalculator{get; private set;}
        public BeforeTaxDiscountCalculator(RelativeDiscountList relativeDiscountList, SpecialDiscountList specialDiscountList)
        {
            Validate(relativeDiscountList, specialDiscountList);  
            this.RelativeDiscountCalculator = new BeforeTaxRelativeDiscountCalculator(relativeDiscountList);
            this.SpecialDiscountCalculator = new BeforeTaxSpecialDiscountCalculator(specialDiscountList);        
        }

        public double Calculate(Product product)
        {
            return (this.RelativeDiscountCalculator.Calculate(product) + this.SpecialDiscountCalculator.Calculate(product));
        }

        private void Validate(RelativeDiscountList relativeDiscountList, SpecialDiscountList specialDiscountList)
        {
            if(relativeDiscountList == null || specialDiscountList == null)
            {
                throw new ArgumentException("Invalid input! Please make sure that the RelativeDiscountList and the SpecialDiscountList you are providing are not null.");
            }
        }
    }
}