// -------------------------------------------------------------------------------------------------
// <copyright file="LabelTests.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.Tests
{
    using System.Diagnostics.CodeAnalysis;
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
            var fuzzyState = new FuzzyState("Low");

            // Assert
            Assert.Equal("Low", fuzzyState.Value);
        }

        [Fact]
        internal void Equals_WithEqualStates_ReturnsTrue()
        {
            // Arrange
            // Act
            var fuzzyState1 = new FuzzyState("Low");
            var fuzzyState2 = new FuzzyState("Low");

            // Assert
            Assert.True(fuzzyState1.Equals(fuzzyState2));
        }

        [Fact]
        internal void Equals_WithNullObject_ReturnsFalse()
        {
            // Arrange
            // Act
            var fuzzyState = new FuzzyState("Low");

            // Assert
            Assert.False(fuzzyState.Equals(null));
        }

        [Fact]
        internal void Equals_WithDifferentObject_ReturnsFalse()
        {
            // Arrange
            // Act
            var fuzzyState1 = new FuzzyState("Low");
            var fuzzyState2 = new FuzzyState("Low");

            // Assert
            Assert.True(fuzzyState1.Equals(fuzzyState2));
        }

        [Fact]
        internal void EqualOperator_WithEqualStates_ReturnsTrue()
        {
            // Arrange
            // Act
            var fuzzyState1 = new FuzzyState("Low");
            var fuzzyState2 = new FuzzyState("Low");

            // Assert
            Assert.True(fuzzyState1 == fuzzyState2);
        }

        [Fact]
        internal void EqualOperator_WithUnequalStates_ReturnsTrue()
        {
            // Arrange
            // Act
            var fuzzyState1 = new FuzzyState("High");
            var fuzzyState2 = new FuzzyState("Low");

            // Assert
            Assert.False(fuzzyState1 == fuzzyState2);
        }

        [Fact]
        internal void NotEqualOperator_WithEqualStates_ReturnsTrue()
        {
            // Arrange
            // Act
            var fuzzyState1 = new FuzzyState("Low");
            var fuzzyState2 = new FuzzyState("Low");

            // Assert
            Assert.False(fuzzyState1 != fuzzyState2);
        }

        [Fact]
        internal void NotEqualOperator_WithUnequalStates_ReturnsTrue()
        {
            // Arrange
            // Act
            var fuzzyState1 = new FuzzyState("High");
            var fuzzyState2 = new FuzzyState("Low");

            // Assert
            Assert.True(fuzzyState1 != fuzzyState2);
        }

        [Fact]
        internal void GetHashcode_ReturnsExpectedValue()
        {
            // Arrange
            var fuzzyState = new FuzzyState("High");

            // Act
            var result = fuzzyState.GetHashCode();

            // Assert
            Assert.Equal(-77932258, result);
        }

        [Fact]
        internal void ToString_ReturnsExpectedString()
        {
            // Arrange
            var fuzzyState = new FuzzyState("High");

            // Act
            var result = fuzzyState.ToString();

            // Assert
            Assert.Equal("High", result);
        }
    }
}