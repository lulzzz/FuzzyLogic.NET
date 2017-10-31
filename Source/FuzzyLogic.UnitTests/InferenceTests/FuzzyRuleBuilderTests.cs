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

            // Act
            var fuzzyRule = new FuzzyRuleBuilder("Rule1")
                .If(new ConditionBuilder().If(waterTemp.Is(WaterTemp.Warm)))
                .Then(waterTemp.Is(WaterTemp.Warm))
                .Build();

            // Assert
            Assert.Equal(Label.Create("Rule1"), fuzzyRule.Label);
            Assert.Equal(1, fuzzyRule.Conditions.Count);
            Assert.Equal(1, fuzzyRule.Conclusions.Count);
        }

        [Fact]
        internal void Build_ValidConditionsAndConclusions_ReturnsExpectedFuzzyRule()
        {
            // Arrange
            var waterTemp = StubLinguisticVariableFactory.WaterTemp();

            // Act
            var rule1 = new FuzzyRuleBuilder(PumpSpeedRule.Rule0)
                .If(new ConditionBuilder()
                    .If(waterTemp.IsNot(WaterTemp.Cold))
                    .And(waterTemp.IsNot(WaterTemp.Freezing))
                    .And(waterTemp.IsNot(WaterTemp.Frozen)))
                .And(new ConditionBuilder(0.5).If(waterTemp.Is(WaterTemp.Warm)))
                .Or(new ConditionBuilder(0.5)
                    .If(waterTemp.IsNot(WaterTemp.Frozen))
                    .And(waterTemp.IsNot(WaterTemp.Boiling)))
                .Then(waterTemp.IsNot(WaterTemp.Boiling))
                .Then(waterTemp.IsNot(WaterTemp.Frozen))
                .Build();

            // Assert
            Assert.Equal(3, rule1.Conditions.Count);
            Assert.Equal(2, rule1.Conclusions.Count);
        }

        [Fact]
        internal void ReturnsExpectedFuzzyRule()
        {
            // Arrange
            var waterTemp = StubLinguisticVariableFactory.WaterTemp();

            // Act
            var rule1 = new FuzzyRuleBuilder("Rule1")
                .If(new ConditionBuilder()
                    .If(waterTemp.Is("cold"))
                    .And(waterTemp.IsNot("freezing"))
                    .Or(waterTemp.IsNot("frozen")))
                .And(new ConditionBuilder(0.8)
                    .If(waterTemp.Is("warm"))
                    .And(waterTemp.IsNot("hot"))
                    .Or(waterTemp.IsNot("boiling")))
                .And(new ConditionBuilder()
                    .If(waterTemp.Is("frozen"))
                    .And(waterTemp.Is("warm")))
                .Then(waterTemp.IsNot("frozen"))
                .Build();

            var data = new Dictionary<Label, double> { { waterTemp.Label, 20 } };

            var result = rule1.Evaluate(data);

            var temp = waterTemp.GetState(2);

            // Assert
            //Assert.Equal(new FuzzyState("warm"), temp);
            //Assert.True(result);
        }
    }
}