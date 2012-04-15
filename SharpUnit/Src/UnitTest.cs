/**
 * @file UnitTest.cs
 * 
 * Attribute to mark unit test methods within a TestCase.
 */

using System;

namespace SharpUnit
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class UnitTest : Attribute
    {
        // Intentionally empty
    }
}
