using System;
using Price_Calculator_Classes;
using Xunit;

namespace Price_Calculator_Tests
{
    public class PriceCalculatorTests 
    {
        //Tests that the CalculatePriceDefaultTax method applies the default tax rate correctly and calculates 
        //a Product's PriceAfterTax to two decimal digits correctly
        [Fact]
        public void TestCalculatePriceDefaultTaxValid()
        {
            //arrange
            var product = new Product("Apples", 112233559, 20.37);
            product.CalculatePriceDefaultTax();
            var expected = 24.44;

            //act
            var actual = product.PriceAfterTax;

            //assert
            Assert.Equal(expected, actual);
        }

        //Tests that the CalculatePriceCustomTax method applies the custom tax rate that the user chooses correctly  
        //and calculates a Product's PriceAfterTax to two decimal digits correctly
        [Fact]
        public void TestCalculatePriceCustomTaxValid()
        {
            //arrange
            var product = new Product("Apples", 112233559, 20.37);
            product.CalculatePriceCustomTax(50);
            var expected = 30.56;

            //act
            var actual = product.PriceAfterTax;

            //assert
            Assert.Equal(expected, actual);            
        }

        //Tests that the CalculatePriceCustomTax method throws an ArgumentException if the input tax is invalid (more than 100 or less than zero)
        [Fact]
        public void TestCalculatePriceCustomTaxInvalid()
        {
            //arrange
            var product = new Product("Apples", 112233559, 20.25);
            var expected = "Invalid input. Please make sure that the tax applied is between 0 and 100.";

            //act
            var actual1 = Assert.Throws<ArgumentException>(() => product.CalculatePriceCustomTax(-10.5));
            var actual2 = Assert.Throws<ArgumentException>(() => product.CalculatePriceCustomTax(100.5));

            //assert
            Assert.Equal(expected, actual1.Message);
            Assert.Equal(expected, actual2.Message);
        }
    }
}