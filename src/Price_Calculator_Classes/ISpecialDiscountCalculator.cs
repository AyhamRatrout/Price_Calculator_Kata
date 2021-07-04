using System;

namespace Price_Calculator_Classes
{
    /*
        This interface defines the characteritics any SpecialDiscountCalculator type must have.

        Requires all SpecialDiscountCalculator types to implement its SpecialDiscountList property (the class gets to define the setter modifier), 
        SpecialDiscountListFilterer property (the class gets to define the setter modifier), and the Validate() method which takes a 
        SpecialDiscountList as a parameter.
    */
    public interface ISpecialDiscountCalculator
    {
        SpecialDiscountList SpecialDiscountList { get; }

        SpecialDiscountListFilterer Filterer { get; }

        void Validate(SpecialDiscountList specialDiscountList);
    }
}