using System;
using Extension_Library;

namespace Price_Calculator_Classes
{
    //This class takes care of calculating the Relative Discount applied to a product. Implements the IDiscountCalculator interface.
    public class RelativeDiscountCalculator: IDiscountCalculator
    {
        //Property keeps track of the relative discount percentage applied to a ShoppingCart instance.
        public double Discount{get; private set;}

        //Creates an instance of RelativeDiscountCalculator and sets Discount to its default value (zero percent).
        public RelativeDiscountCalculator()
        {
            this.Discount = 0.00;
        }

        //Creates an instance of RelativeDiscountCalculator and sets Discount to the passed in value.
        public RelativeDiscountCalculator(double Discount)
        {
            Validate(Discount); //validates the Discount value before assigning it to the Discount property.
            this.Discount = Discount;
        }
        
        //Calculates and returns the amount discounted from the price of a product.
        public double CalculateDiscountAmount(Product product)
        {
            return (product.Price * ArithmeticExtensions.PercentageToDecimal(this.Discount));
        }

        //Helper method validates the discount percentage. Throws an ArgumentException if invalid.
        private void Validate(double Discount)
        {
            if(Discount < 0 || Discount > 100)
            {
                throw new ArgumentException("Invalid input! Please make sure that the discount amount is greater than or equal to 0% and less than or equal to 100%");
            }
        }
    }
}