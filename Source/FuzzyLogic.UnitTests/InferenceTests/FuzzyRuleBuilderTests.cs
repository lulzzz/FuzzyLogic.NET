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
    using FuzzyLogic.Logic;
    using FuzzyLogic.MembershipFunctions;
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
            var frozen = new FuzzySet("frozen", SingletonFunction.Create(0));
            var freezing = new FuzzySet("freezing", TriangularFunction.Create(0, 5, 10));
            var cold = new FuzzySet("cold", TrapezoidalFunction.Create(5, 10, 15, 20));
            var warm = new FuzzySet("warm", TrapezoidalFunction.Create(15, 25, 35, 40));
            var hot = new FuzzySet("hot", TrapezoidalFunction.Create(35, 60, 80, 100));
            var boiling = new FuzzySet("boiling", TrapezoidalFunction.CreateWithRightEdge(95, 100));

            var water = new LinguisticVariable("Temperature", new List<FuzzySet> { frozen, freezing, cold, warm, hot, boiling }, -20, 200);

            // Act
            var fuzzyRule = new FuzzyRuleBuilder("Rule1")
                .If(new Condition(water.Is("warm")))
                .Then(water.Is("warm"))
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
            var water = StubLinguisticVariableFactory.CreateTemperature();

            // Act
            var rule1 = new FuzzyRuleBuilder("Rule1")
                .If(new Condition(
                    water.Is(WaterTemp.Cold))
                    .And(water.IsNot(WaterTemp.Freezing))
                    .Or(water.IsNot("frozen")))
                .And(new Condition(
                    water.Is("warm"))
                    .And(water.IsNot("hot"))
                    .Or(water.IsNot("boiling")))
                .And(new Condition(
                    water.Is("frozen"))
                    .And(water.Is("warm")))
                .Then(water.IsNot("frozen"))
                .Then(water.IsNot("boiling"))
                .Build();

            // Assert
            Assert.Equal(3, rule1.Conditions.Count);
            Assert.Equal(2, rule1.Conclusions.Count);
        }

        [Fact]
        internal void ReturnsExpectedFuzzyRule()
        {
            // Arrange
            var water = StubLinguisticVariableFactory.CreateTemperature();

            // Act
            var rule1 = new FuzzyRuleBuilder("Rule1")
                .If(new Condition(
                    water.Is("cold"))
                    .And(water.IsNot("freezing"))
                    .Or(water.IsNot("frozen")))
                .If(new Condition(
                    water.Is("warm"))
                    .And(water.IsNot("hot"))
                    .Or(water.IsNot("boiling")))
                .If(new Condition(
                    water.Is("frozen"))
                    .And(water.Is("warm")))
                .Then(water.IsNot("frozen"))
                .Build();

            var data = new Dictionary<Label, double> { { water.Label, 20 } };

            var result = rule1.Evaluate(data);

            var temp = water.GetState(2);

            // Assert
            //Assert.Equal(new FuzzyState("warm"), temp);
            //Assert.True(result);
        }
    }
}