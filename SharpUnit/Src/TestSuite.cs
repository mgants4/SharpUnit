/**
 * @file TestSuite.cs
 * 
 * Test suite class, used for running a collection of tests.
 */

using System;
using System.Reflection;
using System.Collections.Generic;

namespace SharpUnit
{
    public class TestSuite
    {
        // Member values
        private List<TestCase> m_tests = null;  // List of test cases to run.
        
        /**
         * Constructor
         */
        public TestSuite()
        {
            // Create test list
            m_tests = new List<TestCase>();
        }

        /**
         * Destructor
         */
        ~TestSuite()
        {
            // Clear list
            m_tests = null;
        }

        /**
         * Add all test cases to the test suite.
         * 
         * @param test, the test case containing the tests we will add.
         */
        public void AddAll(TestCase test)
        {
            // If test invalid
            if (null == test)
            {
                // Error
                throw new Exception("Invalid test case encountered.");
            }

            // For each method in the test case
            Type type = test.GetType();
            foreach (MethodInfo method in type.GetMethods())
            {
                // For each unit test attribute
                foreach (Object obj in method.GetCustomAttributes(typeof(UnitTest), false))
                {
                    // If attribute is valid
                    Attribute testAtt = obj as Attribute;
                    if (null != testAtt)
                    {
                        // If type has constructors
                        ConstructorInfo[] ci= type.GetConstructors();
                        if (0 < ci.Length)
                        {
                            // Add the test
                            TestCase tmp = ci[0].Invoke(null) as TestCase;
                            tmp.SetTestMethod(method.Name);
                            m_tests.Add(tmp);
                        }
                    }
                }
            }
        }

        /**
         * Run all of the tests in the test suite.
         * 
         * @param result, result of the test run.
         */
        public TestResult Run(TestResult result)
        {
            // For each test
            foreach (TestCase test in m_tests)
            {
                // Run test
                result = test.Run(result);
            }

            // Return results
            return result;
        }
    }
}
