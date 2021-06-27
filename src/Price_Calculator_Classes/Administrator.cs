using System;
using System.Collections.Generic;

namespace Price_Calculator_Classes
{
    //This class represents a store Administrator who is responsible for adding special discounts to products with specific UPC's
    //Made static as a store should have a single administrator who controls one copy of a special discount list shared between all registers.
    public static class Administrator
    {
        //Dictionary collection keeps track of all the special UPC's and their associated discount percentages.
        public static Dictionary<int, double> UPCDiscountList{get; private set;} = new Dictionary<int, double>();

        //Adds a special UPC and an associated discount amount to the special discount list. Validates the UPC and Discocunt values and checks
        //if a UPC already has an associated discount amount to avoid conflicts.
        public static void AddUPCToDiscountList(int UPC, double Discount)
        {
            Validate(UPC, Discount);
            UPCDiscountList.TryAdd(UPC, Discount);           
        }
        
        //Removes a UPC and its asscocitaed discount from the special discount list when called, if the UPC is in the list.
        public static void RemoveUPCFromDiscountList(int UPC)
        {
            if(UPCDiscountList.ContainsKey(UPC))
            {
                UPCDiscountList.Remove(UPC);
            }
            else
            {
                Console.WriteLine("Operation failed! The UPC you entered is not in the list...");
            }
        }

        //Helper method validates the UPC and Discount values when called. Throw an ArgumentException if either value is invalid.
        private static void Validate(int UPC, double Discount)
        {
            if(UPC <= 0 || Discount <= 0)
            {
                throw new ArgumentException("Invalid input! Please make sure that both the UPC and the Discount are greater than zero.");               
            }
        }

    }
}