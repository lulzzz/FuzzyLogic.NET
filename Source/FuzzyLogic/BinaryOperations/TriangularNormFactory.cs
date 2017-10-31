// -------------------------------------------------------------------------------------------------
// <copyright file="TriangularNormFactory.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.BinaryOperations
{
    /// <summary>
    /// The static <see cref="TriangularNormFactory"/>.
    /// </summary>
    public static class TriangularNormFactory
    {
        /// <summary>
        /// Returns a minimum t-norm function (default).
        /// </summary>
        /// <returns>
        /// A <see cref="MinimumTNorm"/>.
        /// </returns>
        public static MinimumTNorm MinimumTNorm() => new MinimumTNorm();

        /// <summary>
        /// Returns an algebraic product t-norm function.
        /// </summary>
        /// <returns>
        /// An <see cref="AlgebraicProduct"/>.
        /// </returns>
        public static AlgebraicProduct AlgebraicProduct() => new AlgebraicProduct();

        /// <summary>
        /// Returns a drastic product t-norm function.
        /// </summary>
        /// <returns>
        /// A <see cref="DrasticProduct"/>.
        /// </returns>
        public static DrasticProduct DrasticProduct() => new DrasticProduct();

        /// <summary>
        /// Returns an Einstein product t-norm function.
        /// </summary>
        /// <returns>
        /// An <see cref="EinsteinProduct"/>.
        /// </returns>
        public static EinsteinProduct EinsteinProduct() => new EinsteinProduct();

        /// <summary>
        /// Returns a Hamacher Product t-norm function.
        /// </summary>
        /// <returns>
        /// A <see cref="HamacherProduct"/>.
        /// </returns>
        public static HamacherProduct HamacherProduct() => new HamacherProduct();

        /// <summary>
        /// Returns a Lukasiewicz t-norm function.
        /// </summary>
        /// <returns>
        /// A <see cref="Lukasiewicz"/>.
        /// </returns>
        public static Lukasiewicz Lukasiewicz() => new Lukasiewicz();
    }
}
