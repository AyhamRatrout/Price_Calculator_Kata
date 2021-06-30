using System;
using Extension_Library;

namespace Price_Calculator_Classes
{
    //This class takes care of calculating any Special Discounts applied to a Product. Implements the IDiscountCalculator interface.
    public class SpecialDiscountCalculator: IDiscountCalculator
    {
        //A SpecialDiscountCalculator must have a SpecialDiscountList instance where it keeps track of any special discounts applied to any Products.
        public SpecialDiscountList SpecialDiscountList {get; private set;}

        //Class constructor initializes a SpecialDiscountCalculator instance by taking a SpecialDiscountList instance as input.
        public SpecialDiscountCalculator(SpecialDiscountList SpecialDiscountList)
        {
            this.SpecialDiscountList = SpecialDiscountList;
            Validate(); //Validates the SpecialDiscountList before creating a SpecialDiscountCalculator instance.
        }
        
        //Calculates and returns the Special Discocunt amount for a given Product (if any).
        public double CalculateDiscountAmount(Product product)
        {
            if(this.SpecialDiscountList.ContainsKey(product.UPC))
            {
                return (product.Price * ArithmeticExtensions.PercentageToDecimal(this.SpecialDiscountList.DiscountList[product.UPC]));
            }
            return 0.00;
        }

        //Helper method validates the SpecialDiscountList instance passed to this class. Throws an ArgumentException if it is null.
        private void Validate()
        {
            if(this.SpecialDiscountList == null)
            {
                throw new ArgumentException("Operation failed! Please make sure that you are not providing a null SpecialDiscountList instance.");
            }
        }
    }
}