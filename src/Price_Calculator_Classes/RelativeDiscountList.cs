using System;
using System.Collections.Generic;
using System.Collections;

namespace Price_Calculator_Classes
{
    /*
        This class represents a custom Collection of RelativeDiscount items.

        The underlying structure to this Collection type is List<RelativeDiscount> and this class implements 
        the IEnumerable<RelativeDiscount> interface in order for it to become Enumerable.

        This class has some, but not all, of the List type capabilities (methods and properties) but it is 
        designed to serve this project only.
    */
    public class RelativeDiscountList : IEnumerable<RelativeDiscount>
    {
        //Private field of type List of RelativeDiscount represents the underlying structure to this custom Collection.
        private List<RelativeDiscount> DiscountList;

        //Property exposes the number of items in a RelativeDiscountList instance.
        public int Count
        {
            get { return this.DiscountList.Count; }
        }

        /*
            Class constructor takes no input and initializes a RelativeDiscountList instance by creating a 
            new List<RelativeDiscount> instance.
        */
        public RelativeDiscountList()
        {
            this.DiscountList = new List<RelativeDiscount>();
        }

        /*
            Adds a RelativeDiscount instance to the RelativeDiscountList instance or displays an error message 
            on the screen if the RelativeDiscount already exists in the List.
            Validates the RelativeDiscount before adding it.
        */
        public void Add(RelativeDiscount relativeDiscount)
        {
            Validate(relativeDiscount);
            if (!this.DiscountList.Contains(relativeDiscount))
            {
                this.DiscountList.Add(relativeDiscount);
            }
            else
            {
                Console.WriteLine("Invalid operation! The discount you are trying to add is already in the list.");
            }
        }

        /*
            Removes a RelativeDiscount instance from the RelativeDiscountList instance or displays an error 
            message to the screen if the RelativeDiscount does not exist in the List.
            Validates the RelativeDiscount before any removals.
        */
        public void Remove(RelativeDiscount relativeDiscount)
        {
            Validate(relativeDiscount);
            if (this.DiscountList.Contains(relativeDiscount))
            {
                this.DiscountList.Remove(relativeDiscount);
            }
            else
            {
                Console.WriteLine("Invalid operation! The discount you are trying to remove does not exist in the list.");
            }
        }

        /*
            Given RelativeDiscount instance, returns the Discount percentage associated with the instance.
            Returns 0 if no such RelativeDiscount exists in the List.
        */
        public double GetDiscountPercentage(RelativeDiscount relativeDiscount)
        {
            if (this.DiscountList.Contains(relativeDiscount))
            {
                return relativeDiscount.Discount;
            }
            return 0.00;
        }

        /*
            Checks if the RelativeDiscountList contains the given RelativeDiscount instance. 
            Returns true if it does or false if it does not.
        */
        public bool Contains(RelativeDiscount relativeDiscount)
        {
            if (this.DiscountList.Contains(relativeDiscount))
            {
                return true;
            }
            return false;
        }

        //Clears all the RelativeDiscocunt items from the RelativeDiscountList.
        public void Clear()
        {
            this.DiscountList.Clear();
        }

        //Implementation of the IEnumerable<RelativeDiscount> GetEnumerator() method.
        public IEnumerator<RelativeDiscount> GetEnumerator()
        {
            return this.DiscountList.GetEnumerator();
        }

        //Implementation of the IEnumerbale IEnumerable.GetEnumerator() method.
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        //Checks a RelativeDiscount instance for validity. Throws an ArgumentException if it is null.
        private void Validate(RelativeDiscount relativeDiscount)
        {
            if (relativeDiscount == null)
            {
                throw new ArgumentException("Invalid input! Please make sure that you are not providing a null RelativeDiscount instance.");
            }
        }
    }
}