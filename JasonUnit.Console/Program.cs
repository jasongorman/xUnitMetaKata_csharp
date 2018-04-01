using System.Reflection;
using JasonUnit.Framework;

namespace JasonUnit.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Test assembly: " + args[0]);
            Assembly testAssembly = Assembly.LoadFrom(args[0]);
            var testSuite = new TestSuite(new ConsoleOutput(), testAssembly);
            Assert.TestSuite = testSuite;
            testSuite.RunAll();
        }
    }
}
