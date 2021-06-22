using System;
using Price_Calculator_Classes;
using Xunit;

namespace Price_Calculator_Tests
{
    public class PriceCalculatorTests 
    {
        //Tests that the CalculatePriceDefaultTax method applies the default tax rate correctly and calculates 
        //a Product's PriceAfterAdjustments to two decimal digits correctly (no discount applied)
        [Fact]
        public void TestCalculatePriceDefaultTaxValidNoDiscountApplied()
        {
            //arrange
            var product = new Product("Apples", 112233559, 20.37);
            PriceCalculator.ApplyDiscount(0);
            product.CalculateAdjustedPriceDefaultTax();
            var expected = 24.44;

            //act
            var actual = product.PriceAfterAdjustments;

            //assert
            Assert.Equal(expected, actual);
        }

        //Tests that the CalculatePriceDefaultTax method applies the default tax rate and the discount amount correctly 
        //and calculates a Product's PriceAfterAdjustments to two decimal digits correctly
        [Fact]
        public void TestCalculatePriceDefaultTaxValidWithDiscountApplied()
        {
            //arrange
            var product = new Product("Apples", 112233559, 20.37);
            PriceCalculator.ApplyDiscount(15);
            product.CalculateAdjustedPriceDefaultTax();
            var expected = 21.39;

            //act
            var actual = product.PriceAfterAdjustments;

            //assert
            Assert.Equal(expected, actual);
        }

        //Tests that the PriceCalculator's ApplyDiscount method throws an ArgumentException if the discount amount is invalid (more than 100 or less than zero)
        [Fact]
        public void TestApplyDiscountInvalid()
        {
            //arrange
            var expected = "Invalid input. Please make sure that the discount applied is between 0% and 100%";

            //act
            var actual1 = Assert.Throws<ArgumentException>(() => PriceCalculator.ApplyDiscount(-10.5));
            var actual2 = Assert.Throws<ArgumentException>(() => PriceCalculator.ApplyDiscount(100.5));

            //assert
            Assert.Equal(expected, actual1.Message);
            Assert.Equal(expected, actual2.Message);

        }
        
        //Tests that the CalculatePriceCustomTax method applies the custom tax rate that the user chooses correctly  
        //and calculates a Product's PriceAfterAdjustments to two decimal digits correctly (no discount applied)
        [Fact]
        public void TestCalculatePriceCustomTaxValidNoDiscountApplied()
        {
            //arrange
            var product = new Product("Apples", 112233559, 20.37);
            PriceCalculator.ApplyDiscount(0);
            product.CalculateAdjustedPriceCustomTax(50);
            var expected = 30.56;

            //act
            var actual = product.PriceAfterAdjustments;

            //assert
            Assert.Equal(expected, actual);            
        }

        //Tests that the CalculatePriceCustomTax method applies the custom tax rate nd the discount amount that the   
        //user chooses correctly and calculates a Product's PriceAfterAdjustments to two decimal digits correctly
        [Fact]
        public void TestCalculatePriceCustomTaxValidWithDiscountApplied()
        {
            //arrange
            var product = new Product("Apples", 112233559, 20.37);
            PriceCalculator.ApplyDiscount(25);
            product.CalculateAdjustedPriceCustomTax(50);
            var expected = 25.46;

            //act
            var actual = product.PriceAfterAdjustments;

            //assert
            Assert.Equal(expected, actual);            
        }        

        //Tests that the CalculatePriceCustomTax method throws an ArgumentException if the input tax is invalid (more than 100 or less than zero)
        [Fact]
        public void TestCalculatePriceCustomTaxInvalid()
        {
            //arrange
            var product = new Product("Apples", 112233559, 20.25);
            var expected = "Invalid input. Please make sure that the tax applied is between 0% and 100%";

            //act
            var actual1 = Assert.Throws<ArgumentException>(() => product.CalculateAdjustedPriceCustomTax(-10.5));
            var actual2 = Assert.Throws<ArgumentException>(() => product.CalculateAdjustedPriceCustomTax(100.5));

            //assert
            Assert.Equal(expected, actual1.Message);
            Assert.Equal(expected, actual2.Message);
        }
    }
}