// -------------------------------------------------------------------------------------------------
// <copyright file="Premise.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.Logic
{
    using FuzzyLogic.Annotations;
    using FuzzyLogic.Logic.Operators;

    using static FuzzyLogic.Logic.LogicOperators;

    /// <summary>
    /// The premise.
    /// </summary>
    [Immutable]
    public class Premise : Proposition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Premise"/> class.
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
        private Premise(
            ILogicOperator connectiveA,
            LinguisticVariable variable,
            ILogicOperator connectiveB,
            string condition)
            : base(connectiveA, variable, connectiveB, condition)
        {
        }

        /// <summary>
        /// The if.
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
        /// The <see cref="Premise"/>.
        /// </returns>
        public static Premise If(LinguisticVariable variable, ILogicOperator connective, string condition)
        {
            return new Premise(LogicOperators.If(), variable, connective, condition);
        }

        /// <summary>
        /// The to string.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public override string ToString() => $"{base.ConnectiveA} {this.Variable.Name} {this.ConnectiveB} {this.Condition}";
    }
}