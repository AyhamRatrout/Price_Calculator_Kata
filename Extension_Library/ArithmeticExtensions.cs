using System;

namespace Extension_Library
{
    //This class contains all the arithmetic operations that are regularly used throughout this project.
    public class ArithmeticExtensions
    {
        //Converts a percentage to its decimal equivalent. Returns the decimal to the caller.
        public static double PercentageToDecimal(double percentage)
        {
            return (percentage / 100);
        }
    }
}
