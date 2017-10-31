// -------------------------------------------------------------------------------------------------
// <copyright file="IsNotTests.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.UnitTests.LogicTests.LogicOperatorsTests
{
    using System.Diagnostics.CodeAnalysis;
    using FuzzyLogic.Logic;
    using Xunit;

    [SuppressMessage("StyleCop.CSharp.NamingRules", "*", Justification = "Reviewed. Suppression is OK within the Test Suite.")]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "Reviewed. Suppression is OK within the Test Suite.")]
    public class IsNotTests
    {
        [Theory]
        [InlineData(0, 1)]
        [InlineData(0.25, 0.75)]
        [InlineData(0.5, 0.5)]
        [InlineData(0.75, 0.25)]
        [InlineData(1, 0)]
        internal void Evaluate_WithVariousValues_ReturnsExpectedResult(double membership, double expected)
        {
            // Arrange
            var isNotOperator = LogicOperators.IsNot();

            // Act
            var result = isNotOperator.Evaluate(membership);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}