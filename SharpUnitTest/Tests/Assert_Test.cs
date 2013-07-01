/**
 * @file Assert_Test.cs
 * 
 * Unit tests for the Assert class.
 */

using System;
using SharpUnit;

namespace SharpUnitTest
{
    class Assert_Test : TestCase
    {
        [UnitTest]
        public void TestExpectedException()
        {
            Assert.Null(Assert.Exception);
        }

        [UnitTest]
        public void TestExpectException()
        {
            Exception ex = new Exception("Test");

            Assert.Null(Assert.Exception);
            Assert.ExpectException(ex);
            Assert.NotNull(Assert.Exception);
            Assert.Equal(ex, Assert.Exception);

            Assert.Exception = null;
            Assert.Null(Assert.Exception);
        }

        [UnitTest]
        public void TestTrue_NoParams()
        {
            // Test pass
            Assert.True(true);

            // Test fail
            Assert.ExpectException(new TestException("Expected True, got False."));
            Assert.True(false);
        }

        [UnitTest]
        public void TestTrue()
        {
            // Test pass
            Assert.True(true, null);

            // Test fail
            Assert.ExpectException(new TestException("Failed."));
            Assert.True(false, "Failed.");
        }

        [UnitTest]
        public void TestFalse_NoParams()
        {
            // Test pass
            Assert.False(false);

            // Test fail
            Assert.ExpectException(new TestException("Expected False, got True."));
            Assert.False(true);
        }

        [UnitTest]
        public void TestFalse()
        {
            // Test pass
            Assert.False(false, null);

            // Test fail
            Assert.ExpectException(new TestException("Failed."));
            Assert.False(true, "Failed.");
        }

        [UnitTest]
        public void TestNull_NoParams()
        {
            // Test pass
            Assert.Null(null);

            // Test fail
            Object obj = 3;
            Assert.ExpectException(new TestException("Expected Null object, got " + obj));
            Assert.Null(obj);
        }

        [UnitTest]
        public void TestNull()
        {
            // Test pass
            Assert.Null(null, null);

            // Test fail
            Object obj = 3;
            Assert.ExpectException(new TestException("Failed."));
            Assert.Null(obj, "Failed.");
        }

        [UnitTest]
        public void TestNotNull_NoParams()
        {
            // Test pass
            Assert.NotNull(3);

            // Test fail
            Assert.ExpectException(new TestException("The object is null."));
            Assert.NotNull(null);
        }

        [UnitTest]
        public void TestNotNull()
        {
            // Test pass
            Assert.NotNull(3, null);

            // Test fail
            Assert.ExpectException(new TestException("Failed."));
            Assert.NotNull(null, "Failed.");
        }

        [UnitTest]
        public void TestEqual_Int_NoParams()
        {
            // Test pass
            Assert.Equal(4, 4);

            // Test fail
            Assert.ExpectException(new TestException("Expected 3, Got 4"));
            Assert.Equal(3, 4);
        }

        [UnitTest]
        public void TestEqual_Int()
        {
            // Test pass
            Assert.Equal(4, 4, null);

            // Test fail
            Assert.ExpectException(new TestException("Failed."));
            Assert.Equal(3, 4, "Failed.");
        }

        [UnitTest]
        public void TestEqual_String_NoParams()
        {
            // Test pass
            Assert.Equal("test", "test");

            // Test fail
            Assert.ExpectException(new TestException("Expected \"crap\", Got \"test\""));
            Assert.Equal("crap", "test");
        }

        [UnitTest]
        public void TestEqual_String()
        {
            // Test pass
            Assert.Equal("test", "test", null);

            // Test fail
            Assert.ExpectException(new TestException("Failed"));
            Assert.Equal("crap", "test", "Failed");
        }

        [UnitTest]
        public void TestEqual_Float_NoParams()
        {
            // Test pass
            Assert.Equal(3.14f, 3.14f);

            // Test fail
            Assert.ExpectException(new TestException("Expected 5.2, Got 3.14"));
            Assert.Equal(5.2f, 3.14f);
        }

        [UnitTest]
        public void TestEqual_Float()
        {
            // Test pass
            Assert.Equal(3.14f, 3.14f, null);

            // Test fail
            Assert.ExpectException(new TestException("Failed"));
            Assert.Equal(0.0f, 3.14f, "Failed");
        }

        [UnitTest]
        public void TestEqual_Bool_NoParams()
        {
            // Test pass
            Assert.Equal(true, true);

            // Test fail
            Assert.ExpectException(new TestException("Expected False, Got True"));
            Assert.Equal(false, true);
        }

        [UnitTest]
        public void TestEqual_Bool()
        {
            // Test pass
            Assert.Equal(true, true);

            // Test fail
            Assert.ExpectException(new TestException("Failed"));
            Assert.Equal(false, true, "Failed");
        }

        [UnitTest]
        public void TestEqual_Obj_NoParams()
        {
            // Test pass
            Object obj = new Dummy();
            Assert.Equal(obj, obj);

            // Test fail
            Assert.ExpectException(new TestException("Expected " + obj.GetType() + ", Got 3"));
            Assert.Equal(obj, 3);
        }

		[UnitTest]
		public void TestEqual_Obj_Null_NoParams()
		{
			// Test pass
			Object obj = new Dummy();
			Assert.Equal((object)null, null);

			// Test fail
			Assert.ExpectException(new TestException("Expected , Got " + obj.GetType()));
			Assert.Equal(null, obj);
		}

        [UnitTest]
        public void TestEqual_Obj()
        {
            // Test pass
            Object obj = new Dummy();
            Assert.Equal(obj, obj, null);

            // Test fail
            Assert.ExpectException(new TestException("Failed"));
            Assert.Equal(obj, 3, "Failed");
        }
    }
}
