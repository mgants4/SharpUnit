/**
 * TestResult_Test.cs
 * 
 * Unit tests for the TestResult class.
 */

using System;
using SharpUnit;

namespace SharpUnitTest
{
    class TestResult_Test : TestCase
    {
        // Members
        private TestResult m_res = null;   // TestResult instance for testing

        public override void SetUp()
        {
            m_res = new TestResult();
        }

        public override void TearDown()
        {
            m_res = null;
        }

        [UnitTest]
        public void TestTestStarted()
        {
            Assert.Equal(0, m_res.NumRun);
            m_res.TestStarted();
            Assert.Equal(1, m_res.NumRun);
        }

        [UnitTest]
        public void TestTestFailed_NoParam()
        {
            Assert.ExpectException(new Exception("Encountered invalid exception."));
            m_res.TestFailed(null);
        }

        [UnitTest]
        public void TestTestFailed()
        {
            Assert.Equal(0, m_res.NumFailed);
            m_res.TestFailed(new Exception("Failed"));
            Assert.Equal(1, m_res.NumFailed);
        }

        [UnitTest]
        public void TestGetSummary()
        {
            string exp = "Ran " + m_res.NumRun + " tests, " + m_res.NumFailed + " failed.";
            Assert.Equal(exp, m_res.GetSummary());

            m_res.TestStarted();
            m_res.TestFailed(new Exception("Fail"));
            exp = "Ran " + m_res.NumRun + " tests, " + m_res.NumFailed + " failed.";
            Assert.Equal(exp, m_res.GetSummary());
        }
    }
}
