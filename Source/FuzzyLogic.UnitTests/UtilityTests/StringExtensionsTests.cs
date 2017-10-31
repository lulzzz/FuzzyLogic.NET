// -------------------------------------------------------------------------------------------------
// <copyright file="StringExtensionsTests.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/CodeEssence
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.UnitTests.UtilityTests
{
    using System.Diagnostics.CodeAnalysis;
    using FuzzyLogic.Utility;
    using Xunit;

    [SuppressMessage("StyleCop.CSharp.NamingRules", "*", Justification = "Reviewed. Suppression is OK within the Test Suite.")]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "Reviewed. Suppression is OK within the Test Suite.")]
    public class StringExtensionsTests
    {
        private enum TestEnum
        {
            Failed = 0,

            Passed = 1
        }

        [Theory]
        [InlineData("123 123 1adc \n 222", "1231231adc222")]
        [InlineData(" 123 123 1adc 222", "1231231adc222")]
        [InlineData("123 123 1adc \n 222 ", "1231231adc222")]
        public void RemoveWhiteSpace_WithVariousInputs_ReturnsExpectedString(string input, string expected)
        {
            // Arrange

            // Act
            var s = input.RemoveAllWhitespace();

            // Assert
            Assert.Equal(expected, s);
        }

        [Fact]
        internal void ToEnum_WhenString_ReturnsExpectedEnum()
        {
            // Arrange
            var someString = "Passed";

            // Act
            var result = someString.ToEnum<TestEnum>();

            // Assert
            Assert.Equal(TestEnum.Passed, result);
        }

        [Fact]
        internal void ToEnum_WhenWhiteSpaceString_ReturnsDefaultEnum()
        {
            // Arrange
            var someString = " ";

            // Act
            var result = someString.ToEnum<TestEnum>();

            // Assert
            Assert.Equal(TestEnum.Failed, result);
        }
    }
}