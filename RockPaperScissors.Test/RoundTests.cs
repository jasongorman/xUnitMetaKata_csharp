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

        public void TestRoundIsADraw(Hand hand)
        {
                int result = new Round().Play(hand, hand);
                Assert.Equals(0, result, string.Format("round is a draw ({0})", hand));
        }

        private object[][] DataFor_TestRoundIsADraw()
        {
            return new object[][]
            {
                new object[]{Hand.Rock},
                new object[]{Hand.Scissors},
                new object[]{Hand.Paper}
            };
        }

        public void TestPaperWrapsRock(Hand player1, Hand player2, int expectedResult)
        {
            int result = new Round().Play(player1, player2);
            Assert.Equals(expectedResult, result, string.Format("paper wraps rock ({0},{1})", player1, player2));
        }

        private object[][] DataFor_TestPaperWrapsRock()
        {
            return new object[][]
            {
                new object[]{Hand.Paper, Hand.Rock, 1}, 
                new object[]{Hand.Rock, Hand.Paper, 2}, 
            };
        }

        public void TestScissorsCutPaper(Hand player1, Hand player2, int expectedResult)
        {
            int result = new Round().Play(player1, player2);
            Assert.Equals(expectedResult, result, string.Format("scissors cut paper ({0}, {1})", player1, player2));
        }

        private object[][] DataFor_TestScissorsCutPaper()
        {
            return new object[][]
            {
                new object[]{Hand.Scissors, Hand.Paper, 1}, 
                new object[]{Hand.Paper, Hand.Scissors, 2}, 
            };
        }

        public void TestRockBluntsScissors(Hand player1, Hand player2, int expectedResult)
        {
            int result = new Round().Play(player1, player2);
            Assert.Equals(expectedResult, result, string.Format("rock blunts scissors ({0}, {1})", player1, player2));
        }

        private object[][] DataFor_TestRockBluntsScissors()
        {
            return new object[][]
            {
                new object[]{Hand.Rock, Hand.Scissors, 1}, 
                new object[]{Hand.Scissors, Hand.Rock, 2}, 
            };
        }
    }
}