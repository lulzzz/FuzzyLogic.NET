// -------------------------------------------------------------------------------------------------
// <copyright file="LinguisticVariableTests.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.UnitTests
{
    using System.Diagnostics.CodeAnalysis;
    using FuzzyLogic.TestKit.Stubs;
    using Xunit;

    [SuppressMessage("StyleCop.CSharp.NamingRules", "*", Justification = "Reviewed. Suppression is OK within the Test Suite.")]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "Reviewed. Suppression is OK within the Test Suite.")]
    public class LinguisticVariableTests
    {
        [Fact]
        internal void GetLabel_ReturnsExpectedLabel()
        {
            // Arrange
            var temperature = StubLinguisticVariableFactory.CreateTemperature();

            // Act
            var result = temperature.Label;

            // Assert
            Assert.Equal(Label.Create("Temperature"), result);
        }

        [Fact]
        internal void GetLowerBound_ReturnsExpectedDouble()
        {
            // Arrange
            var temperature = StubLinguisticVariableFactory.CreateTemperature();

            // Act
            var result = temperature.LowerBound;

            // Assert
            Assert.Equal(-20, result);
        }

        [Fact]
        internal void GetUpperBound_ReturnsExpectedDouble()
        {
            // Arrange
            var temperature = StubLinguisticVariableFactory.CreateTemperature();

            // Act
            var result = temperature.UpperBound;

            // Assert
            Assert.Equal(200, result);
        }

        [Theory]
        [InlineData(0, "frozen", 1)]
        [InlineData(1, "freezing", 0.2)]
        [InlineData(10, "cold", 1)]
        [InlineData(10, "warm", 0)]
        [InlineData(40, "hot", 0.2)]
        [InlineData(100, "boiling", 1)]
        internal void GetMembership_ReturnsExpectedDouble(double input, string label, double membershipValue)
        {
            // Arrange
            var temperature = StubLinguisticVariableFactory.CreateTemperature();

            // Act
            var result = temperature.GetMembership(Label.Create(label), input);

            // Assert
            Assert.Equal(membershipValue, result);
        }

        [Theory]
        [InlineData(-20, "frozen")]
        [InlineData(0, "frozen")]
        [InlineData(5, "freezing")]
        [InlineData(10, "cold")]
        [InlineData(15, "cold")]
        [InlineData(20, "warm")]
        [InlineData(25, "warm")]
        [InlineData(30, "warm")]
        [InlineData(35, "warm")]
        [InlineData(40, "hot")]
        [InlineData(80, "hot")]
        [InlineData(100, "boiling")]
        [InlineData(200, "boiling")]
        internal void GetState_ReturnsExpectedState(double input, string state)
        {
            // Arrange
            var temperature = StubLinguisticVariableFactory.CreateTemperature();

            // Act
            var result = temperature.GetState(input);

            // Assert
            Assert.Equal(FuzzyState.Create(state), result);
        }

        [Fact]
        internal void IsMember_WhenVariableContainsMember_ReturnsTrue()
        {
            // Arrange
            var temperature = StubLinguisticVariableFactory.CreateTemperature();

            // Act
            var result = temperature.IsMember(Label.Create("frozen"));

            // Assert
            Assert.True(result);
        }

        [Fact]
        internal void IsMember_WhenVariableDoesNotContainMember_ReturnsTrue()
        {
            // Arrange
            var temperature = StubLinguisticVariableFactory.CreateTemperature();

            // Act
            var result = temperature.IsMember(Label.Create("vapour"));

            // Assert
            Assert.False(result);
        }

        [Fact]
        internal void GetSet_ReturnsTheFuzzySet()
        {
            // Arrange
            var temperature = StubLinguisticVariableFactory.CreateTemperature();

            // Act
            var result = temperature.GetSet(Label.Create("frozen"));

            // Assert
            Assert.Equal(Label.Create("frozen"), result.Label);
        }

        [Fact]
        internal void GetMembers_ReturnsTheListOfMembers()
        {
            // Arrange
            var temperature = StubLinguisticVariableFactory.CreateTemperature();

            // Act
            var result = temperature.GetMembers();

            // Assert
            Assert.Equal(6, result.Count);
        }
    }
}