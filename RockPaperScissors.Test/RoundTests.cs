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
            AssertEquals(result, 1, "rock blunts scissors (Rock, Scissors)");

            result = new Round().Play(Hand.Scissors, Hand.Rock);
            AssertEquals(result, 2, "rock blunts scissors (Scissors, Rock)");


            // scissors cut paper
            result = new Round().Play(Hand.Scissors, Hand.Paper);
            AssertEquals(result, 1, "scissors cut paper (Scissors, Paper)");

            result = new Round().Play(Hand.Paper, Hand.Scissors);
            AssertEquals(result, 2, "scissors cut paper (Paper, Scissors)");

            // paper wraps rock
            result = new Round().Play(Hand.Paper, Hand.Rock);
            AssertEquals(result, 1, "paper wraps rock (Paper, Rock)");

            result = new Round().Play(Hand.Rock, Hand.Paper);
            AssertEquals(result, 2, "paper wraps rock (Rock, Paper)");

            // round is a draw
            result = new Round().Play(Hand.Rock, Hand.Rock);
            AssertEquals(result, 0, "round is a draw (Rock, Rock)");

            result = new Round().Play(Hand.Scissors, Hand.Scissors);
            AssertEquals(result, 0, "round is a draw (Scissors, Scissors)");

            result = new Round().Play(Hand.Paper, Hand.Paper);
            AssertEquals(result, 0, "round is a draw (Paper, Paper)");

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

        private void AssertEquals(int result, int expected, string displayName)
        {
            if (result.Equals(expected))
            {
                _testSuite.AddTestPassed();
                Console.WriteLine(string.Format("{0}: PASS", displayName));
            }
            else
            {
                _testSuite.AddTestFailed();
                Console.WriteLine(string.Format("{0}: FAIL - expected {1} but was {2}", displayName, expected, result));
            }
        }
    }
}