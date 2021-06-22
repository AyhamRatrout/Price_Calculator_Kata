using System;
using Price_Calculator_Classes;
using Xunit;

namespace Price_Calculator_Tests
{
    public class ProductTests
    {
        //Tests that the ValidatePrice method returns a valid Price back to the constructor thus a creating a Product instance
        [Fact]
        public void TestValidatePriceMethodValid()
        {
            //arrange
            var expectedName = "Apples";
            var expectedUPC = 112233559;
            var expectedPrice = 20.25;

            //act
            var product = new Product("Apples", 112233559, 20.25);

            //assert
            Assert.Equal(expectedName, product.Name);
            Assert.Equal(expectedUPC, product.UPC);
            Assert.Equal(expectedPrice, product.PriceBeforeTax);
        }

        //Tests that the ValidatePrice method in the Product class throws an ArgumentException if the input price is invalid     
        [Fact]
        public void TestValidatePriceMethodInvalid()
        {
            //arrange
            var expected = "Invalid input! All products must have a price greater than zero...";

            //act
            var actual = Assert.Throws<ArgumentException>(() => new Product("Apples", 112233559, -1.450));

            //assert
            Assert.Equal(expected, actual.Message);

        }
    }
}
