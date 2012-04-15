/**
 * @file TestCase_Test.cs
 * 
 * Unit tests for the TestCase class.
 */

using System;
using SharpUnit;

namespace SharpUnitTest
{
    class TestCase_Test : TestCase
    {
        // Members
        private TestCase m_test = null;     // Test case instance for testing

        public override void SetUp()
        {
            m_test = new Dummy();
        }

        public override void TearDown()
        {
            m_test = null;
        }

        [UnitTest]
        public void TestSetUp()
        {
            m_test.SetUp();
        }

        [UnitTest]
        public void TestTearDown()
        {
            m_test.TearDown();
        }

        [UnitTest]
        public void TestRun_NoTest()
        {
            Assert.ExpectException(new Exception("Invalid test method encountered, be sure to call TestCase::SetTestMethod()"));
            m_test.Run(null);
        }

        [UnitTest]
        public void TestRun_InvalidTest()
        {
            string method = "CrapMethod";
            Type type = m_test.GetType();
            Assert.ExpectException(new Exception("Test method: " + method + " does not exist in class: " + type.ToString()));
            m_test.SetTestMethod(method);
            m_test.Run(null);
        }

        [UnitTest]
        public void TestRun_NoParam()
        {
            m_test.SetTestMethod("TestMethod");
            TestResult res = m_test.Run(null);
            Assert.NotNull(res);
            Assert.Equal(1, res.NumRun);
            Assert.Equal(0, res.NumFailed);
        }

        [UnitTest]
        public void TestRun()
        {
            m_test.SetTestMethod("TestMethod");
            TestResult res1 = new TestResult();
            TestResult res2 = m_test.Run(res1);
            Assert.NotNull(res2);
            Assert.Equal(res1, res2);
        }

        [UnitTest]
        public void TestRun_Fail()
        {
            m_test.SetTestMethod("TestFail");
            TestResult res = m_test.Run(null);
            Assert.NotNull(res);
            Assert.Equal(1, res.NumFailed);
            Assert.Equal(1, res.ErrorList.Count);
        }
    }
}
