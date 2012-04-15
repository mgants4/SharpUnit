/**
 * @file TestResult.cs
 * 
 * Test result class. Tracks how many tests were run and how many failed.
 */

using System;
using System.Collections.Generic;

namespace SharpUnit
{
    public class TestResult
    {
        // Members
        private int m_numRun = 0;                   // Number of tests that were run.
        private List<Exception> m_errors = null;    // List of test failure exceptions.

        /**
         * Constructor
         */
        public TestResult()
        {
            // Init error list
            m_errors = new List<Exception>();
        }

        /**
         * Destructor
         */
        ~TestResult()
        {
            // Clear error list
            m_errors = null;
        }

        /**
         * Get the list of failed test exceptions.
         */
        public List<Exception> ErrorList
        {
            get { return m_errors; }
        }

        /**
         * Get the number of tests run.
         * Incremented by calling TestStarted()
         */
        public int NumRun
        {
            get { return m_numRun; }
        }

        /**
         * Get the number of failed tests.
         * Incremented by calling TestFailed()
         */
        public int NumFailed
        {
            get { return m_errors.Count; }
        }

        /**
         * Increment the number of tests run.
         */
        public void TestStarted()
        {
            m_numRun += 1;
        }

        /**
         * Increment the number of failed tests.
         * 
         * @param error, the exception thrown by the test that failed.
         */
        public void TestFailed(Exception error)
        {
            // If exception invalid
            if (null == error)
            {
                // Error
                throw new Exception("Encountered invalid exception.");
            }

            // Add exception to list
            m_errors.Add(error);
        }

        /**
         * Return a summary of the run vs. failed tests.
         */
        public string GetSummary()
        {
            return "Ran " + m_numRun + " tests, " + NumFailed + " failed.";
        }
    }
}
