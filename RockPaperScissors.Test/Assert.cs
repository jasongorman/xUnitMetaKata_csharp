using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.Test
{
    abstract class Assert
    {
        public static TestSuite TestSuite { get; set; }

        public static void Equals(int expected, int result, string displayName)
        {
            if (result.Equals(expected))
            {
                TestSuite.AddTestPassed();
                Console.WriteLine(String.Format("{0}: PASS", displayName));
            }
            else
            {
                TestSuite.AddTestFailed();
                Console.WriteLine(String.Format("{0}: FAIL - expected {1} but was {2}", displayName, expected, result));
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
                TestSuite.AddTestPassed();
                Console.WriteLine(String.Format("{0}: PASS", displayName));
            }
            else
            {
                TestSuite.AddTestFailed();
                Console.WriteLine(String.Format("{0}: FAIL - expected {1}", displayName, expectedException.Name));
            }
        }
    }
}
