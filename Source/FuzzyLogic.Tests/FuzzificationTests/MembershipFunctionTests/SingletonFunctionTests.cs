﻿// -------------------------------------------------------------------------------------------------
// <copyright file="SingletonFunctionTests.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.Tests.FuzzificationTests.MembershipFunctionTests
{
    using System.Diagnostics.CodeAnalysis;

    using FuzzyLogic.Fuzzification.MembershipFunctions;

    using Xunit;

    /// <summary>
    /// The membership function tests.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.NamingRules", "*", Justification = "Reviewed. Suppression is OK within the Test Suite.")]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "Reviewed. Suppression is OK within the Test Suite.")]
    public class SingletonFunctionTests
    {
        [Theory]
        [InlineData(0, 0, 1)]
        [InlineData(1, 0, 0)]
        [InlineData(1, 2, 0)]
        [InlineData(1, 1, 1)]
        [InlineData(double.MaxValue, double.MaxValue, 1)]
        internal void GetMembership_VariousInputs_ReturnsExpectedResult(double x, double input, double expected)
        {
            // Arrange
            var function = SingletonFunction.Create(x);

            // Act
            var result = function.GetMembership(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        internal void MinY_ReturnsExpectedResult()
        {
            // Arrange
            var function = SingletonFunction.Create(1);

            // Act
            var result = function.MinY;

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        internal void MaxY_ReturnsExpectedResult()
        {
            // Arrange
            var function = SingletonFunction.Create(1);

            // Act
            var result = function.MaxY;

            // Assert
            Assert.Equal(1, result);
        }

        [Fact]
        internal void LowerBound_ReturnsExpectedResult()
        {
            // Arrange
            var function = SingletonFunction.Create(1);

            // Act
            var result = function.LowerBound;

            // Assert
            Assert.Equal(1, result);
        }

        [Fact]
        internal void UpperBound_ReturnsExpectedResult()
        {
            // Arrange
            var function = SingletonFunction.Create(1);

            // Act
            var result = function.UpperBound;

            // Assert
            Assert.Equal(1, result);
        }
    }
}