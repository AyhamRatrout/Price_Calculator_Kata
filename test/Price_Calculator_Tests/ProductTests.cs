using System;
using Xunit;
using Price_Calculator_Classes;

namespace Price_Calculator_Tests
{
    public class ProductTests
    {
        //Tests if a Product instance gets created if the input values are valid
        [Fact]
        public void TestValidateMethodForValidInputs()
        {
            //arrange
            var expectedName = "Apples";
            var expectedUPC = 112233445;
            var expectedPrice = 19.95;

            //act
            var product = new Product("Apples", 112233445, 19.95);

            //assert
            Assert.Equal(expectedName, product.Name);
            Assert.Equal(expectedUPC, product.UPC);
            Assert.Equal(expectedPrice, product.Price);
        }

        //Tests if the Validate method throws an ArgumentException when a Product is created with invalid input values
        [Fact]
        public void TestValidateMethodForInvalidInputs()
        {
            //arrange
            var expected = "Invalid inputs! Please make sure that the product's name is not null, empty, or whitespace, the product's UPC is greater than zero, and the product's price is also greater than zero...";

            //act
            var actual1 = Assert.Throws<ArgumentException>(() => new Product(" ", 112233445, 19.95));
            var actual2 = Assert.Throws<ArgumentException>(() => new Product("Apples", -112233445, 19.95));
            var actual3 = Assert.Throws<ArgumentException>(() => new Product("Apples", 112233445, -19.95));

            //assert
            Assert.Equal(expected, actual1.Message);   
            Assert.Equal(expected, actual2.Message);
            Assert.Equal(expected, actual3.Message);         
        }
    }
}