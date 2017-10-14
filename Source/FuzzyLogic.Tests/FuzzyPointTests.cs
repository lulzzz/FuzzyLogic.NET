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
    /// The fuzzy point tests.
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

            // Act
            var result1 = point1.Add(point2);
            var result2 = point1 + point2;

            // Assert
            Assert.Equal(new FuzzyPoint(point3x, point3y), result1);
            Assert.Equal(new FuzzyPoint(point3x, point3y), result2);
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

            // Act
            var result1 = point1.Subtract(point2);
            var result2 = point1 - point2;

            // Assert
            Assert.Equal(new FuzzyPoint(point3x, point3y), result1);
            Assert.Equal(new FuzzyPoint(point3x, point3y), result2);
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
    }
}