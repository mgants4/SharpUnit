/**
 * @file Dummy_Test.cs
 * 
 * Unit tests for the Dummy class.
 */

using System;
using SharpUnit;

namespace SharpUnitTest
{
    class Dummy_Test : TestCase
    {
        // Members
        private Dummy m_dummy = null;   // Dummy instance for testing.

        /**
         * Init test resources, called before each test is run.
         */
        public override void SetUp()
        {
            m_dummy = new Dummy();
        }

        /**
         * Clean up allocated resources, called after each test is run.
         */
        public override void TearDown()
        {
            // Clear test instance
            m_dummy = null;
        }

        [UnitTest]
        public void TestDummy()
        {
            Assert.NotNull(m_dummy);
        }

        [UnitTest]
        public void TestSetUp()
        {
            Assert.False(m_dummy.m_wasSetup);
            m_dummy.SetUp();
            Assert.True(m_dummy.m_wasSetup);
        }

        [UnitTest]
        public void TestTearDown()
        {
            Assert.False(m_dummy.m_wasTornDown);
            m_dummy.TearDown();
            Assert.True(m_dummy.m_wasTornDown);
        }

        [UnitTest]
        public void TestTestMethod()
        {
            Assert.False(m_dummy.m_wasRun);
            m_dummy.TestMethod();
            Assert.True(m_dummy.m_wasRun);
        }

        [UnitTest]
        public void TestRun()
        {
            Assert.False(m_dummy.m_wasSetup);
            Assert.False(m_dummy.m_wasRun);
            Assert.False(m_dummy.m_wasTornDown);

            m_dummy.SetTestMethod("TestMethod");
            TestResult res = m_dummy.Run(null);

            Assert.NotNull(res);
            Assert.True(m_dummy.m_wasSetup);
            Assert.True(m_dummy.m_wasRun);
            Assert.True(m_dummy.m_wasTornDown);
        }

        [UnitTest]
        public void TestTestFail()
        {
            Assert.ExpectException(new TestException("Expected fail result."));
            m_dummy.TestFail();
        }
    }
}
