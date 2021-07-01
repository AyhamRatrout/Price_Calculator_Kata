using System;

namespace Price_Calculator_Classes
{
    /*
        Enumeration type defines two constants: BeforeTax and AfterTax.
        This Enumeration enables the user to decide the precedence of the Price calculation operations by 
        indication which Discounts they want applied before Tax and which to be applied after Tax.
    */
    public enum Precedence
    {
        BeforeTax,
        AfterTax
    }
}