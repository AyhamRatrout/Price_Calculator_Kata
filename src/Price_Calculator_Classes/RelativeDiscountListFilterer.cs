using System;
using System.Collections;
using System.Collections.Generic;

namespace Price_Calculator_Classes
{
    public class RelativeDiscountListFilterer
    {
        public RelativeDiscountList BeforeTaxRelativeDiscountList{get; private set;}
        public RelativeDiscountList AfterTaxRelativeDiscountList{get; private set;}
        public RelativeDiscountListFilterer(RelativeDiscountList relativeDiscountList)
        {
            this.BeforeTaxRelativeDiscountList = new RelativeDiscountList();
            this.AfterTaxRelativeDiscountList = new RelativeDiscountList();
            Validate(relativeDiscountList);
            Filter(relativeDiscountList);
        }
        
        private void Filter(RelativeDiscountList relativeDiscountList)
        {
            foreach(var relativeDiscount in relativeDiscountList)
            {
                if(relativeDiscount.Precedence == Precedence.BeforeTax)
                {
                    this.BeforeTaxRelativeDiscountList.Add(relativeDiscount);
                }
                else
                {
                    this.AfterTaxRelativeDiscountList.Add(relativeDiscount);
                }
            }
        }
        private void Validate(RelativeDiscountList relativeDiscountList)
        {
            if(relativeDiscountList == null)
            {
                throw new ArgumentException("Invalid input! Please make sure that the provided RelativeDiscountList instance is not null.");
            }
        }
    }
}