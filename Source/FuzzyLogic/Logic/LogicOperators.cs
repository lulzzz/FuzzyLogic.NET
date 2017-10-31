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
    using FuzzyLogic.Annotations;
    using FuzzyLogic.Logic.Operators;

    /// <summary>
    /// The immutable <see cref="LogicOperators"/> class.
    /// </summary>
    [Immutable]
    public static class LogicOperators
    {
        private static readonly If IfOperator = new If();
        private static readonly Is IsOperator = new Is();
        private static readonly IsNot IsNotOperator = new IsNot();
        private static readonly Then ThenOperator = new Then();
        private static readonly And AndOperator = new And();
        private static readonly Or OrOperator = new Or();

        /// <summary>
        /// The 'IF' logic operator.
        /// </summary>
        /// <returns>
        /// An <see cref="If"/>.
        /// </returns>
        public static If If() => IfOperator;

        /// <summary>
        /// The 'IS' logic operator.
        /// </summary>
        /// <returns>
        /// An <see cref="Is"/>.
        /// </returns>
        public static Is Is() => IsOperator;

        /// <summary>
        /// The 'IS NOT' logic operator.
        /// </summary>
        /// <returns>
        /// An <see cref="IsNot"/>.
        /// </returns>
        public static IsNot IsNot() => IsNotOperator;

        /// <summary>
        /// The 'THEN' logic operator.
        /// </summary>
        /// <returns>
        /// An <see cref="Then"/>.
        /// </returns>
        public static Then Then() => ThenOperator;

        /// <summary>
        /// The 'AND' logic operator.
        /// </summary>
        /// <returns>
        /// An <see cref="And"/>.
        /// </returns>
        public static And And() => AndOperator;

        /// <summary>
        /// The 'OR' logic operator.
        /// </summary>
        /// <returns>
        /// An <see cref="Or"/>.
        /// </returns>
        public static Or Or() => OrOperator;
    }
}