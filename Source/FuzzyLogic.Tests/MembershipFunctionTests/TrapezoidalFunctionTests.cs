// -------------------------------------------------------------------------------------------------
// <copyright file="TrapezoidalFunctionTests.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.Tests.MembershipFunctionTests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using FuzzyLogic.MembershipFunctions;
    using Xunit;

    /// <summary>
    /// The trapezoidal function tests.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.NamingRules", "*", Justification = "Reviewed. Suppression is OK within the Test Suite.")]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "Reviewed. Suppression is OK within the Test Suite.")]
    public class TrapezoidalFunctionTests
    {
        [Fact]
        internal void Instantiation_WhenMinYGreaterThanMaxY_Throws()
        {
            // Arrange
            // Act
            // Assert
            Assert.Throws<ArgumentException>(() => TrapezoidalFunction.Create(1, 2, 3, 4, 1, 0.5));
        }

        [Theory]
        [InlineData(2, 3, 4, 5, 0, 0)]
        [InlineData(2, 3, 4, 5, 1, 0)]
        [InlineData(2, 3, 4, 5, 2, 0)]
        [InlineData(2, 3, 4, 5, 3, 1)]
        [InlineData(2, 3, 4, 5, 4, 1)]
        [InlineData(2, 3, 4, 5, 5, 0)]
        [InlineData(2, 3, 4, 5, 6, 0)]
        [InlineData(2, 3, 4, 5, 2.5, 0.5)]
        [InlineData(2, 3, 4, 5, 4.5, 0.5)]
        [InlineData(2, 3, 4, 5, double.MaxValue, 0)]
        internal void Create_GetMembershipWithVariousInputs_ReturnsExpectedResult(
            double x1,
            double x2,
            double x3,
            double x4,
            double input,
            double expected)
        {
            // Arrange
            var function = TrapezoidalFunction.Create(x1, x2, x3, x4);

            // Act
            var result = function.GetMembership(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(2, 3, 0, 0)]
        [InlineData(2, 3, 1, 0)]
        [InlineData(2, 3, 2, 0)]
        [InlineData(2, 3, 3, 1)]
        [InlineData(2, 3, 4, 1)]
        [InlineData(2, 3, 2.5, 0.5)]
        [InlineData(2, 3, double.MaxValue, 1)]
        internal void CreateWithRightEdge_GetMembershipWithVariousInputs_ReturnsExpectedResult(
            double x1,
            double x2,
            double input,
            double expected)
        {
            // Arrange
            var function = TrapezoidalFunction.CreateWithRightEdge(x1, x2);

            // Act
            var result = function.GetMembership(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(2, 3, 0, 1)]
        [InlineData(2, 3, 1, 1)]
        [InlineData(2, 3, 2, 1)]
        [InlineData(2, 3, 3, 0)]
        [InlineData(2, 3, 4, 0)]
        [InlineData(2, 3, 2.5, 0.5)]
        [InlineData(2, 3, double.MaxValue, 0)]
        internal void CreateWithLeftEdge_GetMembershipWithVariousInputs_ReturnsExpectedResult(
            double x1,
            double x2,
            double input,
            double expected)
        {
            // Arrange
            var function = TrapezoidalFunction.CreateWithLeftEdge(x1, x2);

            // Act
            var result = function.GetMembership(input);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}