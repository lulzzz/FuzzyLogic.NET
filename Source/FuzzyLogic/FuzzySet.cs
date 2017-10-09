// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FuzzySet.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace FuzzyLogic
{
    using FuzzyLogic.Utility;

    /// <summary>
    /// The fuzzy set structure.
    /// </summary>
    public struct FuzzySet
    {
        private readonly IMembershipFunction function;

        /// <summary>
        /// Initializes a new instance of the <see cref="FuzzySet"/> structure.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="function">
        /// The function.
        /// </param>
        public FuzzySet(string name, IMembershipFunction function)
        {
            Validate.NotNull(name, nameof(name));
            Validate.NotNull(function, nameof(function));

            this.Name = name;
            this.function = function;
        }

        /// <summary>
        /// Gets the name of the fuzzy set.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The leftmost x value of the fuzzy set's membership function.
        /// </summary>
        public NonNegativeDouble LowerBound => this.function.LowerBound;

        /// <summary>
        /// The rightmost x value of the fuzzy set's membership function.
        /// </summary>
        public NonNegativeDouble UpperBound => this.function.UpperBound;

        /// <summary>
        /// The get membership.
        /// </summary>
        /// <param name="x">
        /// The x.
        /// </param>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public double GetMembership(double x)
        {
            return this.function.GetMembership(NonNegativeDouble.Create(x));
        }
    }
}