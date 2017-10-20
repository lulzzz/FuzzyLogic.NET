// -------------------------------------------------------------------------------------------------
// <copyright file="CompoundCondition.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.Logic
{
    using FuzzyLogic.Annotations;
    using FuzzyLogic.Utility;

    /// <summary>
    /// The compound condition.
    /// </summary>
    [Immutable]
    public abstract class CompoundCondition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CompoundCondition"/> class.
        /// </summary>
        /// <param name="premiseA">
        /// The premise a.
        /// </param>
        /// <param name="premiseB">
        /// The premise b.
        /// </param>
        protected CompoundCondition(Premise premiseA, Premise premiseB)
        {
            Validate.NotNull(premiseA, nameof(premiseA));
            Validate.NotNull(premiseB, nameof(premiseB));

            this.PremiseA = premiseA;
            this.PremiseB = premiseB;
        }

        /// <summary>
        /// Gets the premise a.
        /// </summary>
        protected Premise PremiseA { get; }

        /// <summary>
        /// Gets the premise b.
        /// </summary>
        protected Premise PremiseB { get; }
    }
}