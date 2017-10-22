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
        public static If If => new If();

        /// <summary>
        /// The is.
        /// </summary>
        /// <returns>
        /// The <see cref="Is"/>.
        /// </returns>
        public static Is Is => new Is();

        /// <summary>
        /// The is not.
        /// </summary>
        /// <returns>
        /// The <see cref="IsNot"/>.
        /// </returns>
        public static IsNot IsNot => new IsNot();

        /// <summary>
        /// The then.
        /// </summary>
        /// <returns>
        /// The <see cref="Then"/>.
        /// </returns>
        public static Then Then => new Then();

        /// <summary>
        /// The and.
        /// </summary>
        /// <returns>
        /// The <see cref="And"/>.
        /// </returns>
        public static And And => new And();

        /// <summary>
        /// The and.
        /// </summary>
        /// <returns>
        /// The <see cref="Or"/>.
        /// </returns>
        public static Or Or => new Or();
    }
}