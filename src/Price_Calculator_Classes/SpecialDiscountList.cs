using System;
using System.Collections.Generic;

namespace Price_Calculator_Classes
{
    //This class represents a list of all the special discounts applied to specific products.
    public class SpecialDiscountList
    {
        //Dictionary collection keeps track of all the special UPC's and their associated discount percentages.
        public Dictionary<int, double> DiscountList {get; private set;}

        //Creates a SpecialDiscountList instance with and initializes an empty Dictioanry (DiscountList).
        public SpecialDiscountList()
        {
            this.DiscountList = new Dictionary<int, double>();            
        }

        /*
            Adds a UPC and its associated Discount to the DiscountList after validating both values.
            Uses the Dictionary's TryAdd method to avoid throwing an exception in the case of conflicts.
        */
        public void Add(int UPC, double Discount)
        {
            ValidateUPC(UPC);
            ValidateDiscount(Discount);
            this.DiscountList.TryAdd(UPC, Discount);            
        }

        /*
            Removes the UPC and its associated Discount from the DiscountList after checking whether the
            UPC (key) is actually in the DiscountList or not.
        */
        public void Remove(int UPC)
        {
            if(this.DiscountList.ContainsKey(UPC))
            {
                this.DiscountList.Remove(UPC);
            }
        }

        //Checks if the DiscountList contains the given key. Returns true if it does and false if otherwise.
        public bool ContainsKey(int UPC)
        {
            if(this.DiscountList.ContainsKey(UPC))
            {
                return true;
            }
            return false;
        }

        //Validates the passed in UPC value. Throws an ArgumentException if invalid.
        private void ValidateUPC(int UPC)
        {
            if(UPC <= 0)
            {
                throw new ArgumentException("Invalid input! Please make sure to enter a UPC that is greater than zero.");
            }
        }

        //Validates the passed in Discount value. Throws an ArgumentException if invalid.
        private void ValidateDiscount(double Discount)
        {
            if(Discount <= 0 || Discount > 100)
            {
                throw new ArgumentException("Invalid input! Please make sure to enter a Discount that is greater than 0% and less than 100%");
            }
        }
    }
}