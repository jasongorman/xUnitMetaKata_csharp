using System;

namespace JasonUnit.Framework
{
    public abstract class Assert
    {
        public static TestSuite TestSuite { get; set; }

        public static void Equals(int expected, int result, string displayName)
        {
            if (result.Equals(expected))
            {
                TestSuite.TestPassed(displayName);
            }
            else
            {
                TestSuite.TestFailed(displayName, expected, result);
            }
        }

        public static void Throws(Action t, Type expectedException, string displayName)
        {
            Exception exception = null;

            try
            {
                t.Invoke();
            }
            catch (Exception e)
            {
                exception = e;
            }

            if (exception != null && exception.GetType() == expectedException)
            {
                TestSuite.TestPassed(displayName);
            }
            else
            {
                TestSuite.TestFailed(displayName, expectedException);
            }
        }
    }
}
