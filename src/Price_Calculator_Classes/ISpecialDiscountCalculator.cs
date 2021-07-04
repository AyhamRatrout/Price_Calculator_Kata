
namespace Price_Calculator_Classes
{
    /*
        This interface defines the characteritics any SpecialDiscountCalculator type must have.

        Requires all SpecialDiscountCalculator types to implement all of its members.
    */
    public interface ISpecialDiscountCalculator
    {
        SpecialDiscountList SpecialDiscountList { get; }

        SpecialDiscountListFilterer Filterer { get; }

        double Calculate(Product product, double Price);

        void Validate(SpecialDiscountList specialDiscountList);
    }
}