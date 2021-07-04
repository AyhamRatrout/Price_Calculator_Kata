using System;
using System.Collections;
using System.Collections.Generic;

namespace Price_Calculator_Classes
{
    /*
        This class defines a SpecialDiscountListFilterer type which Filters a SpecialDisocuntList instance by Precedence.

        Does so by calling its Filter() method to Filter a provided SpecialDiscountList, by Precedence, into two SpecialDiscountLists: 
        one containing the SpecialeDiscounts to be applied before Tax and the other containing the SpecialDiscounts to be applied after Tax.

        Stores the new (Filetered) List in two seperate SpecialDsciountList instances.
    */
    public class SpecialDiscountListFilterer
    {
        //Stores a filtered varsion of the provided SpecialDiscountList containing all the SpecialDiscounts to be applied before Tax.        
        public SpecialDiscountList BeforeTaxSpecialDiscountList { get; private set; }

        //Stores a filtered varsion of the provided SpecialDiscountList containing all the SpecialDiscounts to be applied after Tax.        
        public SpecialDiscountList AfterTaxSpecialDiscountList { get; private set; }

        /*
            Class constructor initializes a SpecialDiscountListFilterer isnatnce provided a SpecialDiscountList instance.

            First Validates the provided SpecialDiscountList instance. If valid, creates two new SpecialDiscountList instances:
            a BeforeTaxSpecialDiscountList and an AfterTaxSpecialDiscountList and populates them by calling the Filter() method. 
        */
        public SpecialDiscountListFilterer(SpecialDiscountList specialDiscountList)
        {
            Validate(specialDiscountList);
            this.BeforeTaxSpecialDiscountList = new SpecialDiscountList();
            this.AfterTaxSpecialDiscountList = new SpecialDiscountList();
            Filter(specialDiscountList);
        }

        /*
            Helper method Filters a given SpecialDiscountList by precedence into two new SpecialDiscountLists: a BeforeTaxSpecialDiscountList 
            and an AfterTaxSpecialDiscountList.

            Does so by enumerating over the given SpecialDiscountList instance and checking each SpecialDiscount's Precedence before adding
            it to the appropriate List.
        */
        private void Filter(SpecialDiscountList specialDiscountList)
        {
            foreach (var specialDiscount in specialDiscountList)
            {
                if (specialDiscount.Precedence == Precedence.BeforeTax)
                {
                    this.BeforeTaxSpecialDiscountList.Add(specialDiscount);
                }
                else
                {
                    this.AfterTaxSpecialDiscountList.Add(specialDiscount);
                }
            }
        }

        //Validates a given SpecialDiscountList instance. Throws an ArgumentException if the provided List is null.
        private void Validate(SpecialDiscountList specialDiscountList)
        {
            if (specialDiscountList == null)
            {
                throw new ArgumentException("Invalid input! Please make sure that the provided SpecialDiscountList instance is not null.");
            }
        }
    }
}