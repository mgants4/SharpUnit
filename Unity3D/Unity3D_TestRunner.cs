/**
 * @file TestRunner.cs
 * 
 * Unity3D unit test runner.
 * Sets up the unit testing suite and executes all unit tests.
 * Drag this onto an empty GameObject to run tests.
 */

using System;
using System.Collections;
using System.Reflection;
using SharpUnit;
using UnityEngine;

public class Unity3D_TestRunner : MonoBehaviour 
{
    /**
     * Initialize class resources.
     */
	void Start() 
    {
        // Create test suite
        TestSuite suite = new TestSuite();

        // For each assembly in this app domain
        foreach (Assembly assem in AppDomain.CurrentDomain.GetAssemblies())
        {
            // For each type in the assembly
            foreach (Type type in assem.GetTypes())
            {
                // If this is a valid test case
                // i.e. derived from TestCase and instantiable
                if (typeof(TestCase).IsAssignableFrom(type) &&
                    type != typeof(TestCase) &&
                    !type.IsAbstract)
                {
                    // Add tests to suite
                    suite.AddAll(type.GetConstructor(new Type[0]).Invoke(new object[0]) as TestCase);
                }
            }
        }

        // Run the tests
        TestResult res = suite.Run(null);

        // Report results
        Unity3D_TestReporter reporter = new Unity3D_TestReporter();
        reporter.LogResults(res);
	}
}
