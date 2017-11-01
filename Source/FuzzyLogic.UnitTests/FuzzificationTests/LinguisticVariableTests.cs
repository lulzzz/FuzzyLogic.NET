// -------------------------------------------------------------------------------------------------
// <copyright file="LinguisticVariableTests.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.UnitTests.FuzzificationTests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using FuzzyLogic.Fuzzification;
    using FuzzyLogic.TestKit;
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
            var temperature = StubLinguisticVariableFactory.WaterTemp();

            // Act
            var result = temperature.Subject;

            // Assert
            Assert.Equal(Label.Create(InputVariable.WaterTemp), result);
        }

        [Fact]
        internal void GetLowerBound_ReturnsExpectedDouble()
        {
            // Arrange
            var temperature = StubLinguisticVariableFactory.WaterTemp();

            // Act
            var result = temperature.LowerBound;

            // Assert
            Assert.Equal(-20, result);
        }

        [Fact]
        internal void GetUpperBound_ReturnsExpectedDouble()
        {
            // Arrange
            var temperature = StubLinguisticVariableFactory.WaterTemp();

            // Act
            var result = temperature.UpperBound;

            // Assert
            Assert.Equal(200, result);
        }

        [Theory]
        [InlineData(0, WaterTemp.Frozen, 1)]
        [InlineData(1, WaterTemp.Freezing, 0.2)]
        [InlineData(10, WaterTemp.Cold, 1)]
        [InlineData(10, WaterTemp.Warm, 0)]
        [InlineData(40, WaterTemp.Hot, 0.2)]
        [InlineData(100, WaterTemp.Boiling, 1)]
        internal void GetMembership_ReturnsExpectedDouble(double input, Enum label, double membershipValue)
        {
            // Arrange
            var temperature = StubLinguisticVariableFactory.WaterTemp();

            // Act
            var result = temperature.GetMembership(label, input);

            // Assert
            Assert.Equal(UnitInterval.Create(membershipValue), result);
        }

        [Theory]
        [InlineData(-20, WaterTemp.Frozen)]
        [InlineData(0, WaterTemp.Frozen)]
        [InlineData(5, WaterTemp.Freezing)]
        [InlineData(10, WaterTemp.Cold)]
        [InlineData(15, WaterTemp.Cold)]
        [InlineData(20, WaterTemp.Warm)]
        [InlineData(25, WaterTemp.Warm)]
        [InlineData(30, WaterTemp.Warm)]
        [InlineData(35, WaterTemp.Warm)]
        [InlineData(40, WaterTemp.Hot)]
        [InlineData(80, WaterTemp.Hot)]
        [InlineData(100, WaterTemp.Boiling)]
        [InlineData(200, WaterTemp.Boiling)]
        internal void GetState_ReturnsExpectedState(double input, Enum state)
        {
            // Arrange
            var temperature = StubLinguisticVariableFactory.WaterTemp();

            // Act
            var result = temperature.GetState(input);

            // Assert
            Assert.Equal(FuzzyState.Create(state), result);
        }

        [Fact]
        internal void IsMember_WhenVariableContainsMember_ReturnsTrue()
        {
            // Arrange
            var temperature = StubLinguisticVariableFactory.WaterTemp();

            // Act
            var result = temperature.IsMember(WaterTemp.Frozen);

            // Assert
            Assert.True(result);
        }

        [Fact]
        internal void IsMember_WhenVariableDoesNotContainMember_ReturnsTrue()
        {
            // Arrange
            var temperature = StubLinguisticVariableFactory.WaterTemp();

            // Act
            var result = temperature.IsMember(FuzzyState.Create("vapour"));

            // Assert
            Assert.False(result);
        }

        [Fact]
        internal void GetSet_ReturnsTheFuzzySet()
        {
            // Arrange
            var temperature = StubLinguisticVariableFactory.WaterTemp();

            // Act
            var result = temperature.GetSet(WaterTemp.Frozen);

            // Assert
            Assert.Equal(FuzzyState.Create("frozen"), result.State);
        }

        [Fact]
        internal void GetMembers_ReturnsTheListOfMembers()
        {
            // Arrange
            var temperature = StubLinguisticVariableFactory.WaterTemp();

            // Act
            var result = temperature.GetMembers();

            // Assert
            Assert.Equal(6, result.Count);
        }
    }
}