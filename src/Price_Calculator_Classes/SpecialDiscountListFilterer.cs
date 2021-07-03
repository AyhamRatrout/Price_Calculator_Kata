using System;
using System.Collections;
using System.Collections.Generic;

namespace Price_Calculator_Classes
{
    public class SpecialDiscountListFilterer
    {
        public SpecialDiscountList BeforeTaxSpecialDiscountList{get; private set;}
        public SpecialDiscountList AfterTaxSpecialDiscountList{get; private set;}
        public SpecialDiscountListFilterer(SpecialDiscountList specialDiscountList)
        {
            this.BeforeTaxSpecialDiscountList = new SpecialDiscountList();
            this.AfterTaxSpecialDiscountList = new SpecialDiscountList();
            Validate(specialDiscountList);
            Filter(specialDiscountList);
        }
        
        private void Filter(SpecialDiscountList specialDiscountList)
        {
            foreach(var specialDiscount in specialDiscountList)
            {
                if(specialDiscount.Precedence == Precedence.BeforeTax)
                {
                    this.BeforeTaxSpecialDiscountList.Add(specialDiscount);
                }
                else
                {
                    this.AfterTaxSpecialDiscountList.Add(specialDiscount);
                }
            }
        }
        private void Validate(SpecialDiscountList specialDiscountList)
        {
            if(specialDiscountList == null)
            {
                throw new ArgumentException("Invalid input! Please make sure that the provided SpecialDiscountList instance is not null.");
            }
        }
    }
}