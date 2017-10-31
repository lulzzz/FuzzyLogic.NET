// -------------------------------------------------------------------------------------------------
// <copyright file="ProbabilisticSumTests.cs" author="Christopher Sellers">
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
    public class ProbabilisticSumTests
    {
        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(0, 0.25, 0.25)]
        [InlineData(0.5, 0.5, 0.75)]
        [InlineData(0.5, 1, 1)]
        [InlineData(1, 0.5, 1)]
        [InlineData(1, 0.75, 1)]
        [InlineData(1, 1, 1)]
        internal void Evaluate_WithVariousValidValues_ReturnsExpectedResult(
            double membershipA,
            double membershipB,
            double expected)
        {
            // Arrange
            var algebraicProduct = new ProbabilisticSum();

            // Act
            var result = algebraicProduct.Evaluate(membershipA, membershipB);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}