// -------------------------------------------------------------------------------------------------
// <copyright file="FuzzySet.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic
{
    using System;
    using FuzzyLogic.Annotations;
    using FuzzyLogic.MembershipFunctions;
    using FuzzyLogic.Utility;

    /// <summary>
    /// The fuzzy set structure.
    /// </summary>
    [Immutable]
    public sealed class FuzzySet
    {
        private readonly IMembershipFunction function;

        /// <summary>
        /// Initializes a new instance of the <see cref="FuzzySet"/> class.
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
        /// The lower bound.
        /// </summary>
        public double LowerBound => this.function.LowerBound;

        /// <summary>
        /// The upper bound.
        /// </summary>
        public double UpperBound => this.function.UpperBound;

        /// <summary>
        /// Returns a boolean indicating whether the <see cref="FuzzySet"/> is normal (max y = 1.0).
        /// </summary>
        public bool IsNormal => this.function.MaxY.Equals(1);

        /// <summary>
        /// Returns the value of the membership for the given input (input must not be negative).
        /// </summary>
        /// <param name="x">
        /// The x input (must not be negative).
        /// </param>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public double GetMembership(double x)
        {
            Validate.NotOutOfRange(x, nameof(x), 0);

            return this.function.GetMembership(x);
        }

        /// <summary>
        /// Returns the negation of the membership value for this fuzzy set.
        /// </summary>
        /// <param name="x">
        /// The x.
        /// </param>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public double Complement(double x)
        {
            Validate.NotOutOfRange(x, nameof(x), 0);

            return 1 - this.function.GetMembership(x);
        }

        /// <summary>
        /// Returns the union of the membership value (the maximum membership value of the fuzzy sets).
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        /// <param name="x">
        /// The x.
        /// </param>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public double Union(FuzzySet other, double x)
        {
            Validate.NotNull(other, nameof(other));
            Validate.NotOutOfRange(x, nameof(x), 0);

            return Math.Max(this.function.GetMembership(x), other.GetMembership(x));
        }

        /// <summary>
        /// Returns the intersection of the membership value (the minimum membership value of the fuzzy sets).
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        /// <param name="x">
        /// The x.
        /// </param>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public double Intersection(FuzzySet other, double x)
        {
            Validate.NotNull(other, nameof(other));
            Validate.NotOutOfRange(x, nameof(x), 0);

            return Math.Min(this.function.GetMembership(x), other.GetMembership(x));
        }
    }
}