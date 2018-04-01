using System;
using System.Linq;
using System.Reflection;

namespace JasonUnit.Framework
{
    public class TestSuite
    {
        private int _testsPassed;
        private int _testsFailed;
        private readonly IOutput _output;
        private readonly Assembly _testAssembly;

        public TestSuite(IOutput output, Assembly testAssembly)
        {
            _output = output;
            _testAssembly = testAssembly;
            _testsPassed = 0;
            _testsFailed = 0;
        }

        public void RunAll()
        {
            _output.WriteHeader(_testAssembly.GetName().Name.Replace(@".Test", ""));
            RunTestFixtures();
            _output.WriteSummary(_testsPassed, _testsFailed);
        }

        private void RunTestFixtures()
        {
            foreach (var type in _testAssembly.ExportedTypes.Where(IsFixture))
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
            _output.WriteTestFailed(expected, result, displayName);
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