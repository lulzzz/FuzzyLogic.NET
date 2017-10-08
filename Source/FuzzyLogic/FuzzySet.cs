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
    using CodeEssence.DesignByContract;

    /// <summary>
    /// Fuzzy sets are sets whose elements have degrees of membership.
    /// Fuzzy sets were introduced by Lotfi A. Zadeh and Dieter Klaua in 1965
    /// as an extension of the classical notion of set.
    /// </summary>
    public class FuzzySet
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
            Contract.Requires(Condition.NotNull(name, nameof(name)));
            Contract.Requires(Condition.NotNull(function, nameof(function)));

            this.Name = name;
            this.function = function;

            Contract.Ensures(Condition.NotNull(this.Name, nameof(this.Name)));
            Contract.Ensures(Condition.DoubleNotInvalidNumber(this.LeftLimit, nameof(this.LeftLimit)));
            Contract.Ensures(Condition.DoubleNotInvalidNumber(this.RightLimit, nameof(this.RightLimit)));
        }

        /// <summary>
        /// Gets the name of the fuzzy set.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The leftmost x value of the fuzzy set's membership function.
        /// </summary>
        public double LeftLimit => this.function.LeftLimit;

        /// <summary>
        /// The rightmost x value of the fuzzy set's membership function.
        /// </summary>
        public double RightLimit => this.function.RightLimit;

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
            Contract.Requires(Condition.DoubleNotInvalidNumber(x, nameof(x)));

            var membershipValue = this.function.GetMembership(x);

            Contract.Ensures(Condition.DoubleNotOutOfRange(membershipValue, nameof(membershipValue), 0, 1));

            return membershipValue;
        }
    }
}