// -------------------------------------------------------------------------------------------------
// <copyright file="FuzzyStateTests.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.UnitTests
{
    using System.Diagnostics.CodeAnalysis;
    using FuzzyLogic.Fuzzification;
    using Xunit;

    [SuppressMessage("StyleCop.CSharp.NamingRules", "*", Justification = "Reviewed. Suppression is OK within the Test Suite.")]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "Reviewed. Suppression is OK within the Test Suite.")]
    public class FuzzyStateTests
    {
        [Fact]
        internal void Value_WithString_ReturnsExpectedValue()
        {
            // Arrange
            // Act
            var fuzzyState = FuzzyState.Create("Low");

            // Assert
            Assert.Equal("low", fuzzyState.Value);
        }

        [Fact]
        internal void Equals_WithEqualStates_ReturnsTrue()
        {
            // Arrange
            // Act
            var fuzzyState1 = FuzzyState.Create("Low");
            var fuzzyState2 = FuzzyState.Create("Low");

            // Assert
            Assert.True(fuzzyState1.Equals(fuzzyState2));
        }

        [Fact]
        internal void Equals_WithNullObject_ReturnsFalse()
        {
            // Arrange
            // Act
            var fuzzyState = FuzzyState.Create("Low");

            // Assert
            Assert.False(fuzzyState.Equals(null));
        }

        [Fact]
        internal void Equals_WithDifferentObject_ReturnsFalse()
        {
            // Arrange
            // Act
            var fuzzyState1 = FuzzyState.Create("Low");
            var fuzzyState2 = FuzzyState.Create("Low");

            // Assert
            Assert.True(fuzzyState1.Equals(fuzzyState2));
        }

        [Fact]
        internal void EqualOperator_WithEqualStates_ReturnsTrue()
        {
            // Arrange
            // Act
            var fuzzyState1 = FuzzyState.Create("Low");
            var fuzzyState2 = FuzzyState.Create("Low");

            // Assert
            Assert.True(fuzzyState1 == fuzzyState2);
        }

        [Fact]
        internal void EqualOperator_WithUnequalStates_ReturnsTrue()
        {
            // Arrange
            // Act
            var fuzzyState1 = FuzzyState.Create("High");
            var fuzzyState2 = FuzzyState.Create("Low");

            // Assert
            Assert.False(fuzzyState1 == fuzzyState2);
        }

        [Fact]
        internal void NotEqualOperator_WithEqualStates_ReturnsTrue()
        {
            // Arrange
            // Act
            var fuzzyState1 = FuzzyState.Create("Low");
            var fuzzyState2 = FuzzyState.Create("Low");

            // Assert
            Assert.False(fuzzyState1 != fuzzyState2);
        }

        [Fact]
        internal void NotEqualOperator_WithUnequalStates_ReturnsTrue()
        {
            // Arrange
            // Act
            var fuzzyState1 = FuzzyState.Create("High");
            var fuzzyState2 = FuzzyState.Create("Low");

            // Assert
            Assert.True(fuzzyState1 != fuzzyState2);
        }

        [Fact]
        internal void GetHashcode_ReturnsExpectedValue()
        {
            // Arrange
            var fuzzyState = FuzzyState.Create("High");

            // Act
            var result = fuzzyState.GetHashCode();

            // Assert
            Assert.Equal(-77933506, result);
        }

        [Fact]
        internal void ToString_ReturnsExpectedString()
        {
            // Arrange
            var fuzzyState = FuzzyState.Create("High");

            // Act
            var result = fuzzyState.ToString();

            // Assert
            Assert.Equal("high", result);
        }
    }
}