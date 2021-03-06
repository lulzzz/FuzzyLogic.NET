﻿// -------------------------------------------------------------------------------------------------
// <copyright file="FuzzyOutput.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.Inference
{
    using FuzzyLogic.Annotations;
    using FuzzyLogic.Fuzzification;
    using FuzzyLogic.Utility;

    /// <summary>
    /// The immutable <see cref="FuzzyOutput"/> structure.
    /// </summary>
    [Immutable]
    public struct FuzzyOutput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FuzzyOutput"/> struct.
        /// </summary>
        /// <param name="subject">
        /// The subject.
        /// </param>
        /// <param name="outputFunction">
        /// The output function.
        /// </param>
        /// <param name="firingStrength">
        /// The firing strength [0, 1].
        /// </param>
        public FuzzyOutput(
            Label subject,
            FuzzySet outputFunction,
            UnitInterval firingStrength)
        {
            Validate.NotNull(subject, nameof(subject));
            Validate.NotNull(firingStrength, nameof(firingStrength));
            Validate.NotNull(outputFunction, nameof(outputFunction));

            this.Subject = subject;
            this.OutputFunction = outputFunction;
            this.FiringStrength = firingStrength;
        }

        /// <summary>
        /// Gets the output subject.
        /// </summary>
        public Label Subject { get; }

        /// <summary>
        /// Gets the output state.
        /// </summary>
        public FuzzyState State => this.OutputFunction.State;

        /// <summary>
        /// Gets the output function.
        /// </summary>
        public FuzzySet OutputFunction { get; }

        /// <summary>
        /// Gets the output firing strength.
        /// </summary>
        public UnitInterval FiringStrength { get; }
    }
}