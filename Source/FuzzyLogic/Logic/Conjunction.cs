// -------------------------------------------------------------------------------------------------
// <copyright file="Conjunction.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.Logic
{
    using FuzzyLogic.Utility;

    /// <summary>
    /// The conjunction.
    /// </summary>
    public class Conjunction : CompoundCondition, ICondition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Conjunction"/> class.
        /// </summary>
        /// <param name="connective">
        /// The connective.
        /// </param>
        /// <param name="premiseA">
        /// The premise a.
        /// </param>
        /// <param name="premiseB">
        /// The premise b.
        /// </param>
        public Conjunction(ILogicOperator connective, Premise premiseA, Premise premiseB) : base(premiseA, premiseB)
        {
            Validate.NotNull(connective, nameof(connective));

            this.Connective = connective;
        }

        /// <summary>
        /// Gets the connective.
        /// </summary>
        public ILogicOperator Connective { get; }

        /// <summary>
        /// The evaluate.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Evaluate()
        {
            return this.PremiseA.Evaluate() && this.PremiseB.Evaluate();
        }
    }
}