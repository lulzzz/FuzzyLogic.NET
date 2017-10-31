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
    /// The immutable <see cref="LogicOperators"/> class.
    /// </summary>
    public static class LogicOperators
    {
        /// <summary>
        /// The 'IF' logic operator.
        /// </summary>
        /// <returns>
        /// An <see cref="If"/>.
        /// </returns>
        public static If If() => new If();

        /// <summary>
        /// The 'IS' logic operator.
        /// </summary>
        /// <returns>
        /// An <see cref="Is"/>.
        /// </returns>
        public static Is Is() => new Is();

        /// <summary>
        /// The 'IS NOT' logic operator.
        /// </summary>
        /// <returns>
        /// An <see cref="IsNot"/>.
        /// </returns>
        public static IsNot IsNot() => new IsNot();

        /// <summary>
        /// The 'THEN' logic operator.
        /// </summary>
        /// <returns>
        /// An <see cref="Then"/>.
        /// </returns>
        public static Then Then() => new Then();

        /// <summary>
        /// The 'AND' logic operator.
        /// </summary>
        /// <returns>
        /// An <see cref="And"/>.
        /// </returns>
        public static And And() => new And();

        /// <summary>
        /// The 'OR' logic operator.
        /// </summary>
        /// <returns>
        /// An <see cref="Or"/>.
        /// </returns>
        public static Or Or() => new Or();
    }
}