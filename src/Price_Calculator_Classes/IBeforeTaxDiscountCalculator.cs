
namespace Price_Calculator_Classes
{
    /*
        This interface defines the characteritics any BeforeTaxCalculator type must have.

        Requires all BeforeTaxCalculator types to implement all its members.
    */
    public interface IBeforeTaxDiscountCalculator
    {
        IRelativeDiscountCalculator RelativeDiscountCalculator { get; }

        ISpecialDiscountCalculator SpecialDiscountCalculator { get; }

        double Calculate(Product product);

        void Validate(RelativeDiscountList relativeDiscountList, SpecialDiscountList specialDiscountList);
    }
}