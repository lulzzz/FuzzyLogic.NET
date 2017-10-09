// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TrapezoidalFunctionTests.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace FuzzyLogic.Tests.MembershipFunctionTests
{
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
        internal void GetMembership_VariousInputs_ReturnsExpectedResult(
            double x1,
            double x2,
            double x3,
            double x4,
            double input,
            double expected)
        {
            // Arrange
            var function = new TrapezoidalFunction(x1, x2, x3, x4);

            // Act
            var result = function.GetMembership(NonNegativeDouble.Create(input));

            // Assert
            Assert.Equal(MembershipValue.Create(expected), result);
        }

        [Theory]
        [InlineData(2, 3, 5, 0, 0)]
        [InlineData(2, 3, 5, 1, 0)]
        [InlineData(2, 3, 5, 2, 0)]
        [InlineData(2, 3, 5, 3, 1)]
        [InlineData(2, 3, 5, 4, 1)]
        [InlineData(2, 3, 5, 5, 1)]
        [InlineData(2, 3, 5, 6, 1)]
        [InlineData(2, 3, 5, 2.5, 0.5)]
        internal void Create_LeftEdgeType_ReturnsExpectedResult(
            double x1,
            double x2,
            double x3,
            double input,
            double expected)
        {
            // Arrange
            var function = TrapezoidalFunction.Create(x1, x2, x3, TrapezoidalFunction.EdgeType.Left);

            // Act
            var result = function.GetMembership(NonNegativeDouble.Create(input));

            // Assert
            Assert.Equal(MembershipValue.Create(expected), result);
        }

        [Theory]
        [InlineData(2, 4, 5, 0, 1)]
        [InlineData(2, 4, 5, 1, 1)]
        [InlineData(2, 4, 5, 2, 1)]
        [InlineData(2, 4, 5, 3, 1)]
        [InlineData(2, 4, 5, 4, 1)]
        [InlineData(2, 4, 5, 5, 0)]
        [InlineData(2, 4, 5, 6, 0)]
        [InlineData(2, 4, 5, 4.5, 0.5)]
        internal void Create_RightEdgeType_ReturnsExpectedResult(
            double x1,
            double x2,
            double x3,
            double input,
            double expected)
        {
            // Arrange
            var function = TrapezoidalFunction.Create(x1, x2, x3, TrapezoidalFunction.EdgeType.Right);

            // Act
            var result = function.GetMembership(NonNegativeDouble.Create(input));

            // Assert
            Assert.Equal(MembershipValue.Create(expected), result);
        }
    }
}