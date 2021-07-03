using System;
using Extension_Library;

namespace Price_Calculator_Classes
{
    public class BeforeTaxSpecialDiscountCalculator: IBeforeTaxCalculator
    {
        public SpecialDiscountList SpecialDiscountList{get; private set;}
        private SpecialDiscountListFilterer Filterer;
        public BeforeTaxSpecialDiscountCalculator(SpecialDiscountList specialDiscountList)
        {
            Validate(specialDiscountList);
            this.Filterer = new SpecialDiscountListFilterer(specialDiscountList);
            this.SpecialDiscountList = this.Filterer.BeforeTaxSpecialDiscountList;
        }

        public double Calculate(Product product)
        {
            var specialDiscountAmount = 0.00;
            foreach(var specialDiscount in this.SpecialDiscountList)
            {
                if(specialDiscount.UPC == product.UPC)
                {
                    specialDiscountAmount += (product.Price * ArithmeticExtensions.PercentageToDecimal(specialDiscount.Discount));
                }
            }
            return specialDiscountAmount;            
        }

        private void Validate(SpecialDiscountList specialDiscountList)
        {
            if(specialDiscountList == null)
            {
                throw new ArgumentException("Invalid input! Please make sure that the SpecialDiscountList you are providing is not null.");
            }
        }
    }
}