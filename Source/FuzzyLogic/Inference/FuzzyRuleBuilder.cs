// -------------------------------------------------------------------------------------------------
// <copyright file="FuzzyRuleBuilder.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.Inference
{
    using System.Collections.Generic;
    using FuzzyLogic.Logic;
    using static Logic.LogicOperators;

    /// <summary>
    /// The fuzzy rule builder.
    /// </summary>
    public class FuzzyRuleBuilder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FuzzyRuleBuilder"/> class.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        public FuzzyRuleBuilder(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        private string Name { get; }

        private IList<ICondition> Premises { get; set; } = new List<ICondition>();

        private Conclusion Conclusion { get; set; }

        /// <summary>
        /// The add condition.
        /// </summary>
        /// <param name="connectiveA">
        /// The connective A.
        /// </param>
        /// <param name="variable">
        /// The variable.
        /// </param>
        /// <param name="connectiveB">
        /// The connective B.
        /// </param>
        /// <param name="condition">
        /// The condition.
        /// </param>
        /// <returns>
        /// The <see cref="FuzzyRuleBuilder"/>.
        /// </returns>
        public FuzzyRuleBuilder WithCondition(
            ILogicOperator connectiveA,
            LinguisticVariable variable,
            ILogicOperator connectiveB,
            string condition)
        {
            this.Premises.Add(new Premise(connectiveA, variable, connectiveB, condition));

            return this;
        }

        /// <summary>
        /// The with conjunction.
        /// </summary>
        /// <param name="connective">
        /// The connective.
        /// </param>
        /// <param name="variableA">
        /// The variable A.
        /// </param>
        /// <param name="connectiveA">
        /// The connective A.
        /// </param>
        /// <param name="conditionA">
        /// The condition A.
        /// </param>
        /// <param name="variableB">
        /// The variable B.
        /// </param>
        /// <param name="connectiveB">
        /// The connective B.
        /// </param>
        /// <param name="conditionB">
        /// The condition B.
        /// </param>
        /// <returns>
        /// The <see cref="FuzzyRuleBuilder"/>.
        /// </returns>
        public FuzzyRuleBuilder WithConjunction(
            ILogicOperator connective,
            LinguisticVariable variableA,
            ILogicOperator connectiveA,
            string conditionA,
            LinguisticVariable variableB,
            ILogicOperator connectiveB,
            string conditionB)
        {
            var premiseA = new Premise(If(), variableA, connectiveA, conditionA);
            var premiseB = new Premise(If(), variableB, connectiveB, conditionB);

            this.Premises.Add(new Conjunction(connective, premiseA, premiseB));

            return this;
        }

        /// <summary>
        /// The with disjunction.
        /// </summary>
        /// <param name="connective">
        /// The connective.
        /// </param>
        /// <param name="variableA">
        /// The variable a.
        /// </param>
        /// <param name="connectiveA">
        /// The connective a.
        /// </param>
        /// <param name="conditionA">
        /// The condition a.
        /// </param>
        /// <param name="variableB">
        /// The variable b.
        /// </param>
        /// <param name="connectiveB">
        /// The connective b.
        /// </param>
        /// <param name="conditionB">
        /// The condition b.
        /// </param>
        /// <returns>
        /// The <see cref="FuzzyRuleBuilder"/>.
        /// </returns>
        public FuzzyRuleBuilder WithDisjunction(
            ILogicOperator connective,
            LinguisticVariable variableA,
            ILogicOperator connectiveA,
            string conditionA,
            LinguisticVariable variableB,
            ILogicOperator connectiveB,
            string conditionB)
        {
            var premiseA = new Premise(If(), variableA, connectiveA, conditionA);
            var premiseB = new Premise(If(), variableB, connectiveB, conditionB);

            this.Premises.Add(new Disjunction(connective, premiseA, premiseB));

            return this;
        }

        /// <summary>
        /// The add condition.
        /// </summary>
        /// <param name="variable">
        /// The variable.
        /// </param>
        /// <param name="connective">
        /// The connective.
        /// </param>
        /// <param name="condition">
        /// The condition.
        /// </param>
        /// <returns>
        /// The <see cref="FuzzyRuleBuilder"/>.
        /// </returns>
        public FuzzyRuleBuilder WithConclusion(
            LinguisticVariable variable,
            ILogicOperator connective,
            string condition)
        {
            this.Conclusion = new Conclusion(variable, connective, condition);

            return this;
        }

        /// <summary>
        /// The build.
        /// </summary>
        /// <returns>
        /// The <see cref="FuzzyRule"/>.
        /// </returns>
        public FuzzyRule Build()
        {
            return new FuzzyRule(this.Name, this.Premises, this.Conclusion);
        }
    }
}