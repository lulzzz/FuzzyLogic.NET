// -------------------------------------------------------------------------------------------------
// <copyright file="IsNot.cs" author="Christopher Sellers">
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
    /// The immutable sealed <see cref="IsNot"/> class. A linguistic string representation of the
    /// 'IS NOT' logic operator.
    /// </summary>
    [Immutable]
    public sealed class IsNot : ValidString<IsNot>, IEvaluationOperator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IsNot"/> class.
        /// </summary>
        public IsNot()
            : base("IS-NOT")
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
        public double Evaluate(double membership) => 1 - membership;
    }
}