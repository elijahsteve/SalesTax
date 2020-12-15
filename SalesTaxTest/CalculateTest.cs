using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using static SalesTax.Calculate;
using FluentAssertions;

namespace SalesTaxTest
{
    [TestClass]
    public class CalculatorTest
    {
        //const variables
        const double STATETAXRATE = 0.04d;
        const double COUNTYTAXRATE = 0.02d;

        [TestMethod]
        public void HappyTotalChecked()
        {
            // variables
            var amount = 100;
            var countyTax = true;
            var expected = 106d;
            // test string
            var testString = $"{expected} should be equal to {amount} * {1 + STATETAXRATE + COUNTYTAXRATE}";
            // result
            var result = GetTotal(amount, countyTax);
            // error message
            result.Should().Be(expected, because: testString);
        }

        [TestMethod]
        public void HappyTotalUnChecked()
        {
            // variables
            var amount = 100;
            var countyTax = false;
            var expected = 104d;

            // test string
            var testString = $"{expected} should be equal to {amount} * {1 + STATETAXRATE}";

            // result
            var result = GetTotal(amount, countyTax);

            // error message
            result.Should().Be(expected, because: testString);
        }

        [TestMethod]
        public void HappyStateTax()
        {
            // variables
            var amount = 200;            
            var expected = 8d;
            // test string
            var testString = $"{expected} should be equal to {amount} * {STATETAXRATE}";
            // result
            var result = GetStateTax(amount);
            // error message
            result.Should().Be(expected, because: testString);
        }

        [TestMethod]
        public void HappyCountyTax()
        {
            // variables
            var amount = 10;            
            var expected = .2d;
            // test string
            var testString = $"{expected} should be equal to {amount} * {COUNTYTAXRATE}";
            // result
            var result = GetCountyTax(amount);
            // error message
            result.Should().Be(expected, because: testString);
        }

        [TestMethod]
        public void HappySalesTaxChecked()
        {
            // variables
            var amount = 100;
            var countyTax = true;
            var expected = 6d;
            // test string
            var testString = $"{expected} should be equal to {amount} * {STATETAXRATE + COUNTYTAXRATE}";
            // result
            var result = GetTotalSalesTax(amount, countyTax);
            // error message
            result.Should().Be(expected, because: testString);
        }

        [TestMethod]
        public void HappySalesTaxUnChecked()
        {
            // variables
            var amount = 100;
            var countyTax = false;
            var expected = 4d;
            // test string
            var testString = $"{expected} should be equal to {amount} * {STATETAXRATE}";
            // result
            var result = GetTotalSalesTax(amount, countyTax);
            // error message
            result.Should().Be(expected, because: testString);
        }
    }
}
