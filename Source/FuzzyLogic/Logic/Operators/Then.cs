﻿// -------------------------------------------------------------------------------------------------
// <copyright file="Then.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.Logic.Operators
{
    using System;

    /// <summary>
    /// The is.
    /// </summary>
    public class Then : ILogicOperator
    {
        /// <summary>
        /// The evaluate.
        /// </summary>
        /// <param name="variable">
        /// The variable.
        /// </param>
        /// <param name="condition">
        /// The condition.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Evaluate(LinguisticVariable variable, string condition)
        {
            throw new ArgumentException("Invalid evaluation (cannot evaluate a THEN operator)");
        }

        /// <summary>
        /// The to string.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public override string ToString() => nameof(Then).ToUpper();
    }
}