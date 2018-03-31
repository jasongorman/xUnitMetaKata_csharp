using System;

namespace RockPaperScissors.Test
{
    internal class TestSuite
    {
        private int _testsPassed;
        private int _testsFailed;

        public void RunAll()
        {
            _testsPassed = 0;
            _testsFailed = 0;

            // output header
            Console.WriteLine("Running RockPaperScissors tests...");

            new RoundTests(this).RunAll();

            new GameTests(this).RunAll();


            Console.WriteLine("Tests run: {0}  Passed: {1}  Failed: {2}", _testsPassed + _testsFailed, _testsPassed, _testsFailed);
        }

        public void AddTestFailed()
        {
            _testsFailed++;
        }

        public void AddTestPassed()
        {
            _testsPassed++;
        }
    }
}