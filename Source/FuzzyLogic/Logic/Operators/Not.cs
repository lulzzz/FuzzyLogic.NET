// -------------------------------------------------------------------------------------------------
// <copyright file="Not.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.Logic.Operators
{
    using FuzzyLogic.Annotations;
    using FuzzyLogic.Logic.Interfaces;

    /// <summary>
    /// The immutable sealed <see cref="Not"/> class. A linguistic string representation of the
    /// 'NOT' logic operator.
    /// </summary>
    [Immutable]
    public sealed class Not : ValidString<Not>, IEvaluationOperator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Not"/> class.
        /// </summary>
        public Not()
            : base(nameof(Not).ToUpper())
        {
        }

        /// <summary>
        /// Returns the result of the evaluation.
        /// </summary>
        /// <param name="membership">
        /// The membership value.
        /// </param>
        /// <returns>
        /// A <see cref="double"/> [0, 1].
        /// </returns>
        public UnitInterval Evaluate(UnitInterval membership) => UnitInterval.Create(1 - membership);
    }
}