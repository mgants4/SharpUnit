/**
 * @file TestSuite.cs
 * 
 * Unit tests for the TestSuite class.
 */

using System;
using SharpUnit;

namespace SharpUnitTest
{
    class TestSuite_Test : TestCase
    {
        // Member values
        private TestSuite m_suite = null;   // TestSuite instance for testing

        public override void SetUp()
        {
            m_suite = new TestSuite();
        }

        public override void TearDown()
        {
            m_suite = null;
        }

        [UnitTest]
        public void TestAddAll_Null()
        {
            Assert.ExpectException(new Exception("Invalid test case encountered.")); 
            m_suite.AddAll(null);
        }

        [UnitTest]
        public void TestAddAll()
        {
            Dummy test = new Dummy();
            m_suite.AddAll(test);
        }

        [UnitTest]
        public void TestRun_NoTests()
        {
            // Test w/ no parameter
            TestResult res = m_suite.Run(null);
            Assert.Null(res);

            // Test w/ parameter
            res = new TestResult();
            TestResult res2 = m_suite.Run(res);
            Assert.NotNull(res2);
            Assert.Equal(res, res2);
            Assert.Equal(0, res2.NumRun);
            Assert.Equal(0, res2.NumFailed);
        }
    }
}
