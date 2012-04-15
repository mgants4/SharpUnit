/**
 * @file Program.cs
 * 
 * Main entry point for the SharpUnit test framework.
 * Runs the unit tests that test the framework itself.
 */

using System;
using SharpUnit;

namespace SharpUnitTest
{
    class Program
    {
        /**
         * Main entry point.
         * Runs unit tests for the unit testing framework.
         * 
         * @param args, array of string arguments.
         */
        static void Main(string[] args)
        {
            try
            {
                // Create the test suite
                TestSuite suite = new TestSuite();

                // Add tests to the test suite
                suite.AddAll((TestCase)new Dummy_Test());
                suite.AddAll((TestCase)new Assert_Test());
                suite.AddAll((TestCase)new TestCase_Test());
                suite.AddAll((TestCase)new TestResult_Test());
                suite.AddAll((TestCase)new TestSuite_Test());
                suite.AddAll((TestCase)new TestReporter_Test());

                // Run the tests
                TestResult result = suite.Run(null);
                
                // Report test results
                TestReporter reporter = new TestReporter();
                reporter.LogResults(result);
            }
            catch (Exception e)
            {
                // Log uncaught exceptions
                System.Console.WriteLine(e.ToString());
            }

            // Set a break point here for testing to examine console output
            //int pause = 0;
        }
    }
}
