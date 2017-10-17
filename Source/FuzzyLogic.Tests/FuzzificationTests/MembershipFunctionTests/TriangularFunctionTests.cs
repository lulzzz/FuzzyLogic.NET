﻿// -------------------------------------------------------------------------------------------------
// <copyright file="TriangularFunctionTests.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.Tests.FuzzificationTests.MembershipFunctionTests
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    using FuzzyLogic.Fuzzification.MembershipFunctions;

    using Xunit;

    /// <summary>
    /// The trapezoidal function tests.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.NamingRules", "*", Justification = "Reviewed. Suppression is OK within the Test Suite.")]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "Reviewed. Suppression is OK within the Test Suite.")]
    public class TriangularFunctionTests
    {
        [Fact]
        internal void Instantiation_WhenMinYGreaterThanMaxY_Throws()
        {
            // Arrange
            // Act
            // Assert
            Assert.Throws<ArgumentException>(() => TriangularFunction.Create(1, 2, 3, 1, 0));
        }

        [Theory]
        [InlineData(2, 3, 4, 0, 0)]
        [InlineData(2, 3, 4, 1, 0)]
        [InlineData(2, 3, 4, 2, 0)]
        [InlineData(2, 3, 4, 3, 1)]
        [InlineData(2, 3, 4, 5, 0)]
        [InlineData(2, 3, 4, 2.5, 0.5)]
        [InlineData(2, 3, 4, 3.5, 0.5)]
        [InlineData(2, 3, 4, double.MaxValue, 0)]
        internal void GetMembership_VariousInputs_ReturnsExpectedResult(
            double x1,
            double x2,
            double x3,
            double input,
            double expected)
        {
            // Arrange
            var function = TriangularFunction.Create(x1, x2, x3);

            // Act
            var result = function.GetMembership(input);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}