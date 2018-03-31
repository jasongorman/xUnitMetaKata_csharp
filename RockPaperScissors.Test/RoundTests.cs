using System;
using System.Reflection;

namespace RockPaperScissors.Test
{
    public class RoundTests
    {
        public void TestInvalidInputsNotAllowed()
        {
            Assert.Throws(() => new Round().Play(null, null), typeof(InvalidMoveException), "invalid inputs not allowed");
        }

        public void TestRoundIsADraw()
        {
            foreach (Hand hand in DataFor_TestRoundIsADraw())
            {
                CheckForDrawer(hand);
            }
        }

        private object[] DataFor_TestRoundIsADraw()
        {
            return new object[]
            {
                Hand.Rock,
                Hand.Scissors,
                Hand.Paper
            };
        }

        private void CheckForDrawer(Hand player1)
        {
            int result = new Round().Play(player1, player1);
            Assert.Equals(0, result, string.Format("round is a draw ({0})", player1.ToString()));
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