using System;
using System.Reflection;

namespace RockPaperScissors.Test
{
    public class TestRunner
    {
        private readonly object _fixture;

        public TestRunner(object fixture)
        {
            _fixture = fixture;
        }

        internal void RunAll()
        {
            var fixtureName = _fixture.GetType().Name.Replace("Tests", "");
            Console.WriteLine(string.Format("{0} tests...", fixtureName));
            foreach (MethodInfo method in _fixture.GetType().GetMethods())
            {
                if (method.Name.StartsWith("Test"))
                {
                    method.Invoke(_fixture, null);
                }
            }
        }
    }
}