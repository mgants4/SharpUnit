/**
 * @file Assert.cs
 * 
 * Static assertion methods for verifying test expectations.
 * NOTE: It is important that each test throw its own TestException if it fails,
 *       as this gives us more accurate call stack reporting.
 * 
 */

using System;

namespace SharpUnit
{
    public class Assert
    {
        // Members
        private static Exception ms_exception = null;  // The expected exception.

        /**
         * Property to get/set the exception we are expecting.
         */
        public static Exception Exception
        {
            get { return ms_exception; }
            set { ms_exception = value; }
        }

        /**
         * Set the exception that is expected to be triggered by a unit test case.
         *
         * @param ex, the expection to expect.
         */
        public static void ExpectException(Exception ex)
        {
            ms_exception = ex;
        }

        /**
         * Throw an exception if the boolean expression is not true.
         * 
         * @param boolean, the expression to test.
         */
        public static void True(bool boolean)
        {
            // If not true
            if (true != boolean)
            {
                // Test failed
                throw new TestException("Expected True, got False.");
            }
        }

        /**
         * Throw an exception if the boolean expression is not true.
         * 
         * @param boolean, boolean expression to evaluate.
         * @param msg, error message to display if test fails.
         */
        public static void True(bool boolean, string msg)
        {
            // If not true
            if (true != boolean)
            {
                // Test failed
                throw new TestException(msg);
            }
        }

        /**
         * Throw an exception if the boolean expression is not false.
         * 
         * @param boolean, the expression to test.
         */
        public static void False(bool boolean)
        {
            // If not false
            if (false != boolean)
            {
                // Test failed
                throw new TestException("Expected False, got True.");
            }
        }

        /**
         * Throw an exception if the boolean expression is not false.
         * 
         * @param boolean, boolean expression to evaluate.
         * @param msg, error message to display if test fails.
         */
        public static void False(bool boolean, string msg)
        {
            // If not false
            if (false != boolean)
            {
                // Test failed
                throw new TestException(msg);
            }
        }

        /**
         * Throw an exception if the object is not null.
         * 
         * @param obj, the object to test.
         */
        public static void Null(Object obj)
        {
            // If not null
            if (null != obj)
            {
                // Test failed
                throw new TestException("Expected Null object, got " + obj);
            }
        }

        /**
         * Throw an exception if the object is not null.
         * 
         * @param obj, the object to test.
         * @param msg, error message to display if test fails.
         */
        public static void Null(Object obj, string msg)
        {
            // If not null
            if (null != obj)
            {
                // Test failed
                throw new TestException(msg);
            }
        }

        /**
         * Throw an exception if the object is null.
         * 
         * @param obj, the object to test.
         */
        public static void NotNull(Object obj)
        {
            // If null
            if (null == obj)
            {
                // Test failed
                throw new TestException("The object is null.");
            }
        }

        /**
         * Throw an exception if the object is null.
         * 
         * @param obj, the object to test.
         * @param msg, error message to display if test fails.
         */
        public static void NotNull(Object obj, string msg)
        {
            // If null
            if (null == obj)
            {
                // Test failed
                throw new TestException(msg);
            }
        }

        /**
         * Throw an exception if the two integers are not not equal.
         * 
         * @param wanted, the value we expected.
         * @param got, the value we actually received.
         */
        public static void Equal(int wanted, int got)
        {
            // If values not equal
            if (wanted != got)
            {
                // Test failed
                throw new TestException("Expected " + wanted + ", Got " + got);
            }
        }

        /**
         * Throw an exception if the two integers are not not equal.
         * 
         * @param wanted, the value we expected.
         * @param got, the value we actually received.
         * @param msg, error message to display if test fails.
         */
        public static void Equal(int wanted, int got, string msg)
        {
            // If values not equal
            if (wanted != got)
            {
                // Test failed
                throw new TestException(msg);
            }
        }

        /**
         * Throw an exception if the two floats are not not equal.
         * NOTE: Comparing two floats for exact equality is never accurate unless
         *       you take into account error tolerances. 
         * 
         * 		 It may be wiser instead to test the expected ranges of floats using the greater-than / less-than operators.
         *       Otherwise, feel free to tweak this method using the info here for more precise checking based on your needs.
         *
         *       	http://www.cygnus-software.com/papers/comparingfloats/comparingfloats.htm
         *          http://realtimecollisiondetection.net/blog/?p=89
         * 
         * @param wanted, the value we expected.
         * @param got, the value we actually received.
         */
        public static void Equal(float wanted, float got)
        {
            // If values not equal
			bool equal = Math.Abs (wanted - got) <= float.Epsilon;
            if (!equal)
            {
                // Test failed
                throw new TestException("Expected " + wanted + ", Got " + got);
            }
        }

