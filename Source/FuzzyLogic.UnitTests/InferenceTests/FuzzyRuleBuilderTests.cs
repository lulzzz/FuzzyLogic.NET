// -------------------------------------------------------------------------------------------------
// <copyright file="FuzzyRuleBuilderTests.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.UnitTests.InferenceTests
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using FuzzyLogic.Inference;
    using FuzzyLogic.TestKit;
    using FuzzyLogic.TestKit.Stubs;
    using Xunit;

    [SuppressMessage("StyleCop.CSharp.NamingRules", "*", Justification = "Reviewed. Suppression is OK within the Test Suite.")]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "Reviewed. Suppression is OK within the Test Suite.")]
    public class FuzzyRuleBuilderTests
    {
        [Fact]
        internal void Build_WhenConditionsAndConclusionsAreValid_ReturnsExpectedRuzzyRule()
        {
            // Arrange
            var waterTemp = StubLinguisticVariableFactory.WaterTemp();
            var pumpSpeed = StubLinguisticVariableFactory.PumpSpeed();

            // Act
            var fuzzyRule = new FuzzyRuleBuilder(PumpSpeedRule.Rule0)
                .If(waterTemp.Is(WaterTemp.Warm))
                .And(waterTemp.Not(WaterTemp.Frozen))
                .Then(pumpSpeed.Is(PumpSpeed.Moderate))
                .Build();

            // Assert
            Assert.Equal(Label.Create(PumpSpeedRule.Rule0), fuzzyRule.Label);
            Assert.Equal(2, fuzzyRule.Conditions.Count);
            Assert.Equal(1, fuzzyRule.Conclusions.Count);
        }

        [Fact]
        internal void Build_ValidConditionsAndConclusions_ReturnsExpectedFuzzyRule()
        {
            // Arrange
            var waterTemp = StubLinguisticVariableFactory.WaterTemp();

            // Act
            var rule1 = new FuzzyRuleBuilder(PumpSpeedRule.Rule0)
                .If(ConditionBuilder
                    .If(waterTemp.Not(WaterTemp.Cold))
                    .And(waterTemp.Not(WaterTemp.Freezing))
                    .And(waterTemp.Not(WaterTemp.Frozen)))
                .And(ConditionBuilder.If(waterTemp.Is(WaterTemp.Warm)))
                .Or(ConditionBuilder.If(waterTemp.Not(WaterTemp.Frozen)).And(waterTemp.Not(WaterTemp.Boiling)))
                .Then(waterTemp.Not(WaterTemp.Boiling))
                .Then(waterTemp.Not(WaterTemp.Frozen))
                .Build();

            // Assert
            Assert.Equal(3, rule1.Conditions.Count);
            Assert.Equal(2, rule1.Conclusions.Count);
        }

        [Fact]
        internal void Build_WithComplexCondition_ReturnsExpectedFuzzyRule()
        {
            // Arrange
            var waterTemp = StubLinguisticVariableFactory.WaterTemp();

            // Act
            var rule1 = new FuzzyRuleBuilder("Rule1")
                .If(ConditionBuilder
                    .If(waterTemp.Is("cold"))
                    .And(waterTemp.Not("freezing"))
                    .Or(waterTemp.Not("frozen")))
                .And(ConditionBuilder
                    .If(waterTemp.Is("warm"))
                    .And(waterTemp.Not("hot"))
                    .Or(waterTemp.Not("boiling")))
                .And(ConditionBuilder
                    .If(waterTemp.Is("frozen"))
                    .And(waterTemp.Is("warm")))
                .Then(waterTemp.Not("frozen"))
                .Build();

            var dataPoint = new DataPoint(waterTemp.Subject, 20);

            var data = new Dictionary<Label, DataPoint> { { dataPoint.Variable, dataPoint } };

            var result = rule1.Evaluate(data, new FuzzyEvaluator());

            var temp = waterTemp.GetState(2);

            // Assert
            //Assert.Equal(new FuzzyState("warm"), temp);
            //Assert.True(result);
        }
    }
}