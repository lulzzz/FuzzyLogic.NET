// -------------------------------------------------------------------------------------------------
// <copyright file="LogicOperators.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.Logic
{
    using FuzzyLogic.Logic.Operators;

    /// <summary>
    /// The logic operators.
    /// </summary>
    public static class LogicOperators
    {
        /// <summary>
        /// The if.
        /// </summary>
        /// <returns>
        /// The <see cref="If"/>.
        /// </returns>
        public static If If()
        {
            return new If();
        }

        /// <summary>
        /// The is.
        /// </summary>
        /// <returns>
        /// The <see cref="Is"/>.
        /// </returns>
        public static Is Is()
        {
            return new Is();
        }

        /// <summary>
        /// The then.
        /// </summary>
        /// <returns>
        /// The <see cref="Then"/>.
        /// </returns>
        public static Then Then()
        {
            return new Then();
        }
    }
}