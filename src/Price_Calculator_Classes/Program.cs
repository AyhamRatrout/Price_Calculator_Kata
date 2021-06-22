using System;

namespace Price_Calculator_Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            TestProductConstructorValid();
            Console.WriteLine("***************************************");
            TestProductConstructorInvalid();
            Console.WriteLine("***************************************");
            TestCalculatePriceDefaultTaxValid();
            Console.WriteLine("***************************************");
            TestCalculatePriceCustomTaxValid();
            Console.WriteLine("***************************************");
            TestCalculatePriceCustomTaxInvalid();
        }

        //Tests that the Product class constructor does indeed create a Product with the data that the users passes in
        private static void TestProductConstructorValid(){
            var product = new Product("Apples", 123456, 20.0);
            Console.WriteLine($"Product name: {product.Name}, UPC: {product.UPC}, Base price: {product.PriceBeforeTax :N2}");

        }

        //Tests that the Product class throws an ArgumentException if an invalid price (less than or equal to zero) is passed in
        private static void TestProductConstructorInvalid(){
            var product = new Product("Apples", 123456, -20.0);
        }

        //Tests that the CalculatePriceDefaultTax works as intended (i.e. applies the default tax and displays the results)
        private static void TestCalculatePriceDefaultTaxValid()
        {
            var product = new Product("Apples", 123456, 20.0);
            product.CalculatePriceDefaultTax();
        }

        //Tests that the CalculatePriceCustomTax works as intended (i.e. applies the tax the user passes in and displays the results)
        private static void TestCalculatePriceCustomTaxValid()
        {
            var product = new Product("Apples", 123456, 20.0);
            product.CalculatePriceCustomTax(30);
        }

        //Tests that the CalculatePriceCustomTax throws an ArgumentException for invalid tax values
        private static void TestCalculatePriceCustomTaxInvalid()
        {
            var product = new Product("Apples", 123456, 20.0);
            product.CalculatePriceCustomTax(-30);
        }
    }
}
