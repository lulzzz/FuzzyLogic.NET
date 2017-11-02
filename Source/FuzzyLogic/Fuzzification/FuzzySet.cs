// -------------------------------------------------------------------------------------------------
// <copyright file="FuzzySet.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.Fuzzification
{
    using System;
    using System.Collections.Generic;
    using FuzzyLogic.Annotations;
    using FuzzyLogic.MembershipFunctions;
    using FuzzyLogic.Utility;

    /// <summary>
    /// The immutable sealed <see cref="FuzzySet"/> class.
    /// </summary>
    [Immutable]
    public sealed class FuzzySet
    {
        private readonly IMembershipFunction function;

        /// <summary>
        /// Initializes a new instance of the <see cref="FuzzySet"/> class.
        /// </summary>
        /// <param name="state">
        /// The state.
        /// </param>
        /// <param name="function">
        /// The membership function.
        /// </param>
        public FuzzySet(string state, IMembershipFunction function)
        {
            Validate.NotNull(state, nameof(state));
            Validate.NotNull(function, nameof(function));

            this.State = FuzzyState.Create(state);
            this.function = function;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FuzzySet"/> class.
        /// </summary>
        /// <param name="labelEnum">
        /// The label enumeration.
        /// </param>
        /// <param name="function">
        /// The membership function.
        /// </param>
        public FuzzySet(Enum labelEnum, IMembershipFunction function)
            : this(labelEnum.ToString(), function)
        {
        }

        /// <summary>
        /// Gets the fuzzy state of the set.
        /// </summary>
        public FuzzyState State { get; }

        /// <summary>
        /// Returns the lower bound of the <see cref="FuzzySet"/>.
        /// </summary>
        public double LowerBound => this.function.LowerBound;

        /// <summary>
        /// Returns the upper bound of the <see cref="FuzzySet"/>
        /// </summary>
        public double UpperBound => this.function.UpperBound;

        /// <summary>
        /// Returns a <see cref="bool"/> indicating whether the <see cref="FuzzySet"/> is normal (max y = 1.0).
        /// </summary>
        public bool IsNormal => this.function.MaxY.Equals(UnitInterval.One());

        /// <summary>
        /// Returns a <see cref="bool"/> indicating whether the <see cref="FuzzySet"/> is convex
        /// (all points either increasing or decreasing).
        /// </summary>
        public bool IsConvex => this.CalculateIsConvex();

        /// <summary>
        /// The get points.
        /// </summary>
        /// <returns>
        /// An <see cref="IEnumerable{FuzzyPoint}"/>.
        /// </returns>
        public IEnumerable<FuzzyPoint> GetPoints() => this.function.Points;

        /// <summary>
        /// Returns the value of the membership for the given <see cref="double"/>.
        /// </summary>
        /// <param name="x">
        /// The x input (must not be negative).
        /// </param>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public UnitInterval GetMembership(double x)
        {
            Validate.NotOutOfRange(x, nameof(x));

            return this.function.GetMembership(x);
        }

        /// <summary>
        /// Returns the negation of the membership value for the <see cref="FuzzySet"/>.
        /// </summary>
        /// <param name="x">
        /// The x.
        /// </param>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public UnitInterval Complement(double x)
        {
            Validate.NotOutOfRange(x, nameof(x));

            return UnitInterval.Create(1 - this.function.GetMembership(x));
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
        public UnitInterval Union(FuzzySet other, double x)
        {
            Validate.NotNull(other, nameof(other));
            Validate.NotOutOfRange(x, nameof(x));

            return UnitInterval.Create(Math.Max(this.function.GetMembership(x).Value, other.GetMembership(x).Value));
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
        public UnitInterval Intersection(FuzzySet other, double x)
        {
            Validate.NotNull(other, nameof(other));
            Validate.NotOutOfRange(x, nameof(x));

            return UnitInterval.Create(Math.Min(this.function.GetMembership(x).Value, other.GetMembership(x).Value));
        }

        private bool CalculateIsConvex()
        {
            var points = this.function.Points;
            var increasing = true;
            var decreasing = true;

            for (int i = 0; i < points.Length - 1; i++)
            {
                if (points[i].Y >= points[i + 1].Y)
                {
                    increasing = false;
                }
            }

            for (int i = 0; i < points.Length - 1; i++)
            {
                if (points[i].Y <= points[i + 1].Y)
                {
                    decreasing = false;
                }
            }

            return increasing || decreasing;
        }
    }
}