using System;
using Extension_Library;

namespace Price_Calculator_Classes
{
    public class BeforeTaxRelativeDiscountCalculator: IBeforeTaxCalculator
    {
        public RelativeDiscountList RelativeDiscountList{get; private set;}
        private RelativeDiscountListFilterer Filterer;
        public BeforeTaxRelativeDiscountCalculator(RelativeDiscountList relativeDiscountList)
        {
            Validate(relativeDiscountList);
            this.Filterer = new RelativeDiscountListFilterer(relativeDiscountList);
            this.RelativeDiscountList = this.Filterer.BeforeTaxRelativeDiscountList;
        }

        public double Calculate(Product product)
        {
            var relativeDiscountAmount = 0.00;
            foreach(var relativeDiscount in this.RelativeDiscountList)
            {
                relativeDiscountAmount += (product.Price * ArithmeticExtensions.PercentageToDecimal(relativeDiscount.Discount));
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