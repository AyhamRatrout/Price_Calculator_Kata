using System;
using System.Collections;
using System.Collections.Generic;

namespace Price_Calculator_Classes
{
    /*
        This class represents a custom Collection of AdditionalCost items (instances).

        The underlying structure to this Collection type is List<AdditionalCost> and this class implements 
        the IEnumerable<AdditionalCost> interface in order for it to become Enumerable.

        This class has some, but not all, of the List type capabilities (methods and properties) but it is 
        designed to serve this project only.
    */
    public class AdditionalCostsList : IEnumerable<AdditionalCost>
    {
        //Stores a List of AdditionalCost instances and represents the underlying structure to this custom Collection.
        private List<AdditionalCost> ListOfCosts;

        //Property exposes the number of items in an AdditionalCostList instance.
        public int Count
        {
            get { return this.ListOfCosts.Count; }
        }

        /*
            Class constructor takes no input and initializes an AdditionalCostsList instance by creating a 
            new List<AdditionalCost> instance.
        */
        public AdditionalCostsList()
        {
            this.ListOfCosts = new List<AdditionalCost>();
        }

        /*
            Adds an AdditionalCost instance to the AdditionalCostsList instance or displays an error message 
            on the screen if the AdditionalCost instance already exists in the List.
            Validates the AdditionalCost before adding it.
        */
        public void Add(AdditionalCost additionalCost)
        {
            Validate(additionalCost);
            if (!this.ListOfCosts.Contains(additionalCost))
            {
                this.ListOfCosts.Add(additionalCost);
            }
            else
            {
                Console.WriteLine("Invalid operation! The additional cost you are trying to add is already in the list.");
            }
        }

        /*
            Removes an AdditionalCost instance from the AdditionalCostsList instance or displays an error 
            message to the screen if the AdditionalCost does not exist in the List.
            Validates the AdditionalCost instance before any removals.
        */
        public void Remove(AdditionalCost additionalCost)
        {
            Validate(additionalCost);
            if (this.ListOfCosts.Contains(additionalCost))
            {
                this.ListOfCosts.Remove(additionalCost);
            }
            else
            {
                Console.WriteLine("Invalid operation! The additional cost you are trying to remove does not exist in the list.");
            }
        }

        /*
            Checks if the AdditionalCostsList contains the given AdditionalCost instance. 
            Returns true if it does or false if it does not.
        */
        public bool Contains(AdditionalCost additionalCost)
        {
            if (this.ListOfCosts.Contains(additionalCost))
            {
                return true;
            }
            return false;
        }

        //Clears all the AdditionalCost items from the AdditionalCostsList.
        public void Clear()
        {
            this.ListOfCosts.Clear();
        }

        //Implementation of the IEnumerable<AdditionalCost> GetEnumerator() method.
        public IEnumerator<AdditionalCost> GetEnumerator()
        {
            return this.ListOfCosts.GetEnumerator();
        }

        //Implementation of the IEnumerbale IEnumerable.GetEnumerator() method.
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        //Checks an AdditionalCost instance for validity. Throws an ArgumentException if it is null.
        private void Validate(AdditionalCost additionalCost)
        {
            if (additionalCost == null)
            {
                throw new ArgumentException("Invalid input! Please make sure you are not providing a null AdditionalCost instance.");
            }
        }
    }
}