using System;
using Xunit;
using Extension_Library;

namespace Price_Calculator_Tests
{
    public class ArithmeticExtensionsTests
    {
        //Tests that the PercentageToDecimal method does the conversion correctly and returns the correct decimal value.
        [Fact]
        public void TestPercentageToDecimal()
        {
            //arrange
            var expected1 = -0.40;
            var expected2 = 0.00;
            var expected3 = 0.20;
            var expected4 = 1.00;
            var expected5 = 1.50;
            
            //act
            var actual1 = ArithmeticExtensions.PercentageToDecimal(-40);
            var actual2 = ArithmeticExtensions.PercentageToDecimal(0);
            var actual3 = ArithmeticExtensions.PercentageToDecimal(20);
            var actual4 = ArithmeticExtensions.PercentageToDecimal(100);
            var actual5 = ArithmeticExtensions.PercentageToDecimal(150);

            //assert
            Assert.Equal(expected1, actual1);
            Assert.Equal(expected2, actual2);
            Assert.Equal(expected3, actual3);
            Assert.Equal(expected4, actual4);
            Assert.Equal(expected5, actual5);
        }
    }
}