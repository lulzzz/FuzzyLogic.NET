﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PiecewiseLinearFunctionTests.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace FuzzyLogic.Tests.MembershipFunctionTests
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    using FuzzyLogic.MembershipFunctions;

    using Xunit;

    /// <summary>
    /// The piecewise linear function tests.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.NamingRules", "*", Justification = "Reviewed. Suppression is OK within the Test Suite.")]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "Reviewed. Suppression is OK within the Test Suite.")]
    public class PiecewiseLinearFunctionTests
    {
        [Fact]
        internal void GetMembership_WithEmptyArray_ReturnsZero()
        {
            // Arrange
            var points = new FuzzyPoint[0];

            var function = new PiecewiseLinearFunction(points);

            // Act
            var result = function.GetMembership(NonNegativeDouble.Create(1));

            // Assert
            Assert.Equal(MembershipValue.Zero(), result);
        }

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
            var result = function.GetMembership(NonNegativeDouble.Create(x));

            // Assert
            Assert.Equal(MembershipValue.Create(expected), result);
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
            Assert.Equal(NonNegativeDouble.Create(2), result);
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
            Assert.Equal(NonNegativeDouble.Create(3), result);
        }

        [Fact]
        internal void InitializeFunction_WithOutOfSequencePoints_Throws()
        {
            // Arrange
            // Arrange
            var points = new FuzzyPoint[]
                             {
                                 new FuzzyPoint(2, 0.5),
                                 new FuzzyPoint(4, 0.5), // X out of sequence
                                 new FuzzyPoint(3, 1)
                             };

            // Act
            // Assert
            Assert.Throws<ArgumentException>(() => new PiecewiseLinearFunction(points));
        }
    }
}