        /**
         * Throw an exception if the two floats are not not equal.
         * NOTE: Comparing two floats for exact equality is never accurate unless
         *       you take into account error tolerances. 
         * 
         * 		 It may be wiser instead to test the expected ranges of floats using the greater-than / less-than operators.
         *       Otherwise, feel free to tweak this method using the info here for more precise checking based on your needs.
         *
         *       	http://www.cygnus-software.com/papers/comparingfloats/comparingfloats.htm
         *          http://realtimecollisiondetection.net/blog/?p=89
         * 
         * @param wanted, the value we expected.
         * @param got, the value we actually received.
         * @param msg, error message to display if test fails.
         */
        public static void Equal(float wanted, float got, string msg)
        {
            // If values not equal
			bool equal = Math.Abs (wanted - got) <= float.Epsilon;
            if (!equal)
            {
                // Test failed
                throw new TestException(msg);
            }
        }

        /**
         * Throw an exception if the two strings are not not equal.
         * 
         * @param wanted, the value we expected.
         * @param got, the value we actually received.
         */
        public static void Equal(string wanted, string got)
        {
            // If values not equal
            if (wanted != got)
            {
                // Test failed
                throw new TestException("Expected \"" + wanted + "\", Got \"" + got + "\"");
            }
        }

        /**
         * Throw an exception if the two strings are not not equal.
         * 
         * @param wanted, the value we expected.
         * @param got, the value we actually received.
         * @param msg, error message to display if test fails.
         */
        public static void Equal(string wanted, string got, string msg)
        {
            // If values not equal
            if (wanted != got)
            {
                // Test failed
                throw new TestException(msg);
            }
        }

        /**
         * Throw an exception if the two bools are not not equal.
         * 
         * @param wanted, the value we expected.
         * @param got, the value we actually received.
         */
        public static void Equal(bool wanted, bool got)
        {
            // If values not equal
            if (wanted != got)
            {
                // Test failed
                throw new TestException("Expected " + wanted + ", Got " + got);
            }
        }

        /**
         * Throw an exception if the two bools are not not equal.
         * 
         * @param wanted, the value we expected.
         * @param got, the value we actually received.
         * @param msg, error message to display if test fails.
         */
        public static void Equal(bool wanted, bool got, string msg)
        {
            // If values not equal
            if (wanted != got)
            {
                // Test failed
                throw new TestException(msg);
            }
        }

        /**
         * Throw an exception if the exceptions do not match.
         * NOTE: We only test the type and message of the exceptions.
         * 
         * @param wanted, the exception we expected.
         * @param got, the exception we actually caught.
         */
        public static void Equal(Exception wanted, Exception got)
        {
            // If types or messages not equal
            if ((wanted.GetType() != got.GetType()) ||
                (wanted.Message != got.Message))
            {
                // Test failed
                throw new TestException("Exceptions do not match.\n\tExpected " + wanted + ",\n\tGot " + got);
            }
        }

        /**
         * Throw an exception if the exceptions do not match.
         * NOTE: We only test the type and message of the exceptions.
         * 
         * @param wanted, the exception we expected.
         * @param got, the exception we actually caught.
         * @param msg, error message to display if test fails.
         */
        public static void Equal(Exception wanted, Exception got, string msg)
        {
            // If types or messages not equal
            if ((wanted.GetType() != got.GetType()) ||
                (wanted.Message != got.Message))
            {
                // Test failed
                throw new TestException(msg);
            }
        }

        /**
         * Throw an exception if the two objects are not not equal.
         * 
         * @param wanted, the value we expected.
         * @param got, the value we actually received.
         */
        public static void Equal(Object wanted, Object got)
        {
            // If values not equal
            if (wanted != got)
            {
                // Test failed
                throw new TestException("Expected " + wanted + ", Got " + got);
            }
        }

        /**
         * Throw an exception if the two objects are not not equal.
         * 
         * @param wanted, the value we expected.
         * @param got, the value we actually received.
         * @param msg, error message to display if test fails.
         */
        public static void Equal(Object wanted, Object got, string msg)
        {
            // If values not equal
            if (wanted != got)
            {
                // Test failed
                throw new TestException(msg);
            }
        }
    }
}
