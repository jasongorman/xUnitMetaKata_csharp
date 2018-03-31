using System;

namespace RockPaperScissors.Test
{
    internal class RoundTests
    {
        private readonly TestSuite _testSuite;

        public RoundTests(TestSuite testSuite)
        {
            _testSuite = testSuite;
        }

        internal void RunAll()
        {
// Round tests
            Console.WriteLine("Round tests...");

            // rock blunts scissors
            int result = new Round().Play(Hand.Rock, Hand.Scissors);
            if (result == 1)
            {
                _testSuite.AddTestPassed();
                Console.WriteLine("rock blunts scissors (Rock, Scissors): PASS");
            }
            else
            {
                _testSuite.AddTestFailed();
                Console.WriteLine("rock blunts scissors (Rock, Scissors): FAIL - expected 1 but was {0}", result);
            }

            result = new Round().Play(Hand.Scissors, Hand.Rock);
            if (result == 2)
            {
                _testSuite.AddTestPassed();
                Console.WriteLine("rock blunts scissors (Scissors, Rock): PASS");
            }
            else
            {
                _testSuite.AddTestFailed();
                Console.WriteLine("rock blunts scissors (Scissors, Rock): FAIL - expected 2 but was {0}", result);
            }

            // scissors cut paper
            result = new Round().Play(Hand.Scissors, Hand.Paper);
            if (result == 1)
            {
                _testSuite.AddTestPassed();
                Console.WriteLine("scissors cut paper (Scissors, Paper): PASS");
            }
            else
            {
                _testSuite.AddTestFailed();
                Console.WriteLine("scissors cut paper (Scissors, Paper): FAIL - expected 1 but was {0}", result);
            }

            result = new Round().Play(Hand.Paper, Hand.Scissors);
            if (result == 2)
            {
                _testSuite.AddTestPassed();
                Console.WriteLine("scissors cut paper (Paper, Scissors): PASS");
            }
            else
            {
                _testSuite.AddTestFailed();
                Console.WriteLine("scissors cut paper (Paper, Scissors): FAIL - expected 2 but was {0}", result);
            }

            // paper wraps rock
            result = new Round().Play(Hand.Paper, Hand.Rock);
            if (result == 1)
            {
                _testSuite.AddTestPassed();
                Console.WriteLine("paper wraps rock (Paper, Rock): PASS");
            }
            else
            {
                _testSuite.AddTestFailed();
                Console.WriteLine("paper wraps rock (Paper, Rock): FAIL - expected 1 but was {0}", result);
            }

            result = new Round().Play(Hand.Rock, Hand.Paper);
            if (result == 2)
            {
                _testSuite.AddTestPassed();
                Console.WriteLine("paper wraps rock (Rock, Paper): PASS");
            }
            else
            {
                _testSuite.AddTestFailed();
                Console.WriteLine("paper wraps rock (Rock, Paper): FAIL - expected 2 but was {0}", result);
            }

            // round is a draw
            result = new Round().Play(Hand.Rock, Hand.Rock);
            if (result == 0)
            {
                _testSuite.AddTestPassed();
                Console.WriteLine("round is a draw (Rock, Rock): PASS");
            }
            else
            {
                _testSuite.AddTestFailed();
                Console.WriteLine("round is a draw (Rock, Rock): FAIL - expected 0 but was {0}", result);
            }

            result = new Round().Play(Hand.Scissors, Hand.Scissors);
            if (result == 0)
            {
                _testSuite.AddTestPassed();
                Console.WriteLine("round is a draw (Scissors, Scissors): PASS");
            }
            else
            {
                _testSuite.AddTestFailed();
                Console.WriteLine("round is a draw (Scissors, Scissors): FAIL - expected 0 but was {0}", result);
            }

            result = new Round().Play(Hand.Paper, Hand.Paper);
            if (result == 0)
            {
                _testSuite.AddTestPassed();
                Console.WriteLine("round is a draw (Paper, Paper): PASS");
            }
            else
            {
                _testSuite.AddTestFailed();
                Console.WriteLine("round is a draw (Paper, Paper): FAIL - expected 0 but was {0}", result);
            }

            // invalid inputs not allowed
            Exception exception = null;

            try
            {
                new Round().Play(null, null);
            }
            catch (Exception e)
            {
                exception = e;
            }

            if (exception is InvalidMoveException)
            {
                _testSuite.AddTestPassed();
                Console.WriteLine("invalid inputs not allowed: PASS");
            }
            else
            {
                _testSuite.AddTestFailed();
                Console.WriteLine("invalid inputs not allowed: FAIL - expected InvalidMoveException");
            }
        }
    }
}