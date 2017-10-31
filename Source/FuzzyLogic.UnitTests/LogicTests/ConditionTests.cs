// -------------------------------------------------------------------------------------------------
// <copyright file="ConditionTests.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.UnitTests.LogicTests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using FuzzyLogic.Logic;
    using FuzzyLogic.TestKit;
    using FuzzyLogic.TestKit.Stubs;
    using Xunit;

    [SuppressMessage("StyleCop.CSharp.NamingRules", "*", Justification = "Reviewed. Suppression is OK within the Test Suite.")]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "Reviewed. Suppression is OK within the Test Suite.")]
    public class ConditionTests
    {
        [Fact]
        internal void Validate_WhenConnectiveNull_Throws()
        {
            // Arrange
            var condition = Condition.Create();

            // Act
            // Assert
            Assert.Throws<InvalidOperationException>(() => condition.Validate());
        }

        [Fact]
        internal void Validate_WhenNoPremises_Throws()
        {
            // Arrange
            var condition = Condition.Create();
            condition.SetConnective(LogicOperators.If());

            // Act
            // Assert
            Assert.Throws<InvalidOperationException>(() => condition.Validate());
        }

        [Fact]
        internal void SetConnective_WhenConnectiveNotSet_SetsExpectedConnective()
        {
            // Arrange
            var condition = Condition.Create();

            // Act
            condition.SetConnective(LogicOperators.If());

            // Assert
            Assert.Equal(LogicOperators.If(), condition.Connective);
        }

        [Fact]
        internal void SetConnective_WhenConnectiveAlreadySet_Throws()
        {
            // Arrange
            var condition = Condition.Create();
            condition.SetConnective(LogicOperators.If());

            // Act
            // Assert
            Assert.Throws<InvalidOperationException>(() => condition.SetConnective(LogicOperators.If()));
        }

        [Fact]
        internal void SetWeight_SetsWeightToExpectedValue()
        {
            // Arrange
            var condition = Condition.Create(1.0);
            condition.SetConnective(LogicOperators.If());

            // Act
            condition.SetWeight(0.5);

            // Assert
            Assert.Equal(0.5, condition.Weight);
        }

        [Fact]
        internal void Evaluate_WhenInvalidData_Throws()
        {
            // Arrange
            var waterTemp = StubLinguisticVariableFactory.WaterTemp();

            var condition = Condition.Create().If(waterTemp.Is(WaterTemp.Boiling));
            condition.SetConnective(LogicOperators.If());
            condition.Validate();

            var data = new Dictionary<Label, double> { { Label.Create(InputVariable.Pressure), 3000 } };

            // Act
            // Assert
            Assert.Throws<InvalidOperationException>(() => condition.Evaluate(data));
        }

        [Fact]
        internal void ToString_ReturnsExpectedString()
        {
            // Arrange
            var waterTemp = StubLinguisticVariableFactory.WaterTemp();

            var condition = Condition.Create()
                .If(waterTemp.IsNot(WaterTemp.Boiling))
                .And(waterTemp.IsNot(WaterTemp.Freezing))
                .And(waterTemp.IsNot(WaterTemp.Frozen));

            condition.SetConnective(LogicOperators.If());
            condition.Validate();

            // Act
            var result = condition.ToString();

            // Assert
            Assert.Equal("IF WaterTemp IS-NOT boiling AND WaterTemp IS-NOT freezing AND WaterTemp IS-NOT frozen", result);
        }
    }
}