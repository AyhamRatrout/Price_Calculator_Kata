using System;

namespace Price_Calculator_Classes
{
    /*
        This interface defines the characteritics any RelativeDiscountCalculator type must have.

        Requires all RelativeDdiscountCalculator types to implement its RelativeDiscountList property (the class gets to define the setter modifier), 
        RelativeDiscountListFilterer property (the class gets to define the setter modifier), and the Validate() method which takes a 
        RelativeDiscountList as a parameter.
    */
    public interface IRelativeDiscountCalculator
    {
        RelativeDiscountList RelativeDiscountList { get; }

        RelativeDiscountListFilterer Filterer { get; }

        void Validate(RelativeDiscountList relativeDiscountList);
    }
}