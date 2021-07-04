using System;

namespace Price_Calculator_Classes
{
    /*
        Enumeration type defines two constants: Percentage and Absolute.
        This Enumeration enables the user to decide the type of an AdditionalDiscount's amount as either a Percentage
        of the Product's Price or as an Absolute value to be added to a Product's Price.
    */
    public enum AmountType
    {
        Percentage,
        Absolute
    }
}