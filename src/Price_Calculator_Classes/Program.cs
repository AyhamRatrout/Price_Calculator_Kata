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
            TestCalculatePriceDefaultTaxValidNoDiscount();
            Console.WriteLine("***************************************");
            TestCalculatePriceDefaultTaxValidWithDiscount();
            Console.WriteLine("***************************************");
            TestCalculatePriceCustomTaxValidNoDiscount();
            Console.WriteLine("***************************************");
            TestCalculatePriceCustomTaxValidWithDiscount();
            Console.WriteLine("***************************************");
            TestCalculatePriceCustomTaxInvalid();
            TestApplyDiscountInvalid();
        }

        //Tests that the Product class constructor does indeed create a Product with the data that the users passes in
        private static void TestProductConstructorValid(){
            var product = new Product("Apples", 123456, 20.0);
            Console.WriteLine($"Product name: {product.Name}, UPC: {product.UPC}, Base price: {product.PriceBeforeAdjustments :N2}");

        }

        //Tests that the Product class throws an ArgumentException if an invalid price (less than or equal to zero) is passed in
        private static void TestProductConstructorInvalid(){
            var product = new Product("Apples", 123456, -20.0);
        }

        //Tests that the CalculatePriceDefaultTax works as intended when no discount is applied (i.e. applies the default tax and displays the results)
        private static void TestCalculatePriceDefaultTaxValidNoDiscount()
        {
            var product = new Product("Apples", 123456, 20.0);
            PriceCalculator.ApplyDiscount(0);
            product.CalculateAdjustedPriceDefaultTax();
        }

        //Tests that the CalculatePriceDefaultTax works as intended when discount is applied (i.e. applies the default tax and displays the results)
        private static void TestCalculatePriceDefaultTaxValidWithDiscount()
        {
            var product = new Product("Apples", 123456, 20.0);
            PriceCalculator.ApplyDiscount(10);
            product.CalculateAdjustedPriceDefaultTax();
        }

        //Tests that the CalculatePriceCustomTax works as intended when no discount is applied (i.e. applies the tax the user passes in and displays the results)
        private static void TestCalculatePriceCustomTaxValidNoDiscount()
        {
            var product = new Product("Apples", 123456, 20.0);
            PriceCalculator.ApplyDiscount(0);
            product.CalculateAdjustedPriceCustomTax(30);
        }

        //Tests that the CalculatePriceCustomTax works as intended when discount is applied (i.e. applies the tax the user passes in and displays the results)
        private static void TestCalculatePriceCustomTaxValidWithDiscount()
        {
            var product = new Product("Apples", 123456, 20.0);
            PriceCalculator.ApplyDiscount(10);
            product.CalculateAdjustedPriceCustomTax(30);
        }
        
        //Tests that the CalculatePriceCustomTax throws an ArgumentException for invalid tax values
        private static void TestCalculatePriceCustomTaxInvalid()
        {
            var product = new Product("Apples", 123456, 20.0);
            product.CalculateAdjustedPriceCustomTax(-30);
        }

        //Tests that the ApplyDiscount method throws an ArgumentException for invalid discount values
        private static void TestApplyDiscountInvalid()
        {
            PriceCalculator.ApplyDiscount(105);
        }
    }
}
