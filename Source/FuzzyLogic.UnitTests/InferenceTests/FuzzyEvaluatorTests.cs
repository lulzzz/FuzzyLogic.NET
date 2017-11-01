// -------------------------------------------------------------------------------------------------
// <copyright file="FuzzyEvaluatorTests.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.UnitTests.InferenceTests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using FuzzyLogic.BinaryOperations;
    using FuzzyLogic.Inference;
    using FuzzyLogic.Logic;
    using Xunit;

    [SuppressMessage("StyleCop.CSharp.NamingRules", "*", Justification = "Reviewed. Suppression is OK within the Test Suite.")]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "Reviewed. Suppression is OK within the Test Suite.")]
    public class FuzzyEvaluatorTests
    {
        [Fact]
        internal void And_WhenFunctionsDefault_ReturnsExpectedResult()
        {
            // Arrange
            var evaluator = new FuzzyEvaluator();

            var membershipA = UnitInterval.Create(0.25);
            var membershipB = UnitInterval.Create(0.5);

            // Act
            var result = evaluator.And(membershipA, membershipB);

            // Assert
            Assert.Equal(UnitInterval.Create(0.25), result);
        }

        [Fact]
        internal void Or_WhenFunctionsDefault_ReturnsExpectedResult()
        {
            // Arrange
            var tNorm = TriangularNormFactory.MinimumTNorm();
            var tConorm = TriangularConormFactory.MaximumTConorm();

            var evaluator = new FuzzyEvaluator(tNorm, tConorm);

            var membershipA = UnitInterval.Create(0.25);
            var membershipB = UnitInterval.Create(0.5);

            // Act
            var result = evaluator.Or(membershipA, membershipB);

            // Assert
            Assert.Equal(UnitInterval.Create(0.5), result);
        }

        [Fact]
        internal void Evaluate_WithTwoEvaluationsAndConnective_ReturnsExpectedResult()
        {
            // Arrange
            var evaluator = new FuzzyEvaluator();

            var evaluations = new List<Evaluation>
                                  {
                                      new Evaluation(LogicOperators.If(), UnitInterval.Create(0.25)),
                                      new Evaluation(LogicOperators.And(), UnitInterval.Create(0.1))
                                  };

            // Act
            var result = evaluator.Evaluate(evaluations);

            // Assert
            Assert.Equal(UnitInterval.Create(0.1), result);
        }

        [Fact]
        internal void Evaluate_WithTwoEvaluationsOrConnective_ReturnsExpectedResult()
        {
            // Arrange
            var evaluator = new FuzzyEvaluator();

            var evaluations = new List<Evaluation>
                                  {
                                      new Evaluation(LogicOperators.If(), UnitInterval.Create(0.25)),
                                      new Evaluation(LogicOperators.Or(), UnitInterval.Create(1))
                                  };

            // Act
            var result = evaluator.Evaluate(evaluations);

            // Assert
            Assert.Equal(UnitInterval.Create(1), result);
        }

        [Fact]
        internal void Evaluate_WithThreeEvaluationsOrConnective_ReturnsExpectedResult()
        {
            // Arrange
            var evaluator = new FuzzyEvaluator();

            var evaluations = new List<Evaluation>
                                  {
                                      new Evaluation(LogicOperators.If(), UnitInterval.Create(0.25)),
                                      new Evaluation(LogicOperators.And(), UnitInterval.Create(0.1)),
                                      new Evaluation(LogicOperators.Or(), UnitInterval.Create(1))
                                  };

            // Act
            var result = evaluator.Evaluate(evaluations);

            // Assert
            Assert.Equal(UnitInterval.Create(1), result);
        }

        [Fact]
        internal void Evaluate_WithThreeEvaluationsBothOrConnectives_ReturnsExpectedResult()
        {
            // Arrange
            var evaluator = new FuzzyEvaluator();

            var evaluations = new List<Evaluation>
                                  {
                                      new Evaluation(LogicOperators.If(), UnitInterval.Create(0.25)),
                                      new Evaluation(LogicOperators.Or(), UnitInterval.Create(0.5)),
                                      new Evaluation(LogicOperators.Or(), UnitInterval.Create(1))
                                  };

            // Act
            var result = evaluator.Evaluate(evaluations);

            // Assert
            Assert.Equal(UnitInterval.Create(1), result);
        }

        [Fact]
        internal void Evaluate_WithTwoGroupCompoundStatement_ReturnsExpectedResult()
        {
            // Arrange
            var evaluator = new FuzzyEvaluator();

            var evaluations = new List<Evaluation>
                                  {
                                      // Statement group 1 (assumed to evaluate to 0).
                                      new Evaluation(LogicOperators.If(), UnitInterval.Create(0.25)),
                                      new Evaluation(LogicOperators.And(), UnitInterval.Create(0.0)),
                                      new Evaluation(LogicOperators.And(), UnitInterval.Create(0.2)),

                                      // Statement group 2 (assumed to evaluate to 0.8).
                                      new Evaluation(LogicOperators.Or(), UnitInterval.Create(1)),
                                      new Evaluation(LogicOperators.And(), UnitInterval.Create(0.9)),
                                      new Evaluation(LogicOperators.And(), UnitInterval.Create(0.8))
                                  };

            // Act
            var result = evaluator.Evaluate(evaluations);

            // Assert
            Assert.Equal(UnitInterval.Create(0.8), result);
        }

        [Fact]
        internal void Evaluate_WithTwoGroupCompoundStatementAllZero_ReturnsExpectedResult()
        {
            // Arrange
            var evaluator = new FuzzyEvaluator();

            var evaluations = new List<Evaluation>
                                  {
                                      // Statement group 1 (assumed to evaluate to 0).
                                      new Evaluation(LogicOperators.If(), UnitInterval.Create(0.0)),
                                      new Evaluation(LogicOperators.And(), UnitInterval.Create(0.0)),
                                      new Evaluation(LogicOperators.And(), UnitInterval.Create(0.0)),

                                      // Statement group 2 (assumed to evaluate to 0).
                                      new Evaluation(LogicOperators.Or(), UnitInterval.Create(0)),
                                      new Evaluation(LogicOperators.And(), UnitInterval.Create(0)),
                                      new Evaluation(LogicOperators.And(), UnitInterval.Create(0))
                                  };

            // Act
            var result = evaluator.Evaluate(evaluations);

            // Assert
            Assert.Equal(UnitInterval.Zero(), result);
        }

        [Fact]
        internal void Evaluate_WithThreeGroupCompoundStatement_ReturnsExpectedResult()
        {
            // Arrange
            var evaluator = new FuzzyEvaluator();

            var evaluations = new List<Evaluation>
                                  {
                                      // Statement group 1 (assumed to evaluate to 0).
                                      new Evaluation(LogicOperators.If(), UnitInterval.Create(0.25)),
                                      new Evaluation(LogicOperators.And(), UnitInterval.Create(0.0)),
                                      new Evaluation(LogicOperators.And(), UnitInterval.Create(0.2)),

                                      // Statement group 2 (assumed to evaluate to 0.8).
                                      new Evaluation(LogicOperators.Or(), UnitInterval.Create(1)),
                                      new Evaluation(LogicOperators.And(), UnitInterval.Create(0.9)),
                                      new Evaluation(LogicOperators.And(), UnitInterval.Create(0.8)),

                                      // Statement group 3 (assumed to evaluate to 0.9).
                                      new Evaluation(LogicOperators.Or(), UnitInterval.Create(0.9)),
                                      new Evaluation(LogicOperators.And(), UnitInterval.Create(1)),
                                      new Evaluation(LogicOperators.And(), UnitInterval.Create(1))
                                  };

            // Act
            var result = evaluator.Evaluate(evaluations);

            // Assert
            Assert.Equal(UnitInterval.Create(0.9), result);
        }

        [Fact]
        internal void Evaluate_WithFourGroupCompoundStatementThenConnectedByMultipleOrs_ReturnsExpectedResult()
        {
            // Arrange
            var evaluator = new FuzzyEvaluator();

            var evaluations = new List<Evaluation>
                                  {
                                      // Statement group 1 (assumed to evaluate to 0.9).
                                      new Evaluation(LogicOperators.If(), UnitInterval.Create(1)),
                                      new Evaluation(LogicOperators.And(), UnitInterval.Create(1)),
                                      new Evaluation(LogicOperators.And(), UnitInterval.Create(0.9)),

                                      // Statement group 2 (assumed to evaluate to 0.8).
                                      new Evaluation(LogicOperators.Or(), UnitInterval.Create(1)),
                                      new Evaluation(LogicOperators.And(), UnitInterval.Create(0.9)),
                                      new Evaluation(LogicOperators.And(), UnitInterval.Create(0.8)),

                                      // Statement group 3 (assumed to evaluate to 0.7).
                                      new Evaluation(LogicOperators.Or(), UnitInterval.Create(0.7)),
                                      new Evaluation(LogicOperators.And(), UnitInterval.Create(0.7)),
                                      new Evaluation(LogicOperators.And(), UnitInterval.Create(0.7)),

                                      // Then multiple or connectives (assumed to evaluate to 1).
                                      new Evaluation(LogicOperators.Or(), UnitInterval.Create(0.8)),
                                      new Evaluation(LogicOperators.Or(), UnitInterval.Create(0.9)),
                                      new Evaluation(LogicOperators.Or(), UnitInterval.Create(1))
                                  };

            // Act
            var result = evaluator.Evaluate(evaluations);

            // Assert
            Assert.Equal(UnitInterval.Create(1), result);
        }

        [Fact]
        internal void Evaluate_WithThreeGroupCompoundStatementAndEinsteinFunctions_ReturnsExpectedResult()
        {
            // Arrange
            var tnorm = TriangularNormFactory.EinsteinProduct();
            var tconorm = TriangularConormFactory.EinsteinSum();

            var evaluator = new FuzzyEvaluator(tnorm, tconorm);

            var evaluations = new List<Evaluation>
                                  {
                                      // Statement group 1
                                      new Evaluation(LogicOperators.If(), UnitInterval.Create(0.25)),
                                      new Evaluation(LogicOperators.And(), UnitInterval.Create(0.0)),
                                      new Evaluation(LogicOperators.And(), UnitInterval.Create(0.2)),

                                      // Statement group 2
                                      new Evaluation(LogicOperators.Or(), UnitInterval.Create(1)),
                                      new Evaluation(LogicOperators.And(), UnitInterval.Create(0.9)),
                                      new Evaluation(LogicOperators.And(), UnitInterval.Create(0.8)),

                                      // Statement group 3
                                      new Evaluation(LogicOperators.Or(), UnitInterval.Create(0.5)),
                                      new Evaluation(LogicOperators.And(), UnitInterval.Create(1)),
                                      new Evaluation(LogicOperators.And(), UnitInterval.Create(1))
                                  };

            // Act
            var result = evaluator.Evaluate(evaluations);

            // Assert
            Assert.Equal(0.891304347826087, result.Value);
        }

        [Fact]
        internal void Evaluate_WithThreeGroupCompoundStatementAndHamacherFunctions_ReturnsExpectedResult()
        {
            // Arrange
            var tnorm = TriangularNormFactory.HamacherProduct();
            var tconorm = TriangularConormFactory.HamacherSum();

            var evaluator = new FuzzyEvaluator(tnorm, tconorm);

            var evaluations = new List<Evaluation>
                                  {
                                      // Statement group 1
                                      new Evaluation(LogicOperators.If(), UnitInterval.Create(0.25)),
                                      new Evaluation(LogicOperators.And(), UnitInterval.Create(0.0)),
                                      new Evaluation(LogicOperators.And(), UnitInterval.Create(0.2)),

                                      // Statement group 2
                                      new Evaluation(LogicOperators.Or(), UnitInterval.Create(1)),
                                      new Evaluation(LogicOperators.And(), UnitInterval.Create(0.9)),
                                      new Evaluation(LogicOperators.And(), UnitInterval.Create(0.8)),

                                      // Statement group 3
                                      new Evaluation(LogicOperators.Or(), UnitInterval.Create(0.5)),
                                      new Evaluation(LogicOperators.And(), UnitInterval.Create(1)),
                                      new Evaluation(LogicOperators.And(), UnitInterval.Create(1))
                                  };

            // Act
            var result = evaluator.Evaluate(evaluations);

            // Assert
            Assert.Equal(0.790322580645162, Math.Round(result.Value, 15));
        }

        [Fact]
        internal void Evaluate_WithThreeGroupCompoundStatementAndOtherFunctions_ReturnsExpectedResult()
        {
            // Arrange
            var tnorm = TriangularNormFactory.Lukasiewicz();
            var tconorm = TriangularConormFactory.ProbabilisticSum();

            var evaluator = new FuzzyEvaluator(tnorm, tconorm);

            var evaluations = new List<Evaluation>
                                  {
                                      // Statement group 1
                                      new Evaluation(LogicOperators.If(), UnitInterval.Create(0.25)),
                                      new Evaluation(LogicOperators.And(), UnitInterval.Create(0.0)),
                                      new Evaluation(LogicOperators.And(), UnitInterval.Create(0.2)),

                                      // Statement group 2
                                      new Evaluation(LogicOperators.Or(), UnitInterval.Create(1)),
                                      new Evaluation(LogicOperators.And(), UnitInterval.Create(0.9)),
                                      new Evaluation(LogicOperators.And(), UnitInterval.Create(0.8)),

                                      // Statement group 3
                                      new Evaluation(LogicOperators.Or(), UnitInterval.Create(0.5)),
                                      new Evaluation(LogicOperators.And(), UnitInterval.Create(1)),
                                      new Evaluation(LogicOperators.And(), UnitInterval.Create(1))
                                  };

            // Act
            var result = evaluator.Evaluate(evaluations);

            // Assert
            Assert.Equal(0.85, Math.Round(result.Value, 2));
        }
    }
}