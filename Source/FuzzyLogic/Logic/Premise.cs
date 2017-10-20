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

    /// <summary>
    /// The premise.
    /// </summary>
    [Immutable]
    public class Premise : Proposition, ICondition
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
        public Premise(
            ILogicOperator connectiveA,
            LinguisticVariable variable,
            ILogicOperator connectiveB,
            string condition)
            : base(connectiveA, variable, connectiveB, condition)
        {
        }

        /// <summary>
        /// The connective.
        /// </summary>
        public ILogicOperator Connective => this.ConnectiveA;

        /// <summary>
        /// The evaluate.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Evaluate()
        {
            return this.ConnectiveB.Evaluate(this.Variable, this.Condition);
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