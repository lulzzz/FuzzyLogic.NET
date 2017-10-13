// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PerformanceTimer.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace FuzzyLogic.Tests.PerformanceTests
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// The performance timer.
    /// </summary>
    public static class PerformanceTimer
    {
        /// <summary>
        /// The run.
        /// </summary>
        /// <param name="action">
        /// The action.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public static long Run(Action action)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            action.Invoke();
            stopwatch.Stop();

            return stopwatch.ElapsedMilliseconds;
        }
    }
}