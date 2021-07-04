using System;

namespace Price_Calculator_Classes
{
    /*
        This class defines a RelativeDiscountListFilterer type which Filters a RelativeDisocuntList instance by Precedence.

        Does so by calling its Filter() method to Filter a provided RelativeDiscountList, by Precedence, into two RelativeDiscountLists: 
        one containing the RelativeDiscounts to be applied before Tax and the other containing the RelativeDiscounts to be applied after Tax.

        Stores the new (Filetered) List in two seperate RelativeDsciountList instances.
    */
    public class RelativeDiscountListFilterer
    {
        //Stores a filtered varsion of the provided RelativeDiscountList containing all the RelativeDiscounts to be applied before Tax.
        public RelativeDiscountList BeforeTaxRelativeDiscountList { get; private set; }

        //Stores a filtered varsion of the provided RelativeDiscountList containing all the RelativeDiscounts to be applied after Tax.
        public RelativeDiscountList AfterTaxRelativeDiscountList { get; private set; }

        /*
            Class constructor initializes a RelativeDiscountListFilterer isnatnce provided a RelativeDiscountList instance.

            First Validates the provided RelativeDiscountList instance. If valid, creates two new RelativeDiscountList instances:
            a BeforeTaxRelativeDiscountList and an AfterTaxRelativeDiscountList and populates them by calling the Filter() method. 
        */
        public RelativeDiscountListFilterer(RelativeDiscountList relativeDiscountList)
        {
            Validate(relativeDiscountList);
            this.BeforeTaxRelativeDiscountList = new RelativeDiscountList();
            this.AfterTaxRelativeDiscountList = new RelativeDiscountList();
            Filter(relativeDiscountList);
        }

        /*
            Helper method Filters a given RelativeDiscountList by precedence into two new RelativeDiscountLists: a BeforeTaxRelativeDiscountList 
            and an AfterTaxRelativeDiscountList.

            Does so by enumerating over the given RelativeDiscountList instance and checking each RelativeDiscount's Precedence before adding
            it to the appropriate List.
        */
        private void Filter(RelativeDiscountList relativeDiscountList)
        {
            foreach (var relativeDiscount in relativeDiscountList)
            {
                if (relativeDiscount.Precedence == Precedence.BeforeTax)
                {
                    this.BeforeTaxRelativeDiscountList.Add(relativeDiscount);
                }
                else
                {
                    this.AfterTaxRelativeDiscountList.Add(relativeDiscount);
                }
            }
        }

        //Validates a given RelativeDiscountList instance. Throws an ArgumentException if the provided List is null.
        private void Validate(RelativeDiscountList relativeDiscountList)
        {
            if (relativeDiscountList == null)
            {
                throw new ArgumentException("Invalid input! Please make sure that the provided RelativeDiscountList instance is not null.");
            }
        }
    }
}