/**
 * @file TestReporter.cs
 * 
 * Base class to output the results of executed unit tests.
 */

using System;

namespace SharpUnit
{
    public class TestReporter
    {
        // Member values
        protected TestResult m_result = null;     // Unit test results to output.

        /**
         * Get the TestResult object that will be used for reporting.
         */
        protected TestResult Result
        {
            get { return m_result; }
        }

        /**
         * Outputs the results of the unit tests.
         * 
         * @param result, the result containing the failures to display.
         */
        public virtual void LogResults(TestResult result)
        {
            // Set results
            m_result = result;

            // Log summary
            LogSummary();
            
            // If results valid
            if (null != m_result)
            {
                // For each failure
                foreach (Exception error in m_result.ErrorList)
                {
                    // Log the failure
                    LogFailure(error);
                }
            }
        }

        /**
         * Virtual method to output the summary of the executed unit tests.
         * NOTE: Can be overriden to customize how errors are reported.
         *       Especially useful for displaying failed tests within the 
         *       Unity3D console, etc.
         */
        protected virtual void LogSummary()
        {
            // If results invalid
            if (null == m_result)
            {
                // Log default summary
                System.Console.WriteLine("No test results to report, did you add test cases to the test suite?");
            }
            else
            {
                // Log summary to console
                System.Console.WriteLine(m_result.GetSummary() + "\n");
            }
        }

        /**
         * Virtual method to output an individual test failure.
         * NOTE: Can be overridden to customize how errors are reported.
         *       Especially useful for displaying failed tests within the 
         *       Unity3D console, etc.
         * 
         * @param error, the failed test exception to output.
         */
        protected virtual void LogFailure(Exception error)
        {
            // If error valid
            if (null != error)
            {
                // If error is a test exception
                if (typeof(TestException) == error.GetType())
                {
                    // Write the summary
                    TestException te = error as TestException;
                    System.Console.WriteLine(te.Description);
                }

                // Log failure
                System.Console.WriteLine(error + "\n");
            }
        }
    }
}
