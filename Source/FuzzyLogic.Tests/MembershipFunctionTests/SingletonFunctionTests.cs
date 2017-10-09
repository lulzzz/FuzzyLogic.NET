// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SingletonFunctionTests.cs" author="Christopher Sellers">
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
    /// The membership function tests.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.NamingRules", "*", Justification = "Reviewed. Suppression is OK within the Test Suite.")]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "Reviewed. Suppression is OK within the Test Suite.")]
    public class SingletonFunctionTests
    {
        [Theory]
        [InlineData(1, 0, 0)]
        [InlineData(1, 2, 0)]
        [InlineData(1, 1, 1)]
        internal void GetMembership_VariousInputs_ReturnsExpectedResult(double x, double input, double expected)
        {
            // Arrange
            var function = new SingletonFunction(x);

            // Act
            var result = function.GetMembership(NonNegativeDouble.Create(input));

            // Assert
            Assert.Equal(MembershipValue.Create(expected), result);
        }

        [Fact]
        internal void LowerBound_ReturnsExpectedResult()
        {
            // Arrange
            var function = new SingletonFunction(1);

            // Act
            var result = function.LowerBound;

            // Assert
            Assert.Equal(NonNegativeDouble.Create(1), result);
        }

        [Fact]
        internal void UpperBound_ReturnsExpectedResult()
        {
            // Arrange
            var function = new SingletonFunction(1);

            // Act
            var result = function.UpperBound;

            // Assert
            Assert.Equal(NonNegativeDouble.Create(1), result);
        }
    }
}
