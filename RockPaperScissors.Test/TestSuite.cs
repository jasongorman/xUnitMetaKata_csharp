using System;
using System.Linq;
using System.Reflection;

namespace RockPaperScissors.Test
{
    internal class TestSuite
    {
        private int _testsPassed;
        private int _testsFailed;
        private readonly IOutput _output;

        public TestSuite(IOutput output)
        {
            _output = output;
            _testsPassed = 0;
            _testsFailed = 0;
        }

        public void RunAll()
        {
            _output.WriteHeader(Assembly.GetExecutingAssembly().GetName().Name.Replace(@".Test", ""));
            RunTestFixtures();
            _output.WriteSummary(_testsPassed, _testsFailed);
        }

        private void RunTestFixtures()
        {
            foreach (var type in Assembly.GetExecutingAssembly().ExportedTypes.Where(IsFixture))
            {
                new TestRunner(Activator.CreateInstance(type)).RunAll();
            }
        }

        private bool IsFixture(Type type)
        {
            return type.Name.EndsWith("Tests");
        }

        public void TestFailed(string displayName, object expected, object result)
        {
            _testsFailed++;
            new ConsoleOutput().WriteTestFailed(expected, result, displayName);
        }

        public void TestPassed(string displayName)
        {
            _testsPassed++;
            _output.WriteTestPassed(displayName);
        }

        public void TestFailed(string displayName, Type expectedException)
        {
            _testsFailed++;
            _output.WriteTestFailed(expectedException, displayName);
        }
    }
}