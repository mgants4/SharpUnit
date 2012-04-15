/**
 * @file XML_TestReporter.cs
 * 
 * Reports unit test results to an xml file.
 */

using System;
using System.Collections;
using UnityEngine;
using SharpUnit;

public class XML_TestReporter : TestReporter 
{
    // Members
    protected string m_fileName = null;                 //!< Output file name.
    protected System.IO.StreamWriter m_file = null;     //!< File stream to write to.

    /**
     * Get the output filename.
     */
    public string FileName
    {
        get { return m_fileName; }
    }

    /**
     * Initialize the xml test reporter.
     * 
     * @param fileName, name of the output file to write to.
     */
    public void Init(string fileName)
    {
        // If file name invalid
        if (null == fileName)
        {
            // Error
            throw new Exception("XML_TestReporter::Init() called with invalid file name.");
        }

        // Init the file name
        m_fileName = fileName;
    }

    /**
     * Outputs the results of the unit tests.
     * Completely overrides the base class method of the same name.
     * 
     * @param result, the result containing the failures to display.
     */
    public override void LogResults(TestResult result)
    {
        // Set results
        m_result = result;

        // Create xml file
        m_file = new System.IO.StreamWriter(m_fileName, false);
        if (null != m_file)
        {
            // Begin xml log
            m_file.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            m_file.WriteLine("<SharpUnit>");

            // Log summary
            LogSummary();

            // If results valid
            if (null != m_result)
            {
                // For each failure
                foreach (Exception error in m_result.ErrorList)
                {
                    // Log the failure
                    LogFailure(error);
                }
            }

            // End xml log
            m_file.WriteLine("</SharpUnit>");

            // Close file
            m_file.Close();
            m_file = null;
        }
    }

    /**
     * Log unit test summary to the console.
     */
    protected override void LogSummary()
    {
        // Init summary string
        string summary = "No test results to report, did you add tests to the test suite?";
        if (null != Result)
        {
            // Get result summary if valid
            summary = Result.GetSummary();
        }

        // Form summary string
        m_file.WriteLine("\t<summary><![CDATA[" + summary + "]]></summary>");
    }

    /**
     * Log a unit test failure to the console.
     *
     * @param Exception error, the error to log.
     */
    protected override void LogFailure(Exception error)
    {
        // If the error is valid
        if (null != error)
        {
            // Open error tag
            m_file.WriteLine("\t<fail>");

            // Open description tag
            string msg = "\t\t<description><![CDATA[";
            
            // If the error is a test exception
            if (typeof(TestException) == error.GetType())
            {
                // Append description
                TestException te = error as TestException;
                msg += te.Description;
            }

            // Close description
            msg += "]]></description>";
            m_file.WriteLine(msg);

            // Append exception details
            m_file.WriteLine("\t\t<exception><![CDATA[" + error + "]]></exception>");

            // Close error
            m_file.WriteLine("\t</fail>");
        }
    }
}
