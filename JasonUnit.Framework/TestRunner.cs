using System.Reflection;

namespace JasonUnit.Framework
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
            System.Console.WriteLine(string.Format("{0} tests...", fixtureName));
            foreach (MethodInfo method in _fixture.GetType().GetMethods())
            {
                if (IsTest(method))
                {
                    InvokeTest(method);
                }
            }
        }

        private void InvokeTest(MethodInfo method)
        {
            if (!IsParameterized(method))
            {
                method.Invoke(_fixture, null);
            }
            else
            {
                InvokeParameterized(method);
            }
        }

        private void InvokeParameterized(MethodInfo method)
        {
            object[][] testCases = GetTestData(method);
            foreach (object[] testCase in testCases)
            {
                method.Invoke(_fixture, testCase);
            }
        }

        private bool IsTest(MethodInfo method)
        {
            return method.Name.StartsWith("Test");
        }

        private object[][] GetTestData(MethodInfo testMethod)
        {
            MethodInfo dataMethod = _fixture.GetType().GetMethod("DataFor_" + testMethod.Name, BindingFlags.NonPublic | BindingFlags.Instance);
            return (object[][])dataMethod.Invoke(_fixture, null);
        }

        private bool IsParameterized(MethodInfo testMethod)
        {
            return testMethod.GetParameters().Length > 0;
        }
    }
}