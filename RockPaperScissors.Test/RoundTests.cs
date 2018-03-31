using System;
using System.Reflection;

namespace RockPaperScissors.Test
{
    public class RoundTests
    {
        private readonly TestRunner _testRunner;

        public RoundTests()
        {
            _testRunner = new TestRunner(this);
        }

        public TestRunner TestRunner
        {
            get { return _testRunner; }
        }

        public void TestInvalidInputsNotAllowed()
        {
            Assert.Throws(() => new Round().Play(null, null), typeof(InvalidMoveException), "invalid inputs not allowed");
        }

        public void TestRoundIsADraw()
        {
            int result = new Round().Play(Hand.Rock, Hand.Rock);
            Assert.Equals(0, result, "round is a draw (Rock, Rock)");

            result = new Round().Play(Hand.Scissors, Hand.Scissors);
            Assert.Equals(0, result, "round is a draw (Scissors, Scissors)");

            result = new Round().Play(Hand.Paper, Hand.Paper);
            Assert.Equals(0, result, "round is a draw (Paper, Paper)");
        }

        public void TestPaperWrapsRock()
        {
            int result = new Round().Play(Hand.Paper, Hand.Rock);
            Assert.Equals(1, result, "paper wraps rock (Paper, Rock)");

            result = new Round().Play(Hand.Rock, Hand.Paper);
            Assert.Equals(2, result, "paper wraps rock (Rock, Paper)");
        }

        public void TestScissorsCutPaper()
        {
            int result = new Round().Play(Hand.Scissors, Hand.Paper);
            Assert.Equals(1, result, "scissors cut paper (Scissors, Paper)");

            result = new Round().Play(Hand.Paper, Hand.Scissors);
            Assert.Equals(2, result, "scissors cut paper (Paper, Scissors)");
        }

        public void TestRockBluntsScissors()
        {
            int result = new Round().Play(Hand.Rock, Hand.Scissors);
            Assert.Equals(1, result, "rock blunts scissors (Rock, Scissors)");

            result = new Round().Play(Hand.Scissors, Hand.Rock);
            Assert.Equals(2, result, "rock blunts scissors (Scissors, Rock)");
        }
    }
}