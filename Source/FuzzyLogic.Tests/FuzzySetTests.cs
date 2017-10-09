﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FuzzySetTests.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace FuzzyLogic.Tests
{
    using System.Diagnostics.CodeAnalysis;

    using FuzzyLogic.MembershipFunctions;

    using Xunit;

    /// <summary>
    /// The <see cref="FuzzySet"/> tests.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.NamingRules", "*", Justification = "Reviewed. Suppression is OK within the Test Suite.")]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "Reviewed. Suppression is OK within the Test Suite.")]
    public class FuzzySetTests
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 0)]
        [InlineData(2, 0)]
        [InlineData(3, 1)]
        [InlineData(5, 0)]
        [InlineData(2.5, 0.5)]
        [InlineData(3.5, 0.5)]
        internal void GetMembership_VariousInputs_ReturnsExpectedResult(double input, double expected)
        {
            // Arrange
            var function = new TriangularFunction(2, 3, 4);
            var fuzzySet = new FuzzySet("fuzzySet", function);

            // Act
            var result = fuzzySet.GetMembership(input);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
