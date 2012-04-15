/**
 * @file Unity3D_TestReporter.cs
 * 
 * Unit test reporter for Unity3D, logs messages to the Debug console.
 */

using System;
using System.Collections;
using UnityEngine;
using SharpUnit;

public class Unity3D_TestReporter : TestReporter 
{
    /**
     * Log unit test summary to the console.
     */
    public override void LogSummary()
    {
        // If the results invalid
        if (null == Result)
        {
            // Log default summary
            Debug.LogWarning("No test results to report, did you add tests to the test suite?");
        }
        else
        {
            // Log summary to console
            Debug.Log(Result.GetSummary());
        }
    }

    /**
     * Log a unit test failure to the console.
     *
     * @param Exception error, the error to log.
     */
    public override void LogFailure(Exception error)
    {
        // If the error is valid
        if (null != error)
        {
            // If the error is a test exception
            string msg = "";
            if (typeof(TestException) == error.GetType())
            {
                // Write the summary
                TestException te = error as TestException;
                msg = te.Description;
            }

            // Log as error to the console
            Debug.LogError(msg + "\n" + error);
        }
    }
}
