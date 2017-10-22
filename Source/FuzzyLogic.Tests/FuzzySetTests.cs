// -------------------------------------------------------------------------------------------------
// <copyright file="FuzzySetTests.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

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
            var function = TriangularFunction.Create(2, 3, 4);
            var fuzzySet = new FuzzySet("fuzzySet", function);

            // Act
            var result = fuzzySet.GetMembership(input);

            // Assert
            Assert.Equal(expected, result);
            Assert.Equal("fuzzySet", fuzzySet.Label.Value);
        }

        [Fact]
        internal void IsNormal_WhenSetNormal_ReturnsTrue()
        {
            // Arrange
            var function = TriangularFunction.Create(2, 3, 4);
            var fuzzySet = new FuzzySet("fuzzySet", function);

            // Act
            var result = fuzzySet.IsNormal;

            // Assert
            Assert.True(result);
        }

        [Fact]
        internal void IsNormal_WhenSetNotNormal_ReturnsFalse()
        {
            // Arrange
            var function = TriangularFunction.Create(2, 3, 4, 0, 0.9);
            var fuzzySet = new FuzzySet("fuzzySet", function);

            // Act
            var result = fuzzySet.IsNormal;

            // Assert
            Assert.False(result);
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(3, 0)]
        [InlineData(2.5, 0.5)]
        [InlineData(3.5, 0.5)]
        internal void Complement_VariousInputs_ReturnsExpectedResult(double input, double expected)
        {
            // Arrange
            var function = TriangularFunction.Create(2, 3, 4);
            var fuzzySet = new FuzzySet("fuzzySet", function);

            // Act
            var result = fuzzySet.Complement(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 0)]
        [InlineData(2, 0)]
        [InlineData(3, 1)]
        [InlineData(4, 0.75)]
        [InlineData(5, 0)]
        [InlineData(6, 0)]
        internal void Union_VariousInputs_ReturnsExpectedResult(double input, double expected)
        {
            // Arrange
            var function1 = TriangularFunction.Create(2, 3, 4);
            var function2 = TriangularFunction.Create(3, 4, 5, 0, 0.75);
            var fuzzySet1 = new FuzzySet("fuzzySet1", function1);
            var fuzzySet2 = new FuzzySet("fuzzySet2", function2);

            // Act
            var result = fuzzySet1.Union(fuzzySet2, input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 0)]
        [InlineData(2, 0)]
        [InlineData(3, 0.375)]
        [InlineData(4, 0.5)]
        [InlineData(5, 0)]
        [InlineData(6, 0)]
        internal void Intersection_VariousInputs_ReturnsExpectedResult(double input, double expected)
        {
            // Arrange
            var function1 = TriangularFunction.Create(1, 3, 5);
            var function2 = TriangularFunction.Create(2, 4, 6, 0, 0.75);
            var fuzzySet1 = new FuzzySet("fuzzySet1", function1);
            var fuzzySet2 = new FuzzySet("fuzzySet2", function2);

            // Act
            var result = fuzzySet1.Intersection(fuzzySet2, input);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}