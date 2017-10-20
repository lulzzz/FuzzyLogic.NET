// -------------------------------------------------------------------------------------------------
// <copyright file="AlgebraicOperationsTests.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.Tests.MathematicsTests
{
    using System.Diagnostics.CodeAnalysis;
    using FuzzyLogic.Mathematics;
    using Xunit;

    /// <summary>
    /// The algebraic operations tests.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.NamingRules", "*", Justification = "Reviewed. Suppression is OK within the Test Suite.")]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "Reviewed. Suppression is OK within the Test Suite.")]
    public class AlgebraicOperationsTests
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(2, 4)]
        [InlineData(3, 9)]
        internal void Square_WithVariousInputs_ReturnsExpectedResult(double input, double expected)
        {
            // Arrange
            var number = input;

            // Act
            var result = number.Square();

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(4, 2)]
        [InlineData(9, 3)]
        internal void SquareRoot_WithVariousInputs_ReturnsExpectedResult(double input, double expected)
        {
            // Arrange
            var number = input;

            // Act
            var result = number.SquareRoot();

            // Assert
            Assert.Equal(expected, result);
        }
    }
}