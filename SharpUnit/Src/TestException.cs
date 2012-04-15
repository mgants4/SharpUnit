/**
 * @file TestException.cs
 * 
 * Unit testing exception.
 * Allows us to set a description about the failed test and 
 * distinguish from the regular System.Exceptions.
 */

using System;
using System.Diagnostics;

namespace SharpUnit
{
    public class TestException : Exception
    {
        // Member values
        private string m_desc = null;       // Description of the failed test (i.e. the class and method name)
        private StackFrame m_frame = null;  // Stack frame where error occurred.    

        /**
         * Get / set the Description property.
         */
        public string Description
        {
            get { return m_desc; }
            set { m_desc = value; }
        }

        /**
         * Get the stack frame property
         */
        public StackFrame StackFrame
        {
            get { return m_frame; }
        }

        /**
         * Constructor
         * 
         * @param msg, error message to display.
         */
        public TestException(string msg)
            : base(msg)
        {
            // Set depth to two to capture the correct level at which the exception was thrown
            //      - TestException constructor
            //      - Assert class method
            //      - TestCase method               <-- the level we want
            int depth = 2;

            // If the stack trace to this point is valid
            StackTrace trace = new StackTrace(true);
            if (null != trace)
            {
                // Iterate through stack frames
                StackFrame frame = null;
                for (int index = 0; index < trace.FrameCount; ++index)
                {
                    // If we have reached the desired depth
                    if (index == depth)
                    {
                        // If frame is valid
                        frame = trace.GetFrame(index);
                        if (null != frame)
                        {
                            // Set frame and break
                            m_frame = frame;
                            break;
                        }
                    }
                }
            }
        }
    }
}
