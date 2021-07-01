using System;

namespace Price_Calculator_Classes
{
    /*
        This interface introduces one method which is the Validate() method. 

        The Validate() method has no return type and is used to Validate a set of values which 
        are decided by the implementing class.
         
        Every class implementing this interface must define it Validate() method.
    */
    public interface IValidate
    {
        void Validate();
    }
}