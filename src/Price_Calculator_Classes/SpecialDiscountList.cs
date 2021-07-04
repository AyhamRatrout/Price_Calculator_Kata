using System;
using System.Collections;
using System.Collections.Generic;

namespace Price_Calculator_Classes
{
    /*
        This class represents a custom Collection of SpecialDiscount items.

        The underlying structure to this Collection type is List<SpecialDiscount> and this class implements 
        the IEnumerable<SpecialDiscount> interface in order for it to become Enumerable.

        This class has some, but not all, of the List type capabilities (methods and properties) but it is 
        designed to serve this project only.
    */
    public class SpecialDiscountList : IEnumerable<SpecialDiscount>
    {
        //Private field of type List of SepcialDiscount represents the underlying structure to this custom Collection.
        private List<SpecialDiscount> DiscountList;

        //Property exposes the number of items in a SpecialDiscountList instance.
        public int Count
        {
            get { return this.DiscountList.Count; }
        }

        /*
            Class constructor takes no input and initializes a SpecialDiscountList instance by creating a 
            new List<SpecialDiscount> instance.
        */
        public SpecialDiscountList()
        {
            this.DiscountList = new List<SpecialDiscount>();
        }

        /*
            Adds a SpecialDiscount instance to the SpecialDiscountList instance or displays an error message 
            on the screen if the SpecialDiscount already exists in the List.
            Validates the SpecialDiscount before adding it.
        */
        public void Add(SpecialDiscount specialDiscount)
        {
            Validate(specialDiscount);
            if (!this.DiscountList.Contains(specialDiscount))
            {
                this.DiscountList.Add(specialDiscount);
            }
            else
            {
                Console.WriteLine("Invalid operation! The discount you are trying to add is already in the list.");
            }
        }

        /*
            Removes a SpecialDiscount instance from the SpecialDiscountList instance or displays an error 
            message to the screen if the SpecialDiscount does not exist in the List.
            Validates the SpecialDiscount before any removals.
        */
        public void Remove(SpecialDiscount specialDiscount)
        {
            Validate(specialDiscount);
            if (this.DiscountList.Contains(specialDiscount))
            {
                this.DiscountList.Remove(specialDiscount);
            }
            else
            {
                Console.WriteLine("Invalid operation! The discount you are trying to remove does not exist in the list.");
            }
        }

        /*
            Checks if the SpecialDiscountList contains a SpecialDiscount with the given UPC. 
            Returns true if it does or false if it does not.
        */
        public bool Contains(int UPC)
        {
            foreach (var specialDiscount in this.DiscountList)
            {
                if (specialDiscount.UPC == UPC)
                {
                    return true;
                }
            }
            return false;
        }

        /*
            Given a UPC, returns the Discount percentage associated with this UPC.
            Returns 0 if no such UPC exists in the List.
        */
        public double GetDiscountPercentage(int UPC)
        {
            foreach (var specialDiscount in this.DiscountList)
            {
                if (specialDiscount.UPC == UPC)
                {
                    return specialDiscount.Discount;
                }
            }
            return 0.00;
        }

        //Clears all the SpecialDiscocunt items from the SpecialDiscountList.
        public void Clear()
        {
            this.DiscountList.Clear();
        }

        //Implementation of the IEnumerable<SpecialDiscount> GetEnumerator() method.
        public IEnumerator<SpecialDiscount> GetEnumerator()
        {
            return this.DiscountList.GetEnumerator();
        }

        //Implementation of the IEnumerbale IEnumerable.GetEnumerator() method.
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        //Checks a SpecialDiscount instance for validity. Throws an ArgumentException if it is null.
        private void Validate(SpecialDiscount specialDiscount)
        {
            if (specialDiscount == null)
            {
                throw new ArgumentException("Invalid input! Please make sure that you are not providing a null SpecialDiscount instance.");
            }
        }
    }
}