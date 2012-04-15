/**
 * @file DummyReporter.cs
 * 
 * Dummy test reporter for unit testing.
 */

using System;
using SharpUnit;

namespace SharpUnitTest
{
    class DummyReporter : TestReporter
    {
        // Members
        private int m_numFailures = 0;  // Number of failures logged.

        /**
         * Get the number of "logged" failures.
         */
        public int NumFailures
        {
            get { return m_numFailures; }
        }

        /**
         * Override summary logging since we do not want to display any output in this case.
         */
        protected override void LogSummary()
        {
            // Do not log summary, keeps test output clean
        }

        /**
         * Output a single failure.
         * NOTE: To keep our test output clean we will just count the number of "logged" failures.
         * 
         * @param error, the failed test exception to output.
         */
        protected override void LogFailure(Exception error)
        {
            // If the error is valid
            if (null != error)
            {
                // Increment count
                // NOTE: In practice you would want to do something similar to:
                //       System.Console.WriteLine(error);
                m_numFailures += 1;
            }
        }
    }
}
