// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TriangularFunction.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace FuzzyLogic.MembershipFunctions
{
    /// <summary>
    /// The <see cref="TriangularFunction" /> immutable class.
    /// </summary>
    public class TriangularFunction : PiecewiseLinearFunction
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TriangularFunction"/> class.
        /// </summary>
        /// <param name="x1">
        /// The m 1.
        /// </param>
        /// <param name="x2">
        /// The m 2.
        /// </param>
        /// <param name="x3">
        /// The m 3.
        /// </param>
        /// <param name="minY">
        /// The min.
        /// </param>
        /// <param name="maxY">
        /// The max.
        /// </param>
        public TriangularFunction(
            double x1,
            double x2,
            double x3,
            double minY = 0,
            double maxY = 1)
            : base(new[]
                       {
                           new FuzzyPoint(x1, minY),
                           new FuzzyPoint(x2, maxY),
                           new FuzzyPoint(x3, minY)
                       })
        {
        }
    }
}