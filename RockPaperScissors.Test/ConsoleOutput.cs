using System;
using System.Reflection;

namespace RockPaperScissors.Test
{
    internal class ConsoleOutput : IOutput
    {
        public void WriteSummary(int testsPassed, int testsFailed)
        {
            Console.WriteLine("Tests run: {0}  Passed: {1}  Failed: {2}", testsPassed + testsFailed, testsPassed, testsFailed);
        }

        public void WriteHeader(string assemblyName)
        {
            Console.WriteLine(String.Format("Running {0} tests...", assemblyName));
        }

        public void WriteTestPassed(string displayName)
        {
            Console.WriteLine(String.Format("{0}: PASS", displayName));
        }

        // failure message for Assert.Equals
        public void WriteTestFailed(object expected, object result, string displayName)
        {
            Console.WriteLine(String.Format("{0}: FAIL - expected {1} but was {2}", displayName, expected, result));
        }

        // failure message for Assert.Throws
        public void WriteTestFailed(Type expectedException, string displayName)
        {
            Console.WriteLine(String.Format("{0}: FAIL - expected {1}", displayName, expectedException.Name));
        }
    }
}