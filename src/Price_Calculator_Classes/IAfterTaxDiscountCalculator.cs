
namespace Price_Calculator_Classes
{
    /*
        This interface defines the characteritics any AfterTaxCalculator type must have.

        Requires all AfterTaxCalculator types to implement all its members.
    */
    public interface IAfterTaxDiscountCalculator
    {
        IRelativeDiscountCalculator RelativeDiscountCalculator { get; }

        ISpecialDiscountCalculator SpecialDiscountCalculator { get; }

        double Calculate(Product product, double Price);

        void Validate(RelativeDiscountList relativeDiscountList, SpecialDiscountList specialDiscountList);
    }
}