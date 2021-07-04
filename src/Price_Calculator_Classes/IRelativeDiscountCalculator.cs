
namespace Price_Calculator_Classes
{
    /*
        This interface defines the characteritics any RelativeDiscountCalculator type must have.

        Requires all RelativeDdiscountCalculator types to implement all of its members.
    */
    public interface IRelativeDiscountCalculator
    {
        RelativeDiscountList RelativeDiscountList { get; }

        RelativeDiscountListFilterer Filterer { get; }

        double Calculate(Product product, double Price);

        void Validate(RelativeDiscountList relativeDiscountList);
    }
}