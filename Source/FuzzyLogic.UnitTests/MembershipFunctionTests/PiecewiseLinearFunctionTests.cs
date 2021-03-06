﻿// -------------------------------------------------------------------------------------------------
// <copyright file="PiecewiseLinearFunctionTests.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.UnitTests.MembershipFunctionTests
{
    using System.Diagnostics.CodeAnalysis;
    using FuzzyLogic.Fuzzification;
    using FuzzyLogic.MembershipFunctions;
    using Xunit;

    [SuppressMessage("StyleCop.CSharp.NamingRules", "*", Justification = "Reviewed. Suppression is OK within the Test Suite.")]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "Reviewed. Suppression is OK within the Test Suite.")]
    public class PiecewiseLinearFunctionTests
    {
        [Theory]
        [InlineData(1, 0.5)]
        [InlineData(2, 0.5)]
        [InlineData(3, 1)]
        [InlineData(4, 1)]
        internal void GetMembership_WithVariousInputs_ReturnsExpectedResult(double x, double expected)
        {
            // Arrange
            var points = new FuzzyPoint[]
                             {
                                 new FuzzyPoint(2, 0.5),
                                 new FuzzyPoint(3, 1)
                             };

            var function = new PiecewiseLinearFunction(points);

            // Act
            var result = function.GetMembership(x);

            // Assert
            Assert.Equal(UnitInterval.Create(expected), result);
        }

        [Fact]
        internal void MinY_ReturnsExpectedResult()
        {
            // Arrange
            // Arrange
            var points = new FuzzyPoint[]
                             {
                                 new FuzzyPoint(2, 0),
                                 new FuzzyPoint(3, 1)
                             };

            var function = new PiecewiseLinearFunction(points);

            // Act
            var result = function.MinY;

            // Assert
            Assert.Equal(UnitInterval.Zero(), result);
        }

        [Fact]
        internal void MaxY_ReturnsExpectedResult()
        {
            // Arrange
            // Arrange
            var points = new FuzzyPoint[]
                             {
                                 new FuzzyPoint(2, 0),
                                 new FuzzyPoint(3, 1)
                             };

            var function = new PiecewiseLinearFunction(points);

            // Act
            var result = function.MaxY;

            // Assert
            Assert.Equal(UnitInterval.One(), result);
        }

        [Fact]
        internal void LowerBound_ReturnsExpectedResult()
        {
            // Arrange
            // Arrange
            var points = new FuzzyPoint[]
                             {
                                 new FuzzyPoint(2, 0.5),
                                 new FuzzyPoint(3, 1)
                             };

            var function = new PiecewiseLinearFunction(points);

            // Act
            var result = function.LowerBound;

            // Assert
            Assert.Equal(2, result);
        }

        [Fact]
        internal void UpperBound_ReturnsExpectedResult()
        {
            // Arrange
            // Arrange
            var points = new FuzzyPoint[]
                             {
                                 new FuzzyPoint(2, 0.5),
                                 new FuzzyPoint(3, 1)
                             };

            var function = new PiecewiseLinearFunction(points);

            // Act
            var result = function.UpperBound;

            // Assert
            Assert.Equal(3, result);
        }
    }
}