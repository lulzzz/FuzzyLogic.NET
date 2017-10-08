// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PointTests.cs" author="Christopher Sellers">
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
    public class PointTests
    {
        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(0, 1, 1)]
        [InlineData(0, 10, 10)]
        [InlineData(10, 0, 10)]
        [InlineData(3, 4, 5)]
        [InlineData(-3, 4, 5)]
        [InlineData(3, -4, 5)]
        [InlineData(-3, -4, 5)]
        [InlineData(0.3, 0.4, 0.5)]
        internal void EuclideanNormTest(double x, double y, double expectedNorm)
        {
            // Arrange
            var point = new Point(x, y);

            // Act
            var result = point.EuclideanNorm();

            // Assert
            Assert.Equal(result, expectedNorm);
        }

        [Theory]
        [InlineData(1.1f, 2.2f, 1.1f, 2.2f, true)]
        [InlineData(1.1f, 2.2f, 3.3f, 2.2f, false)]
        [InlineData(1.1f, 2.2f, 1.1f, 4.4f, false)]
        [InlineData(1.1f, 2.2f, 3.3f, 4.4f, false)]
        internal void EqualityOperatorTest(double x1, double y1, double x2, double y2, bool areEqual)
        {
            // Arrange
            // Act
            var point1 = new Point(x1, y1);
            var point2 = new Point(x2, y2);

            // Assert
            Assert.Equal(point1 == point2, areEqual);
        }

        [Theory]
        [InlineData(1.1f, 2.2f, 1.1f, 2.2f, false)]
        [InlineData(1.1f, 2.2f, 3.3f, 2.2f, true)]
        [InlineData(1.1f, 2.2f, 1.1f, 4.4f, true)]
        [InlineData(1.1f, 2.2f, 3.3f, 4.4f, true)]
        internal void InequalityOperatorTest(double x1, double y1, double x2, double y2, bool areNotEqual)
        {
            // Arrange
            // Act
            var point1 = new Point(x1, y1);
            var point2 = new Point(x2, y2);

            // Assert
            Assert.Equal(point1 != point2, areNotEqual);
        }
    }
}