using System;
using Extension_Library;

namespace Price_Calculator_Classes
{
    public class DiscountCalculator
    {
        //Property and backing field that keep track of the relative discount percentage decided by the customer.
        private double _Discount;
        public double Discount
        {
            get {return this._Discount;} 
            set 
            {
                this._Discount = value;
                Validate(); //validates the value of the discount percentage a customer sets.
            }
        }

        //Creates an instance of a DiscountCalculator with the Discount default value.
        public DiscountCalculator()
        {
            this._Discount = 0.00;
        }

        //Calculates the total discount amount applied to a product (relative and special discounts)
        public double CalculateTotalDiscountAmount(Product product)
        {
            return Math.Round((CalculateRelativeDiscountAmount(product) + CalculateUPCSpecificDiscountAmount(product)), 2);
            
        }

        //Calculates and returns the relative discount (applied by a customer) for a product
        public double CalculateRelativeDiscountAmount(Product product)
        {
            return (product.Price * ArithmeticExtensions.PercentageToDecimal(this._Discount));
        }

        //Calculates and returns any special discounts (UPC specific discounts) a product might qualify for.
        public double CalculateUPCSpecificDiscountAmount(Product product)
        {
            if(Administrator.UPCDiscountList.ContainsKey(product.UPC))
            {
                return (product.Price * ArithmeticExtensions.PercentageToDecimal(Administrator.UPCDiscountList[product.UPC]));
            }
            else
            {
                return 0;
            } 
        }

        //Helper method validates a Discount percentage is acceptable. Throws an argument exception if it is not.
        private void Validate()
        {
            if(this._Discount < 0 || this._Discount > 100)
            {
                throw new ArgumentException("Invalid input! Please make sure that the discount amount is greater than or equal to 0% and less than or equal to 100%");
            }
        }
    }
}