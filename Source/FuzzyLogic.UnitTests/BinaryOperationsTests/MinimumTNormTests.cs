// -------------------------------------------------------------------------------------------------
// <copyright file="MinimumTNormTests.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.UnitTests.BinaryOperationsTests
{
    using System.Diagnostics.CodeAnalysis;
    using FuzzyLogic.BinaryOperations;
    using Xunit;

    [SuppressMessage("StyleCop.CSharp.NamingRules", "*", Justification = "Reviewed. Suppression is OK within the Test Suite.")]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "Reviewed. Suppression is OK within the Test Suite.")]
    public class MinimumTNormTests
    {
        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(0, 0.25, 0)]
        [InlineData(0.5, 0.5, 0.5)]
        [InlineData(0.5, 1, 0.5)]
        [InlineData(1, 0.5, 0.5)]
        [InlineData(1, 0.75, 0.75)]
        [InlineData(1, 1, 1)]
        internal void Evaluate_WithVariousValidValues_ReturnsExpectedResult(
            int membershipA,
            int membershipB,
            int expected)
        {
            // Arrange
            var minimumTNorm = new MinimumTNorm();

            // Act
            var result = minimumTNorm.Evaluate(membershipA, membershipB);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}