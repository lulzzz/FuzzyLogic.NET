// -------------------------------------------------------------------------------------------------
// <copyright file="TheTippingProblem.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.Examples
{
    using System.Collections.Generic;
    using FuzzyLogic.BinaryOperations;
    using FuzzyLogic.Defuzzification;
    using FuzzyLogic.Fuzzification;
    using FuzzyLogic.Inference;
    using FuzzyLogic.Inference.Engines;
    using FuzzyLogic.MembershipFunctions;
    using FuzzyLogic.TestKit;
    using Xunit;

    public class TheTippingProblem
    {
        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(2.5, 2.5, 7.8)]
        [InlineData(5, 5, 13)]
        [InlineData(7.5, 7.5, 17.8)]
        [InlineData(10, 10, 25)]
        internal void RunMamdaniInference(double foodInput, double serviceInput, double expected)
        {
            // Define the input and output linguistic variables.
            var foodQuality = new LinguisticVariable(
                InputVariable.FoodQuality,
                new List<FuzzySet>
                    {
                        new FuzzySet(FoodQuality.Poor, TrapezoidalFunction.CreateWithLeftEdge(0, 5)),
                        new FuzzySet(FoodQuality.Average, TriangularFunction.Create(0, 5, 10)),
                        new FuzzySet(FoodQuality.Good, TrapezoidalFunction.CreateWithRightEdge(5, 10))
                    });

            var serviceQuality = new LinguisticVariable(
                InputVariable.FoodQuality,
                new List<FuzzySet>
                    {
                        new FuzzySet(ServiceQuality.Poor, TrapezoidalFunction.CreateWithLeftEdge(0, 5)),
                        new FuzzySet(ServiceQuality.Average, TriangularFunction.Create(0, 5, 10)),
                        new FuzzySet(ServiceQuality.Good, TrapezoidalFunction.CreateWithRightEdge(5, 10))
                    });

            var tipAmount = new LinguisticVariable(
                OutputVariable.TipAmount,
                new List<FuzzySet>
                    {
                        new FuzzySet(TipAmount.Low, TrapezoidalFunction.CreateWithLeftEdge(0, 13)),
                        new FuzzySet(TipAmount.Medium, TriangularFunction.Create(0, 13, 25)),
                        new FuzzySet(TipAmount.High, TrapezoidalFunction.CreateWithRightEdge(13, 25))
                    });

            // Define the rules for the fuzzy inference engine.
            var rule1 = new FuzzyRuleBuilder(TippingProblem.Rule1)
                .If(foodQuality.Is(FoodQuality.Poor))
                .Or(serviceQuality.Is(ServiceQuality.Poor))
                .Then(tipAmount.Is(TipAmount.Low))
                .Build();

            var rule2 = new FuzzyRuleBuilder(TippingProblem.Rule2)
                .If(serviceQuality.Is(ServiceQuality.Average))
                .Then(tipAmount.Is(TipAmount.Medium))
                .Build();

            var rule3 = new FuzzyRuleBuilder(TippingProblem.Rule3)
                .If(foodQuality.Is(FoodQuality.Good))
                .Or(serviceQuality.Is(ServiceQuality.Good))
                .Then(tipAmount.Is(TipAmount.High))
                .Build();

            // Construct the fuzzy inference engine.
            var tnorm = TriangularNormFactory.MinimumTNorm();
            var tconorm = TriangularConormFactory.MaximumTConorm();
            var defuzzifier = new CentroidDefuzzifier();
            var fuzzyEngine = new MamdaniInferenceEngine(tnorm, tconorm, defuzzifier);

            // Add the rules to the rulebase.
            fuzzyEngine.Rulebase.AddRule(rule1);
            fuzzyEngine.Rulebase.AddRule(rule2);
            fuzzyEngine.Rulebase.AddRule(rule3);

            // Prepare database to receive inputs.
            fuzzyEngine.Database.AddVariable(Label.Create(InputVariable.FoodQuality));
            fuzzyEngine.Database.AddVariable(Label.Create(InputVariable.ServiceQuality));

            // Generate input data.
            var foodData = new DataPoint(InputVariable.FoodQuality, foodInput);
            var serviceData = new DataPoint(InputVariable.ServiceQuality, serviceInput);

            // Feed inference engine the data.
            fuzzyEngine.Database.UpdateData(foodData);
            fuzzyEngine.Database.UpdateData(serviceData);

            // Compute the inference engine.
            var result = fuzzyEngine.Compute();

            Assert.Equal(OutputVariable.TipAmount.ToString(), result[0].Subject.Value);
            Assert.Equal(expected, result[0].Value);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(2.5, 2.5, 7.8)]
        [InlineData(5, 5, 13)]
        [InlineData(7.5, 7.5, 17.8)]
        [InlineData(10, 10, 25)]
        internal void RunSugenoInference(double foodInput, double serviceInput, double expected)
        {
            // Define the input and output linguistic variables.
            var foodQuality = new LinguisticVariable(
                InputVariable.FoodQuality,
                new List<FuzzySet>
                    {
                        new FuzzySet(FoodQuality.Poor, TrapezoidalFunction.CreateWithLeftEdge(0, 5)),
                        new FuzzySet(FoodQuality.Average, TriangularFunction.Create(0, 5, 10)),
                        new FuzzySet(FoodQuality.Good, TrapezoidalFunction.CreateWithRightEdge(5, 10))
                    });

            var serviceQuality = new LinguisticVariable(
                InputVariable.FoodQuality,
                new List<FuzzySet>
                    {
                        new FuzzySet(ServiceQuality.Poor, TrapezoidalFunction.CreateWithLeftEdge(0, 5)),
                        new FuzzySet(ServiceQuality.Average, TriangularFunction.Create(0, 5, 10)),
                        new FuzzySet(ServiceQuality.Good, TrapezoidalFunction.CreateWithRightEdge(5, 10))
                    });

            var tipAmount = new LinguisticVariable(
                OutputVariable.TipAmount,
                new List<FuzzySet>
                    {
                        new FuzzySet(TipAmount.Low, TrapezoidalFunction.CreateWithLeftEdge(0, 13)),
                        new FuzzySet(TipAmount.Medium, TriangularFunction.Create(0, 13, 25)),
                        new FuzzySet(TipAmount.High, TrapezoidalFunction.CreateWithRightEdge(13, 25))
                    });

            // Define the rules for the fuzzy inference engine.
            var rule1 = new FuzzyRuleBuilder(TippingProblem.Rule1)
                .If(foodQuality.Is(FoodQuality.Poor))
                .Or(serviceQuality.Is(ServiceQuality.Poor))
                .Then(tipAmount.Is(TipAmount.Low))
                .Build();

            var rule2 = new FuzzyRuleBuilder(TippingProblem.Rule2)
                .If(serviceQuality.Is(ServiceQuality.Average))
                .Then(tipAmount.Is(TipAmount.Medium))
                .Build();

            var rule3 = new FuzzyRuleBuilder(TippingProblem.Rule3)
                .If(foodQuality.Is(FoodQuality.Good))
                .Or(serviceQuality.Is(ServiceQuality.Good))
                .Then(tipAmount.Is(TipAmount.High))
                .Build();

            // Construct the fuzzy inference engine.
            var tnorm = TriangularNormFactory.MinimumTNorm();
            var tconorm = TriangularConormFactory.MaximumTConorm();
            var defuzzifier = new CentroidDefuzzifier();
            var fuzzyEngine = new SugenoInferenceEngine(tnorm, tconorm, defuzzifier);

            // Add the rules to the rulebase.
            fuzzyEngine.Rulebase.AddRule(rule1);
            fuzzyEngine.Rulebase.AddRule(rule2);
            fuzzyEngine.Rulebase.AddRule(rule3);

            // Prepare database to receive inputs.
            fuzzyEngine.Database.AddVariable(Label.Create(InputVariable.FoodQuality));
            fuzzyEngine.Database.AddVariable(Label.Create(InputVariable.ServiceQuality));

            // Generate input data.
            var foodData = new DataPoint(InputVariable.FoodQuality, foodInput);
            var serviceData = new DataPoint(InputVariable.ServiceQuality, serviceInput);

            // Feed inference engine the data.
            fuzzyEngine.Database.UpdateData(foodData);
            fuzzyEngine.Database.UpdateData(serviceData);

            // Compute the inference engine.
            var result = fuzzyEngine.Compute();

            Assert.Equal(OutputVariable.TipAmount.ToString(), result[0].Subject.Value);
            Assert.Equal(expected, result[0].Value);
        }
    }
}