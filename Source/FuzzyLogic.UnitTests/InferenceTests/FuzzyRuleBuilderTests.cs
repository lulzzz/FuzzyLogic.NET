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
    using Xunit;

    using static FuzzyLogic.Logic.LogicOperators;

    [SuppressMessage("StyleCop.CSharp.NamingRules", "*", Justification = "Reviewed. Suppression is OK within the Test Suite.")]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "Reviewed. Suppression is OK within the Test Suite.")]
    public class FuzzyRuleBuilderTests
    {
        [Fact]
        internal void Build_ValidConditionsAndConclusions_ReturnsExpectedFuzzyRule()
        {
            // Arrange
            var frozen = new FuzzySet("frozen", TrapezoidalFunction.CreateWithLeftEdge(0, 5));
            var freezing = new FuzzySet("freezing", TriangularFunction.Create(0, 5, 10));
            var cold = new FuzzySet("cold", TrapezoidalFunction.Create(10, 15, 18, 20));
            var warm = new FuzzySet("warm", TrapezoidalFunction.Create(15, 25, 35, 40));
            var hot = new FuzzySet("hot", TrapezoidalFunction.CreateWithRightEdge(30, 60, 1));
            var boiling = new FuzzySet("boiling", TrapezoidalFunction.CreateWithRightEdge(90, 100));

            var water = new LinguisticVariable("Temperature", new List<FuzzySet> { frozen, freezing, cold, warm, hot, boiling }, -20, 200);

            // Act
            var rule1 = new FuzzyRuleBuilder("Rule1")
                .Add(new Condition(If, water, Is, "cold").And(water, IsNot, "freezing").Or(water, IsNot, "frozen"))
                .Add(new Condition(And, water, Is, "warm").And(water, IsNot, "hot").Or(water, IsNot, "boiling"))
                .Add(new Condition(Or, water, Is, "frozen"))
                .Then(water, Is, "warm")
                .Then(water, IsNot, "frozen")
                .Build();

            // Assert
            Assert.Equal(3, rule1.Conditions.Count);
            Assert.Equal(2, rule1.Conclusions.Count);
        }

        [Fact]
        internal void ReturnsExpectedFuzzyRule()
        {
            // Arrange
            var frozen = new FuzzySet("frozen", TrapezoidalFunction.CreateWithLeftEdge(0, 2));
            var freezing = new FuzzySet("freezing", TriangularFunction.Create(0, 5, 10));
            var cold = new FuzzySet("cold", TrapezoidalFunction.Create(10, 15, 18, 20));
            var warm = new FuzzySet("warm", TrapezoidalFunction.Create(15, 25, 35, 40));
            var hot = new FuzzySet("hot", TrapezoidalFunction.CreateWithRightEdge(30, 60, 1));
            var boiling = new FuzzySet("boiling", TrapezoidalFunction.CreateWithRightEdge(90, 100));

            var water = new LinguisticVariable("Temperature", new List<FuzzySet> { frozen, freezing, cold, warm, hot, boiling }, -20, 200);

            // Act
            var rule1 = new FuzzyRuleBuilder("Rule1")
                .Add(new Condition(If, water, Is, "cold").And(water, IsNot, "freezing").Or(water, IsNot, "frozen"))
                .Add(new Condition(And, water, IsNot, "hot").Or(water, IsNot, "boiling"))
                .Then(water, Is, "warm")
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