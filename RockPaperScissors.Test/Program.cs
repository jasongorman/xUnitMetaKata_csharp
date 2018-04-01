using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var testSuite = new TestSuite(new ConsoleOutput());
            Assert.TestSuite = testSuite;
            testSuite.RunAll();
        }
    }
}
