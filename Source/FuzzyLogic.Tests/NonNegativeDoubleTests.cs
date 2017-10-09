// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NonNegativeDoubleTests.cs" author="Christopher Sellers">
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
    /// The membership value tests.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.NamingRules", "*", Justification = "Reviewed. Suppression is OK within the Test Suite.")]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "Reviewed. Suppression is OK within the Test Suite.")]
    public class NonNegativeDoubleTests
    {
        [Fact]
        internal void Zero_ReturnsExpectedNumberObject()
        {
            // Arrange
            // Act
            var zero = NonNegativeDouble.Zero();

            // Assert
            Assert.Equal(NonNegativeDouble.Create(0), zero);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(0, 1, 1)]
        [InlineData(1, 0, 1)]
        [InlineData(0.5, 0.5, 1)]
        internal void Add_WithVariousInputs_ReturnsExpectedNumberObject(double value1, double value2, double expected)
        {
            // Arrange
            var numberObject1 = NonNegativeDouble.Create(value1);
            var numberObject2 = NonNegativeDouble.Create(value2);

            // Act
            var result = numberObject1.Add(numberObject2);

            // Assert
            Assert.Equal(NonNegativeDouble.Create(expected), result);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(0.5, 0.5, 0)]
        [InlineData(1, 0, 1)]
        [InlineData(1, 0.5, 0.5)]
        internal void Subtract_WithVariousInputs_ReturnsExpectedNumberObject(double value1, double value2, double expected)
        {
            // Arrange
            var numberObject1 = NonNegativeDouble.Create(value1);
            var numberObject2 = NonNegativeDouble.Create(value2);

            // Act
            var result = numberObject1.Subtract(numberObject2);

            // Assert
            Assert.Equal(NonNegativeDouble.Create(expected), result);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(1, 1, 1)]
        [InlineData(0.5, 1, 0.5)]
        [InlineData(1, 0, 0)]
        [InlineData(0.5, 0.5, 0.25)]
        internal void Multiply_WithVariousInputs_ReturnsExpectedNumberObject(double value, double factor, double expected)
        {
            // Arrange
            var numberObject = NonNegativeDouble.Create(value);

            // Act
            var result = numberObject.Multiply(factor);

            // Assert
            Assert.Equal(NonNegativeDouble.Create(expected), result);
        }

        [Theory]
        [InlineData(0, 1, 0)]
        [InlineData(1, 1, 1)]
        [InlineData(0.5, 0.5, 1)]
        internal void Divide(double value, double factor, double expected)
        {
            // Arrange
            var numberObject = NonNegativeDouble.Create(value);

            // Act
            var result = numberObject.Divide(factor);

            // Assert
            Assert.Equal(NonNegativeDouble.Create(expected), result);
        }
    }
}