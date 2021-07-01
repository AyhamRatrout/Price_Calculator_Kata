using System;
using Extension_Library;

namespace Price_Calculator_Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            TestWithDefaultTaxNoDiscountsApplied();
            TestWithDefaultTaxRelativeDiscountApplied();
            TestWithDefaultTaxUPCSpecificDiscountApplied();
            TestWithDefaultTaxBothDiscountsApplied();
            TestWithCustomTaxNoDiscountsApplied();
            TestWithCustomTaxRelativeDiscountApplied();
            TestWithCustomTaxUPCSpecificDiscountApplied();
            TestWithCustomTaxBothDiscountsApplied();
        }

        
        //Tests case 1: Default Tax and no discounts
        private static void TestWithDefaultTaxNoDiscountsApplied()
        {
            var taxCalculator = new TaxCalculator();
            var discountCalculator = new DiscountCalculator(new RelativeDiscountCalculator(), new SpecialDiscountCalculator(new SpecialDiscountList1()));
            var PriceCalculator = new PriceCalculator(taxCalculator, discountCalculator);

            var shoppingCart = new ShoppingCart(PriceCalculator);
            shoppingCart.Add(new Product("Apples", 11223344, 17.25));
            shoppingCart.Add(new Product("Bananas", 1122331, 20.25));
            shoppingCart.Add(new Product("Lofas", 1122331, 14.25));
            shoppingCart.Add(new Product("Orbees", 1122331, 10.25));

            var receipt = new Receipt(shoppingCart);
            receipt.Print();
            var report = new Report(shoppingCart);
            report.Print();
        }

        //Tests case 2: Default Tax and a reative discount
        private static void TestWithDefaultTaxRelativeDiscountApplied()
        {
            var taxCalculator = new TaxCalculator();
            var discountCalculator = new DiscountCalculator(new RelativeDiscountCalculator(10), new SpecialDiscountCalculator(new SpecialDiscountList1()));
            var PriceCalculator = new PriceCalculator(taxCalculator, discountCalculator);

            var shoppingCart = new ShoppingCart(PriceCalculator);
            shoppingCart.Add(new Product("Apples", 11223344, 17.25));
            shoppingCart.Add(new Product("Bananas", 1122331, 20.25));
            shoppingCart.Add(new Product("Lofas", 1122331, 14.25));
            shoppingCart.Add(new Product("Orbees", 1122331, 10.25));

            var receipt = new Receipt(shoppingCart);
            receipt.Print();
            var report = new Report(shoppingCart);
            report.Print();
        }

        //Tests case 3: Default Tax and a UPC specific special discount
        private static void TestWithDefaultTaxUPCSpecificDiscountApplied()
        {
            var taxCalculator = new TaxCalculator();
            var specialDiscountList = new SpecialDiscountList1();
            specialDiscountList.Add(1122331, 15);
            var discountCalculator = new DiscountCalculator(new RelativeDiscountCalculator(), new SpecialDiscountCalculator(specialDiscountList));
            var PriceCalculator = new PriceCalculator(taxCalculator, discountCalculator);

            var shoppingCart = new ShoppingCart(PriceCalculator);
            shoppingCart.Add(new Product("Apples", 11223344, 17.25));
            shoppingCart.Add(new Product("Bananas", 1122331, 20.25));
            shoppingCart.Add(new Product("Lofas", 1122331, 14.25));
            shoppingCart.Add(new Product("Orbees", 1122331, 10.25));

            var receipt = new Receipt(shoppingCart);
            receipt.Print();
            var report = new Report(shoppingCart);
            report.Print();
        }

        //Tests case 4: Default Tax and both discounts (relative and special) applied
        private static void TestWithDefaultTaxBothDiscountsApplied()
        {
            var taxCalculator = new TaxCalculator();
            var specialDiscountList = new SpecialDiscountList1();
            specialDiscountList.Add(1122331, 15);
            var discountCalculator = new DiscountCalculator(new RelativeDiscountCalculator(10), new SpecialDiscountCalculator(specialDiscountList));
            var PriceCalculator = new PriceCalculator(taxCalculator, discountCalculator);

            var shoppingCart = new ShoppingCart(PriceCalculator);
            shoppingCart.Add(new Product("Apples", 11223344, 17.25));
            shoppingCart.Add(new Product("Bananas", 1122331, 20.25));
            shoppingCart.Add(new Product("Lofas", 1122331, 14.25));
            shoppingCart.Add(new Product("Orbees", 1122331, 10.25));

            var receipt = new Receipt(shoppingCart);
            receipt.Print();
            var report = new Report(shoppingCart);
            report.Print();
        }

        //Tests case 5: Custom Tax and no discounts
        private static void TestWithCustomTaxNoDiscountsApplied()
        {
             var taxCalculator = new TaxCalculator(25);
            var discountCalculator = new DiscountCalculator(new RelativeDiscountCalculator(), new SpecialDiscountCalculator(new SpecialDiscountList1()));
            var PriceCalculator = new PriceCalculator(taxCalculator, discountCalculator);

            var shoppingCart = new ShoppingCart(PriceCalculator);
            shoppingCart.Add(new Product("Apples", 11223344, 17.25));
            shoppingCart.Add(new Product("Bananas", 1122331, 20.25));
            shoppingCart.Add(new Product("Lofas", 1122331, 14.25));
            shoppingCart.Add(new Product("Orbees", 1122331, 10.25));

            var receipt = new Receipt(shoppingCart);
            receipt.Print();
            var report = new Report(shoppingCart);
            report.Print();
        } 

        //Tests case 6: Custom Tax and a reative discount
        private static void TestWithCustomTaxRelativeDiscountApplied()
        {
            var taxCalculator = new TaxCalculator(25);
            var discountCalculator = new DiscountCalculator(new RelativeDiscountCalculator(10), new SpecialDiscountCalculator(new SpecialDiscountList1()));
            var PriceCalculator = new PriceCalculator(taxCalculator, discountCalculator);

            var shoppingCart = new ShoppingCart(PriceCalculator);
            shoppingCart.Add(new Product("Apples", 11223344, 17.25));
            shoppingCart.Add(new Product("Bananas", 1122331, 20.25));
            shoppingCart.Add(new Product("Lofas", 1122331, 14.25));
            shoppingCart.Add(new Product("Orbees", 1122331, 10.25));

            var receipt = new Receipt(shoppingCart);
            receipt.Print();
            var report = new Report(shoppingCart);
            report.Print();
        } 

        //Tests case 7: Custom Tax and a UPC specific special discount
        private static void TestWithCustomTaxUPCSpecificDiscountApplied()
        {
            var taxCalculator = new TaxCalculator(25);
            var specialDiscountList = new SpecialDiscountList1();
            specialDiscountList.Add(1122331, 15);
            var discountCalculator = new DiscountCalculator(new RelativeDiscountCalculator(), new SpecialDiscountCalculator(specialDiscountList));
            var PriceCalculator = new PriceCalculator(taxCalculator, discountCalculator);

            var shoppingCart = new ShoppingCart(PriceCalculator);
            shoppingCart.Add(new Product("Apples", 11223344, 17.25));
            shoppingCart.Add(new Product("Bananas", 1122331, 20.25));
            shoppingCart.Add(new Product("Lofas", 1122331, 14.25));
            shoppingCart.Add(new Product("Orbees", 1122331, 10.25));

            var receipt = new Receipt(shoppingCart);
            receipt.Print();
            var report = new Report(shoppingCart);
            report.Print();
        }

        //Tests case 8: Default Tax and both discounts (relative and special) applied
        private static void TestWithCustomTaxBothDiscountsApplied()
        {
            var taxCalculator = new TaxCalculator(25);
            var specialDiscountList = new SpecialDiscountList1();
            specialDiscountList.Add(1122331, 15);
            var discountCalculator = new DiscountCalculator(new RelativeDiscountCalculator(10), new SpecialDiscountCalculator(specialDiscountList));
            var PriceCalculator = new PriceCalculator(taxCalculator, discountCalculator);

            var shoppingCart = new ShoppingCart(PriceCalculator);
            shoppingCart.Add(new Product("Apples", 11223344, 17.25));
            shoppingCart.Add(new Product("Bananas", 1122331, 20.25));
            shoppingCart.Add(new Product("Lofas", 1122331, 14.25));
            shoppingCart.Add(new Product("Orbees", 1122331, 10.25));

            var receipt = new Receipt(shoppingCart);
            receipt.Print();
            var report = new Report(shoppingCart);
            report.Print();
        }
    }
}
