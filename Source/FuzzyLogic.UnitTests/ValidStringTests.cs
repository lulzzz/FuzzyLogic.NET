// -------------------------------------------------------------------------------------------------
// <copyright file="LabelTests.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.UnitTests
{
    using System.Diagnostics.CodeAnalysis;
    using Xunit;

    [SuppressMessage("StyleCop.CSharp.NamingRules", "*", Justification = "Reviewed. Suppression is OK within the Test Suite.")]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "Reviewed. Suppression is OK within the Test Suite.")]
    public class LabelTests
    {
        [Fact]
        internal void Value_WithString_ReturnsExpectedValue()
        {
            // Arrange
            // Act
            var label = new Label("Temperature");

            // Assert
            Assert.Equal("Temperature", label.Value);
        }

        [Fact]
        internal void Equals_WithEqualStates_ReturnsTrue()
        {
            // Arrange
            // Act
            var label1 = new Label("Temperature");
            var label2 = new Label("Temperature");

            // Assert
            Assert.True(label1.Equals(label2));
        }

        [Fact]
        internal void Equals_WithNullObject_ReturnsFalse()
        {
            // Arrange
            // Act
            var label = new Label("Temperature");

            // Assert
            Assert.False(label.Equals(null));
        }

        [Fact]
        internal void Equals_WithDifferentObject_ReturnsFalse()
        {
            // Arrange
            // Act
            var label1 = new Label("Temperature");
            var label2 = new Label("Temperature");

            // Assert
            Assert.True(label1.Equals(label2));
        }

        [Fact]
        internal void EqualOperator_WithEqualStates_ReturnsTrue()
        {
            // Arrange
            // Act
            var label1 = new Label("Temperature");
            var label2 = new Label("Temperature");

            // Assert
            Assert.True(label1 == label2);
        }

        [Fact]
        internal void EqualOperator_WithUnequalStates_ReturnsTrue()
        {
            // Arrange
            // Act
            var label1 = new Label("Pressure");
            var label2 = new Label("Temperature");

            // Assert
            Assert.False(label1 == label2);
        }

        [Fact]
        internal void NotEqualOperator_WithEqualStates_ReturnsTrue()
        {
            // Arrange
            // Act
            var label1 = new Label("Temperature");
            var label2 = new Label("Temperature");

            // Assert
            Assert.False(label1 != label2);
        }

        [Fact]
        internal void NotEqualOperator_WithUnequalStates_ReturnsTrue()
        {
            // Arrange
            // Act
            var label1 = new Label("Pressure");
            var label2 = new Label("Temperature");

            // Assert
            Assert.True(label1 != label2);
        }

        [Fact]
        internal void GetHashcode_ReturnsExpectedValue()
        {
            // Arrange
            var label = new Label("Pressure");

            // Act
            var result = label.GetHashCode();

            // Assert
            Assert.Equal(1026080277, result);
        }

        [Fact]
        internal void ToString_ReturnsExpectedString()
        {
            // Arrange
            var label = new Label("Pressure");

            // Act
            var result = label.ToString();

            // Assert
            Assert.Equal("Pressure", result);
        }
    }
}
