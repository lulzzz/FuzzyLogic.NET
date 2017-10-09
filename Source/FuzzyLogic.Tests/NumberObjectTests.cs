// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NumberObjectTests.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace FuzzyLogic.Tests
{
    using System.Diagnostics.CodeAnalysis;

    using Xunit;

    /// <summary>
    /// 
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.NamingRules", "*", Justification = "Reviewed. Suppression is OK within the Test Suite.")]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "Reviewed. Suppression is OK within the Test Suite.")]
    public class NumberObjectTests
    {
        [Fact]
        internal void EqualToOperator()
        {
            // Arrange
            var number1 = NonNegativeDouble.Create(1);
            var number2 = NonNegativeDouble.Create(1);
            var number3 = NonNegativeDouble.Create(0);

            // Act
            var result1 = number1 == number2;
            var result2 = number1 == number3;

            // Assert
            Assert.True(result1);
            Assert.False(result2);
        }

        [Fact]
        internal void NotEqualToOperator()
        {
            // Arrange
            var number1 = NonNegativeDouble.Create(100);
            var number2 = NonNegativeDouble.Create(100);
            var number3 = NonNegativeDouble.Create(50);

            // Act
            var result1 = number1 != number2;
            var result2 = number1 != number3;

            // Assert
            Assert.False(result1);
            Assert.True(result2);
        }

        [Fact]
        internal void AdditionOperator()
        {
            // Arrange
            var number1 = NonNegativeDouble.Create(1);
            var number2 = NonNegativeDouble.Create(1);

            // Act
            var result1 = number1 + number2;
            var result2 = 1 + number1;
            var result3 = number1 + 1;

            // Assert
            Assert.Equal(2, result1);
            Assert.Equal(2, result2);
            Assert.Equal(2, result3);
        }

        [Fact]
        internal void SubtractionOperator()
        {
            // Arrange
            var number1 = NonNegativeDouble.Create(1);
            var number2 = NonNegativeDouble.Create(1);

            // Act
            var result1 = number1 - number2;
            var result2 = 2 - number1;
            var result3 = number1 - 1;

            // Assert
            Assert.Equal(0, result1);
            Assert.Equal(1, result2);
            Assert.Equal(0, result3);
        }

        [Fact]
        internal void MultiplyOperator()
        {
            // Arrange
            var number1 = NonNegativeDouble.Create(1);
            var number2 = NonNegativeDouble.Create(1);

            // Act
            var result1 = number1 * number2;
            var result2 = 2 * number1;
            var result3 = number1 * 2;

            // Assert
            Assert.Equal(1, result1);
            Assert.Equal(2, result2);
            Assert.Equal(2, result3);
        }

        [Fact]
        internal void DivideOperator()
        {
            // Arrange
            var number1 = NonNegativeDouble.Create(1);
            var number2 = NonNegativeDouble.Create(1);

            // Act
            var result1 = number1 / number2;
            var result2 = 2 / number1;
            var result3 = number1 / 2;

            // Assert
            Assert.Equal(1, result1);
            Assert.Equal(2, result2);
            Assert.Equal(0.5, result3);
        }

        [Fact]
        internal void GreaterThanOperator()
        {
            // Arrange
            var number1 = NonNegativeDouble.Create(1);
            var number2 = NonNegativeDouble.Create(1);

            // Act
            var result1 = number1 > number2;
            var result2 = 2 > number1;
            var result3 = number1 > 0;

            // Assert
            Assert.False(result1);
            Assert.True(result2);
            Assert.True(result3);
        }

        [Fact]
        internal void LessThanOperator()
        {
            // Arrange
            var number1 = NonNegativeDouble.Create(1);
            var number2 = NonNegativeDouble.Create(1);

            // Act
            var result1 = number1 < number2;
            var result2 = 0 < number1;
            var result3 = number1 < 2;

            // Assert
            Assert.False(result1);
            Assert.True(result2);
            Assert.True(result3);
        }

        [Theory]
        [InlineData(1, 0, 1)]
        [InlineData(1, 1, 0)]
        [InlineData(0, 1, -1)]
        internal void CompareTo(double value1, double value2, double comparison)
        {
            // Arrange
            var number1 = NonNegativeDouble.Create(value1);
            var number2 = NonNegativeDouble.Create(value2);

            // Act
            var result = number1.CompareTo(number2);

            // Assert
            Assert.Equal(comparison, result);
        }
    }
}