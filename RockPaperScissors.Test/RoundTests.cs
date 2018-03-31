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
            Console.WriteLine("Round tests...");

            TestRockBluntsScissors();
            TestScissorsCutPaper();
            TestPaperWrapsRock();
            TestRoundIsADraw();
            TestInvalidInputsNotAllowed();
        }

        private void TestInvalidInputsNotAllowed()
        {
            AssertThrows(() => new Round().Play(null, null), typeof(InvalidMoveException), "invalid inputs not allowed");
        }

        private void TestRoundIsADraw()
        {
            int result = new Round().Play(Hand.Rock, Hand.Rock);
            AssertEquals(0, result, "round is a draw (Rock, Rock)");

            result = new Round().Play(Hand.Scissors, Hand.Scissors);
            AssertEquals(0, result, "round is a draw (Scissors, Scissors)");

            result = new Round().Play(Hand.Paper, Hand.Paper);
            AssertEquals(0, result, "round is a draw (Paper, Paper)");
        }

        private void TestPaperWrapsRock()
        {
            int result = new Round().Play(Hand.Paper, Hand.Rock);
            AssertEquals(1, result, "paper wraps rock (Paper, Rock)");

            result = new Round().Play(Hand.Rock, Hand.Paper);
            AssertEquals(2, result, "paper wraps rock (Rock, Paper)");
        }

        private void TestScissorsCutPaper()
        {
            int result = new Round().Play(Hand.Scissors, Hand.Paper);
            AssertEquals(1, result, "scissors cut paper (Scissors, Paper)");

            result = new Round().Play(Hand.Paper, Hand.Scissors);
            AssertEquals(2, result, "scissors cut paper (Paper, Scissors)");
        }

        private void TestRockBluntsScissors()
        {
            int result = new Round().Play(Hand.Rock, Hand.Scissors);
            AssertEquals(1, result, "rock blunts scissors (Rock, Scissors)");

            result = new Round().Play(Hand.Scissors, Hand.Rock);
            AssertEquals(2, result, "rock blunts scissors (Scissors, Rock)");
        }

        private void AssertEquals(int expected, int result, string displayName)
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

        private void AssertThrows(Action t, Type expectedException, string displayName)
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
                _testSuite.AddTestPassed();
                Console.WriteLine(string.Format("{0}: PASS", displayName));
            }
            else
            {
                _testSuite.AddTestFailed();
                Console.WriteLine(string.Format("{0}: FAIL - expected {1}", displayName, expectedException.Name));
            }
        }
    }
}