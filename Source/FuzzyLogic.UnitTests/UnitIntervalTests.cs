// -------------------------------------------------------------------------------------------------
// <copyright file="UnitIntervalTests.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.UnitTests
{
    using System.Diagnostics.CodeAnalysis;
    using Xunit;

    [SuppressMessage("StyleCop.CSharp.NamingRules", "*", Justification = "Reviewed. Suppression is OK within the Test Suite.")]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "Reviewed. Suppression is OK within the Test Suite.")]
    public class UnitIntervalTests
    {
        [Fact]
        internal void Zero_ReturnsUnitIntervalWithValueZero()
        {
            // Arrange
            // Act
            var result = UnitInterval.Zero();

            // Assert
            Assert.Equal(0, result.Value);
        }

        [Fact]
        internal void One_ReturnsUnitIntervalWithValueOne()
        {
            // Arrange
            // Act
            var result = UnitInterval.One();

            // Assert
            Assert.Equal(1, result.Value);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(0, 1, 1)]
        [InlineData(1, 0, 1)]
        [InlineData(1, 1, 2)]
        [InlineData(0.5, 0.25, 0.75)]
        [InlineData(1, 0.5, 1.5)]
        internal void AdditionOperator_WithVariousValues_ReturnsExpectedResult(
            double value1,
            double value2,
            double expected)
        {
            // Arrange
            var unitInterval1 = UnitInterval.Create(value1);
            var unitInterval2 = UnitInterval.Create(value2);

            // Act
            var result1 = unitInterval1 + unitInterval2;
            var result2 = value1 + unitInterval2;
            var result3 = unitInterval1 + value2;

            // Assert
            Assert.Equal(expected, result1);
            Assert.Equal(expected, result2);
            Assert.Equal(expected, result3);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(0, 1, -1)]
        [InlineData(1, 0, 1)]
        [InlineData(1, 1, 0)]
        [InlineData(0.5, 0.25, 0.25)]
        [InlineData(1, 0.5, 0.5)]
        internal void SubtractionOperator_WithVariousValues_ReturnsExpectedResult(
            double value1,
            double value2,
            double expected)
        {
            // Arrange
            var unitInterval1 = UnitInterval.Create(value1);
            var unitInterval2 = UnitInterval.Create(value2);

            // Act
            var result1 = unitInterval1 - unitInterval2;
            var result2 = value1 - unitInterval2;
            var result3 = unitInterval1 - value2;

            // Assert
            Assert.Equal(expected, result1);
            Assert.Equal(expected, result2);
            Assert.Equal(expected, result3);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(0, 1, 0)]
        [InlineData(1, 0, 0)]
        [InlineData(1, 1, 1)]
        [InlineData(0.5, 0.5, 0.25)]
        [InlineData(1, 0.5, 0.5)]
        internal void MultiplicationOperator_WithVariousValues_ReturnsExpectedResult(
            double value1,
            double value2,
            double expected)
        {
            // Arrange
            var unitInterval1 = UnitInterval.Create(value1);
            var unitInterval2 = UnitInterval.Create(value2);

            // Act
            var result1 = unitInterval1 * unitInterval2;
            var result2 = value1 * unitInterval2;
            var result3 = unitInterval1 * value2;

            // Assert
            Assert.Equal(expected, result1);
            Assert.Equal(expected, result2);
            Assert.Equal(expected, result3);
        }

        [Theory]
        [InlineData(0, 0, double.NaN)]
        [InlineData(0, 1, 0)]
        [InlineData(1, 0, double.PositiveInfinity)]
        [InlineData(1, 1, 1)]
        [InlineData(0.5, 0.5, 1)]
        [InlineData(1, 0.5, 2)]
        internal void DivisionOperator_WithVariousValues_ReturnsExpectedResult(
            double value1,
            double value2,
            double expected)
        {
            // Arrange
            var unitInterval1 = UnitInterval.Create(value1);
            var unitInterval2 = UnitInterval.Create(value2);

            // Act
            var result1 = unitInterval1 / unitInterval2;
            var result2 = value1 / unitInterval2;
            var result3 = unitInterval1 / value2;

            // Assert
            Assert.Equal(expected, result1);
            Assert.Equal(expected, result2);
            Assert.Equal(expected, result3);
        }

        [Theory]
        [InlineData(0, 0, false)]
        [InlineData(0, 1, false)]
        [InlineData(1, 0, true)]
        internal void GreaterThanOperator_WithVariousValues_ReturnsExpectedResult(
            double value1,
            double value2,
            bool expected)
        {
            // Arrange
            var unitInterval1 = UnitInterval.Create(value1);
            var unitInterval2 = UnitInterval.Create(value2);

            // Act
            var result1 = unitInterval1 > unitInterval2;
            var result2 = value1 > unitInterval2;
            var result3 = unitInterval1 > value2;

            // Assert
            Assert.Equal(expected, result1);
            Assert.Equal(expected, result2);
            Assert.Equal(expected, result3);
        }

        [Theory]
        [InlineData(0, 0, true)]
        [InlineData(0, 1, false)]
        [InlineData(1, 0, true)]
        internal void GreaterThanOrEqualToOperator_WithVariousValues_ReturnsExpectedResult(
            double value1,
            double value2,
            bool expected)
        {
            // Arrange
            var unitInterval1 = UnitInterval.Create(value1);
            var unitInterval2 = UnitInterval.Create(value2);

            // Act
            var result1 = unitInterval1 >= unitInterval2;
            var result2 = value1 >= unitInterval2;
            var result3 = unitInterval1 >= value2;

            // Assert
            Assert.Equal(expected, result1);
            Assert.Equal(expected, result2);
            Assert.Equal(expected, result3);
        }

        [Theory]
        [InlineData(0, 0, false)]
        [InlineData(0, 1, true)]
        [InlineData(1, 0, false)]
        internal void LessThanOperator_WithVariousValues_ReturnsExpectedResult(
            double value1,
            double value2,
            bool expected)
        {
            // Arrange
            var unitInterval1 = UnitInterval.Create(value1);
            var unitInterval2 = UnitInterval.Create(value2);

            // Act
            var result1 = unitInterval1 < unitInterval2;
            var result2 = value1 < unitInterval2;
            var result3 = unitInterval1 < value2;

            // Assert
            Assert.Equal(expected, result1);
            Assert.Equal(expected, result2);
            Assert.Equal(expected, result3);
        }

        [Theory]
        [InlineData(0, 0, true)]
        [InlineData(0, 1, true)]
        [InlineData(1, 0, false)]
        internal void LessThanOrEqualToOperator_WithVariousValues_ReturnsExpectedResult(
            double value1,
            double value2,
            bool expected)
        {
            // Arrange
            var unitInterval1 = UnitInterval.Create(value1);
            var unitInterval2 = UnitInterval.Create(value2);

            // Act
            var result1 = unitInterval1 <= unitInterval2;
            var result2 = value1 <= unitInterval2;
            var result3 = unitInterval1 <= value2;

            // Assert
            Assert.Equal(expected, result1);
            Assert.Equal(expected, result2);
            Assert.Equal(expected, result3);
        }

        [Theory]
        [InlineData(0, 0, true)]
        [InlineData(0.5, 0.5, true)]
        [InlineData(0, 1, false)]
        [InlineData(1, 0, false)]
        internal void EqualToOperator_WithVariousValues_ReturnsExpectedResult(
            double value1,
            double value2,
            bool expected)
        {
            // Arrange
            var unitInterval1 = UnitInterval.Create(value1);
            var unitInterval2 = UnitInterval.Create(value2);

            // Act
            var result1 = unitInterval1 == unitInterval2;
            var result2 = value1 == unitInterval2;
            var result3 = unitInterval1 == value2;

            // Assert
            Assert.Equal(expected, result1);
            Assert.Equal(expected, result2);
            Assert.Equal(expected, result3);
        }

        [Theory]
        [InlineData(0, 0, false)]
        [InlineData(0.5, 0.5, false)]
        [InlineData(0, 1, true)]
        [InlineData(1, 0, true)]
        internal void NotEqualToOperator_WithVariousValues_ReturnsExpectedResult(
            double value1,
            double value2,
            bool expected)
        {
            // Arrange
            var unitInterval1 = UnitInterval.Create(value1);
            var unitInterval2 = UnitInterval.Create(value2);

            // Act
            var result1 = unitInterval1 != unitInterval2;
            var result2 = value1 != unitInterval2;
            var result3 = unitInterval1 != value2;

            // Assert
            Assert.Equal(expected, result1);
            Assert.Equal(expected, result2);
            Assert.Equal(expected, result3);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(0.5, 0.5, 0)]
        [InlineData(0, 1, -1)]
        [InlineData(1, 0, 1)]
        internal void CompareToDouble_WithVariousValues_ReturnsExpectedResult(
            double value1,
            double value2,
            int expected)
        {
            // Arrange
            var unitInterval = UnitInterval.Create(value1);

            // Act
            var result = unitInterval.CompareTo(value2);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(0.5, 0.5, 0)]
        [InlineData(0, 1, -1)]
        [InlineData(1, 0, 1)]
        internal void CompareToUnitInterval_WithVariousValues_ReturnsExpectedResult(
            double value1,
            double value2,
            int expected)
        {
            // Arrange
            var unitInterval1 = UnitInterval.Create(value1);
            var unitInterval2 = UnitInterval.Create(value2);

            // Act
            var result = unitInterval1.CompareTo(unitInterval2);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        internal void Equals_WhenValueNull_ReturnsFalse()
        {
            // Arrange
            var unitInterval = UnitInterval.One();

            // Act
            var result = unitInterval.Equals(null);

            // Assert
            Assert.False(result);
        }

        [Fact]
        internal void Equals_WhenValueEqual_ReturnsTrue()
        {
            // Arrange
            var unitInterval = UnitInterval.One();

            // Act
            var result1 = unitInterval.Equals(UnitInterval.One());
            var result2 = unitInterval.Equals(1.0);

            // Assert
            Assert.True(result1);
            Assert.True(result2);
        }

        [Fact]
        internal void Equals_WhenValueNotEqual_ReturnsFalse()
        {
            // Arrange
            var unitInterval = UnitInterval.One();

            // Act
            var result1 = unitInterval.Equals(UnitInterval.Zero());
            var result2 = unitInterval.Equals(0);

            // Assert
            Assert.False(result1);
            Assert.False(result2);
        }

        [Fact]
        internal void GetHashCode_ReturnsExpectedResults()
        {
            // Arrange
            // Act
            var result1 = UnitInterval.Zero().GetHashCode();
            var result2 = UnitInterval.One().GetHashCode();

            // Assert
            Assert.Equal(0, result1);
            Assert.Equal(1072693248, result2);
        }

        [Fact]
        internal void ToString_ReturnsExpectedResults()
        {
            // Arrange
            // Act
            var result1 = UnitInterval.Zero().ToString();
            var result2 = UnitInterval.One().ToString();

            // Assert
            Assert.Equal("0", result1);
            Assert.Equal("1", result2);
        }
    }
}