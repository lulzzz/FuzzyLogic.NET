// -------------------------------------------------------------------------------------------------
// <copyright file="TriangularConormFactory.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.BinaryOperations
{
    /// <summary>
    /// The static <see cref="TriangularConormFactory"/>.
    /// </summary>
    public static class TriangularConormFactory
    {
        /// <summary>
        /// Returns a bounded sum t-conorm function.
        /// </summary>
        /// <returns>
        /// An <see cref="AlgebraicProduct"/>.
        /// </returns>
        public static BoundedSum BoundedSum() => new BoundedSum();

        /// <summary>
        /// Returns a drastic sum t-conorm function.
        /// </summary>
        /// <returns>
        /// A <see cref="DrasticProduct"/>.
        /// </returns>
        public static DrasticSum DrasticSum() => new DrasticSum();

        /// <summary>
        /// Returns an Einstein sum t-conorm function.
        /// </summary>
        /// <returns>
        /// An <see cref="EinsteinProduct"/>.
        /// </returns>
        public static EinsteinSum EinsteinSum() => new EinsteinSum();

        /// <summary>
        /// Returns a Hamacher sum t-conorm function.
        /// </summary>
        /// <returns>
        /// A <see cref="HamacherProduct"/>.
        /// </returns>
        public static HamacherSum HamacherSum() => new HamacherSum();

        /// <summary>
        /// Returns a probabilistic sum t-conorm function.
        /// </summary>
        /// <returns>
        /// A <see cref="ProbabilisticSum"/>.
        /// </returns>
        public static ProbabilisticSum ProbabilisticSum() => new ProbabilisticSum();
    }
}