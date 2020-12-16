using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static SalesTax.Validator;

namespace SalesTaxTest
{
    [TestClass]
    public class ValidatorTest
    {
        [TestMethod]
        public void IsHappyNumber()
        {
            // Write this using the format you see in the other tests (just copy/paste the tests)
            var input = "2";
            var expected = 2;

            var result = ValidIsNumber(input,  out var numberResult);
            var testString = $"{input} is a valid double greater than 0";
            var testString2 = $"the string '{input}' is a valid integer and should return the number '{expected}'";

            //testString = @$"'{input}' should be equal to '{expected}' because '{input}' is a valid integer";

            using (new AssertionScope())
            {
                result.Should().BeTrue(because: testString);
                numberResult.Should().Be(expected, because: testString2);                
            }
        }

        [TestMethod]
        public void IsSadNumber()
        {
            var input = "F";

            var result = ValidIsNumber(input, out var numberResult);

            var testString = $"{input} is NOT a valid double greater than 0";

            //result.Should().Be(expected, because: testString);
            using (new AssertionScope())
            {
                result.Should().BeFalse(because: testString);
                numberResult.Should().Be(default);
            }
        }

        [TestMethod]
        public void IsHappyNegNumber()
        {
            // Write this using the format you see in the other tests (just copy/paste the tests)
            var input = "-2";            

            var result = ValidIsNumber(input, out var numberResult);

            var testString = $"{input} is NOT a valid double greater than 0";           

            //result.Should().Be(expected, because: testString);
            using (new AssertionScope())
            {
                result.Should().BeFalse(because: testString);
                //numberResult.Should().Be(default);
            }
        }
    }
}
