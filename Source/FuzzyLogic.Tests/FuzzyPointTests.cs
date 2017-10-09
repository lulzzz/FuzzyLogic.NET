// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FuzzyPointTests.cs" author="Christopher Sellers">
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
    /// The point tests.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.NamingRules", "*", Justification = "Reviewed. Suppression is OK within the Test Suite.")]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "Reviewed. Suppression is OK within the Test Suite.")]
    public class FuzzyPointTests
    {
        [Theory]
        [InlineData(0, 0, 0, 0, 0, 0)]
        [InlineData(0, 0, 0, 1, 0, 1)]
        [InlineData(1, 0.5, 2, 0.5, 3, 1)]
        internal void Add(
            double point1x,
            double point1y,
            double point2x,
            double point2y,
            double point3x,
            double point3y)
        {
            // Arrange
            var point1 = new FuzzyPoint(point1x, point1y);
            var point2 = new FuzzyPoint(point2x, point2y);
            var point3 = new FuzzyPoint(NonNegativeDouble.Create(point1x), MembershipValue.Create(point1y));
            var point4 = new FuzzyPoint(NonNegativeDouble.Create(point2x), MembershipValue.Create(point2y));

            // Act
            var result1 = point1.Add(point2);
            var result2 = point1 + point2;
            var result3 = point3.Add(point4);
            var result4 = point3 + point4;

            // Assert
            Assert.Equal(new FuzzyPoint(point3x, point3y), result1);
            Assert.Equal(new FuzzyPoint(point3x, point3y), result2);
            Assert.Equal(new FuzzyPoint(point3x, point3y), result3);
            Assert.Equal(new FuzzyPoint(point3x, point3y), result4);
        }

        [Theory]
        [InlineData(0, 0, 0, 0, 0, 0)]
        [InlineData(1, 1, 1, 1, 0, 0)]
        [InlineData(2, 1, 1, 1, 1, 0)]
        [InlineData(3, 0.5, 2, 0.5, 1, 0)]
        internal void Subtract(
            double point1x,
            double point1y,
            double point2x,
            double point2y,
            double point3x,
            double point3y)
        {
            // Arrange
            var point1 = new FuzzyPoint(point1x, point1y);
            var point2 = new FuzzyPoint(point2x, point2y);
            var point3 = new FuzzyPoint(NonNegativeDouble.Create(point1x), MembershipValue.Create(point1y));
            var point4 = new FuzzyPoint(NonNegativeDouble.Create(point2x), MembershipValue.Create(point2y));

            // Act
            var result1 = point1.Subtract(point2);
            var result2 = point1 - point2;
            var result3 = point3.Subtract(point4);
            var result4 = point3 - point4;

            // Assert
            Assert.Equal(new FuzzyPoint(point3x, point3y), result1);
            Assert.Equal(new FuzzyPoint(point3x, point3y), result2);
            Assert.Equal(new FuzzyPoint(point3x, point3y), result3);
            Assert.Equal(new FuzzyPoint(point3x, point3y), result4);
        }

        [Theory]
        [InlineData(0, 0, 1, 0, 0)]
        [InlineData(1, 1, 1, 1, 1)]
        [InlineData(1, 1, 0.5, 0.5, 0.5)]
        internal void Multiply(
            double point1x,
            double point1y,
            double factor,
            double point2x,
            double point2y)
        {
            // Arrange
            var point = new FuzzyPoint(point1x, point1y);

            // Act
            var result1 = point.Multiply(factor);
            var result2 = point * factor;

            // Assert
            Assert.Equal(new FuzzyPoint(point2x, point2y), result1);
            Assert.Equal(new FuzzyPoint(point2x, point2y), result2);
        }

        [Theory]
        [InlineData(0, 0, 1, 0, 0)]
        [InlineData(1, 1, 1, 1, 1)]
        [InlineData(1, 1, 2, 0.5, 0.5)]
        internal void Divide(
            double point1x,
            double point1y,
            double factor,
            double point2x,
            double point2y)
        {
            // Arrange
            var point = new FuzzyPoint(point1x, point1y);

            // Act
            var result1 = point.Divide(factor);
            var result2 = point / factor;

            // Assert
            Assert.Equal(new FuzzyPoint(point2x, point2y), result1);
            Assert.Equal(new FuzzyPoint(point2x, point2y), result2);
        }

        [Theory]
        [InlineData(0, 0, 0, 0)]
        internal void DistanceTo(
            double point1x,
            double point1y,
            double point2x,
            double point2y)
        {
            // Arrange
            var point1 = new FuzzyPoint(point1x, point1y);
            var point2 = new FuzzyPoint(point2x, point2y);

            // Act
            var result = point1.DistanceTo(point2);

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        internal void SquaredDistanceTo()
        {
            // Arrange
            var point1 = new FuzzyPoint(1, 0);
            var point2 = new FuzzyPoint(0, 0);

            // Act
            var result = point1.SquaredDistanceTo(point2);

            // Assert
            Assert.Equal(1, result);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(0, 1, 1)]
        [InlineData(10, 0, 10)]
        [InlineData(0.3, 0.4, 0.5)]
        internal void EuclideanNorm(double x, double y, double expectedNorm)
        {
            // Arrange
            var point = new FuzzyPoint(x, y);

            // Act
            var result = point.EuclideanNorm();

            // Assert
            Assert.Equal(result, expectedNorm);
        }

        [Theory]
        [InlineData(1.1f, 0.2f, 1.1f, 0.2f, true)]
        [InlineData(1.1f, 0.2f, 3.3f, 0.2f, false)]
        [InlineData(1.1f, 0.2f, 1.1f, 0.4f, false)]
        [InlineData(1.1f, 0.2f, 3.3f, 0.4f, false)]
        internal void EqualityOperator(double x1, double y1, double x2, double y2, bool areEqual)
        {
            // Arrange
            // Act
            var point1 = new FuzzyPoint(x1, y1);
            var point2 = new FuzzyPoint(x2, y2);

            // Assert
            Assert.Equal(point1 == point2, areEqual);
        }

        [Theory]
        [InlineData(1.1f, 0.2f, 1.1f, 0.2f, false)]
        [InlineData(1.1f, 0.2f, 3.3f, 0.2f, true)]
        [InlineData(1.1f, 0.2f, 1.1f, 0.4f, true)]
        [InlineData(1.1f, 0.2f, 3.3f, 0.4f, true)]
        internal void InequalityOperator(double x1, double y1, double x2, double y2, bool areNotEqual)
        {
            // Arrange
            // Act
            var point1 = new FuzzyPoint(x1, y1);
            var point2 = new FuzzyPoint(x2, y2);

            // Assert
            Assert.Equal(point1 != point2, areNotEqual);
        }

        [Fact]
        internal void GetHashCodeTest()
        {
            // Arrange
            var point1 = new FuzzyPoint(0, 0);
            var point2 = new FuzzyPoint(1, 1);

            // Act
            var result1 = point1.GetHashCode();
            var result2 = point2.GetHashCode();

            // Assert
            Assert.Equal(93, result1);
            Assert.Equal(2145386589, result2);
        }

        [Fact]
        internal void ToStringTest()
        {
            // Arrange
            var point1 = new FuzzyPoint(1, 1);

            // Act
            var result = point1.ToString();

            // Assert
            Assert.Equal("FuzzyPoint: 1, 1", result);
        }
    }
}