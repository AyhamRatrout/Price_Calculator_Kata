using System;

namespace Price_Calculator_Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            TestWithDefaultTaxNoDiscountsApplied();
            TestWithCustomTaxNoDiscountsApplied();
            TestWithDefaultTaxRelativeDiscountApplied();
            TestWithCustomTaxRelativeDiscountApplied();

            TestWithDefaultTaxUPCSpecificDiscountApplied();
            TestWithCustomTaxUPCSpecificDiscountApplied();
            TestWithDefaultTaxBothDiscountsApplied();
            TestWithCustomTaxBothDiscountsApplied(); 
        }

        //Tests case 1: Default Tax and no discounts
        private static void TestWithDefaultTaxNoDiscountsApplied()
        {
            var customer = new Customer();
            customer.AddToCart(new Product("Apples", 11223344, 17.25));
            customer.AddToCart(new Product("Bananas", 1122331, 20.25));
            customer.AddToCart(new Product("Lofas", 1122331, 14.25));
            customer.AddToCart(new Product("Orbees", 1122331, 10.25));

            customer.PrintReceipt();
            customer.GenerateReport();
        }

        //Tests case 2: Default Tax and a reative discount
        private static void TestWithDefaultTaxRelativeDiscountApplied()
        {
            var customer = new Customer();
            customer.AddToCart(new Product("Apples", 11223344, 17.25));
            customer.AddToCart(new Product("Bananas", 1122331, 20.25));
            customer.AddToCart(new Product("Lofas", 1122331, 14.25));
            customer.AddToCart(new Product("Orbees", 1122331, 10.25));
            customer.ApplyDiscount(15);

            customer.PrintReceipt();
            customer.GenerateReport();
        }

        //Tests case 3: Default Tax and a UPC specific special discount
        private static void TestWithDefaultTaxUPCSpecificDiscountApplied()
        {
            var customer = new Customer();
            customer.AddToCart(new Product("Apples", 11223344, 17.25));
            customer.AddToCart(new Product("Bananas", 1122331, 20.25));
            customer.AddToCart(new Product("Lofas", 1122331, 14.25));
            customer.AddToCart(new Product("Orbees", 1122331, 10.25));
            Administrator.AddUPCToDiscountList(1122331, 10);

            customer.PrintReceipt();
            customer.GenerateReport();
        }

        //Tests case 4: Default Tax and both discounts (relative and special) applied
        private static void TestWithDefaultTaxBothDiscountsApplied()
        {
            var customer = new Customer();
            customer.AddToCart(new Product("Apples", 11223344, 17.25));
            customer.AddToCart(new Product("Bananas", 1122331, 20.25));
            customer.AddToCart(new Product("Lofas", 1122331, 14.25));
            customer.AddToCart(new Product("Orbees", 1122331, 10.25));
            customer.ApplyDiscount(15);
            Administrator.AddUPCToDiscountList(1122331, 10);

            customer.PrintReceipt();
            customer.GenerateReport();
        }

        //Tests case 5: Custom Tax and no discounts
        private static void TestWithCustomTaxNoDiscountsApplied()
        {
            var customer = new Customer();
            customer.AddToCart(new Product("Apples", 11223344, 17.25));
            customer.AddToCart(new Product("Bananas", 1122331, 20.25));
            customer.AddToCart(new Product("Lofas", 1122331, 14.25));
            customer.AddToCart(new Product("Orbees", 1122331, 10.25));
            customer.ApplyTax(25);

            customer.PrintReceipt();
            customer.GenerateReport();
        } 

        //Tests case 6: Custom Tax and a reative discount
        private static void TestWithCustomTaxRelativeDiscountApplied()
        {
            var customer = new Customer();
            customer.AddToCart(new Product("Apples", 11223344, 17.25));
            customer.AddToCart(new Product("Bananas", 1122331, 20.25));
            customer.AddToCart(new Product("Lofas", 1122331, 14.25));
            customer.AddToCart(new Product("Orbees", 1122331, 10.25));
            customer.ApplyTax(25);
            customer.ApplyDiscount(15);

            customer.PrintReceipt();
            customer.GenerateReport();
        } 

        //Tests case 7: Custom Tax and a UPC specific special discount
        private static void TestWithCustomTaxUPCSpecificDiscountApplied()
        {
            var customer = new Customer();
            customer.AddToCart(new Product("Apples", 11223344, 17.25));
            customer.AddToCart(new Product("Bananas", 1122331, 20.25));
            customer.AddToCart(new Product("Lofas", 1122331, 14.25));
            customer.AddToCart(new Product("Orbees", 1122331, 10.25));
            customer.ApplyTax(25);
            Administrator.AddUPCToDiscountList(1122331, 10);

            customer.PrintReceipt();
            customer.GenerateReport();
        }

        //Tests case 8: Default Tax and both discounts (relative and special) applied
        private static void TestWithCustomTaxBothDiscountsApplied()
        {
            var customer = new Customer();
            customer.AddToCart(new Product("Apples", 11223344, 17.25));
            customer.AddToCart(new Product("Bananas", 1122331, 20.25));
            customer.AddToCart(new Product("Lofas", 1122331, 14.25));
            customer.AddToCart(new Product("Orbees", 1122331, 10.25));
            customer.ApplyTax(25);
            customer.ApplyDiscount(15);
            Administrator.AddUPCToDiscountList(1122331, 10);

            customer.PrintReceipt();
            customer.GenerateReport();
        }


    }
}
