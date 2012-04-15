/**
 * @file TestException.cs
 * 
 * Unit testing exception.
 * Allows us to set a description about the failed test and 
 * distinguish from the regular System.Exceptions.
 */

using System;

namespace SharpUnit
{
    public class TestException : Exception
    {
        // Member values
        private string m_desc = null;   // Description of the failed test (i.e. the class and method name)

        /**
         * Get / set the Description property.
         */
        public string Description
        {
            get { return m_desc; }
            set { m_desc = value; }
        }

        /**
         * Constructor
         * 
         * @param string msg, error message to display.
         */
        public TestException(string msg)
            : base(msg)
        {
            // Nothing to do
        }
    }
}
