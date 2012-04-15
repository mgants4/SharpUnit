/**
 * @file Dummy.cs
 * 
 * A dummy test case purely for testing the framework.
 */

using System;
using SharpUnit;

namespace SharpUnitTest
{
    class Dummy : TestCase
    {
        // Members
        public bool m_wasRun = false;       // True if this test was run.
        public bool m_wasSetup = false;     // True if this test was setup.
        public bool m_wasTornDown = false;  // True if the test was torn down.
        
        /**
         * Perform test setup.
         */
        public override void SetUp()
        {
            m_wasSetup = true;
        }

        /**
         * Perform test tear down.
         */
        public override void TearDown()
        {
            m_wasTornDown = true;
        }

        /**
         * Dummy method to check if the test case was run.
         */
        [UnitTest]
        public void TestMethod()
        {
            m_wasRun = true;
        }

        /**
         * Dummy method to test failures.
         */
        [UnitTest]
        public void TestFail()
        {
            // Test should fail
            Assert.True(false, "Expected fail result.");
        }
    }
}
