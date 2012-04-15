/**
 * @file TestReporter.cs
 * 
 * Unit tests for the TestReporter class.
 */

using System;
using SharpUnit;

namespace SharpUnitTest
{
    class TestReporter_Test : TestCase
    {
        // Member values
        private DummyReporter m_reporter = null; // TestReporter instance for testing.

        public override void SetUp()
        {
            m_reporter = new DummyReporter();
        }

        public override void TearDown()
        {
            m_reporter = null;
        }

        [UnitTest]
        public void TestLogResults_NoParam()
        {
            // No param
            Assert.Equal(0, m_reporter.NumFailures);
            m_reporter.LogResults(null);
            Assert.Equal(0, m_reporter.NumFailures);

            // w/ param, no test
            m_reporter.LogResults(new TestResult());
            Assert.Equal(0, m_reporter.NumFailures);

            // w/ param and tests
            Dummy test = new Dummy();
            test.SetTestMethod("TestFail");
            TestResult res = test.Run(null);
            m_reporter.LogResults(res);
            Assert.Equal(1, m_reporter.NumFailures);
        }
    }
}
