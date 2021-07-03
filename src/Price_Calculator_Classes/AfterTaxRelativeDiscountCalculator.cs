using System;
using Extension_Library;

namespace Price_Calculator_Classes
{
    public class AfterTaxRelativeDiscountCalculator: IAfterTaxCalculator
    {
        public RelativeDiscountList RelativeDiscountList{get; private set;}
        public RelativeDiscountListFilterer Filterer{get; private set;}
        public AfterTaxRelativeDiscountCalculator(RelativeDiscountList relativeDiscountList)
        {
            Validate(relativeDiscountList);
            this.Filterer = new RelativeDiscountListFilterer(relativeDiscountList);
            this.RelativeDiscountList = this.Filterer.AfterTaxRelativeDiscountList;
        }

        public double Calculate(double Price, Product product)
        {
            var relativeDiscountAmount = 0.00;
            foreach(var relativeDiscount in this.RelativeDiscountList)
            {
                relativeDiscountAmount += (Price * ArithmeticExtensions.PercentageToDecimal(relativeDiscount.Discount));
            }   
            return relativeDiscountAmount;         
        }

        private void Validate(RelativeDiscountList relativeDiscountList)
        {
            if(relativeDiscountList == null)
            {
                throw new ArgumentException("Invalid input! Please make sure that the RelativeDiscountList you are providing is not null.");
            }
        }
    }
}