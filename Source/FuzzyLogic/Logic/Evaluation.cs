// -------------------------------------------------------------------------------------------------
// <copyright file="Evaluation.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.Logic
{
    using FuzzyLogic.Annotations;
    using FuzzyLogic.Logic.Interfaces;
    using FuzzyLogic.Utility;

    /// <summary>
    /// The immutable <see cref="Evaluation"/> structure.
    /// </summary>
    [Immutable]
    public struct Evaluation
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Evaluation"/> struct.
        /// </summary>
        /// <param name="connective">
        /// The connective.
        /// </param>
        /// <param name="result">
        /// The result.
        /// </param>
        public Evaluation(IConnectiveOperator connective, double result)
        {
            Validate.NotNull(connective, nameof(connective));

            this.Connective = connective;
            this.Result = result;
        }

        /// <summary>
        /// Gets the connective logic operator.
        /// </summary>
        public IConnectiveOperator Connective { get; }

        /// <summary>
        /// Gets a value indicating the fuzzy result.
        /// </summary>
        public double Result { get; }
    }
}