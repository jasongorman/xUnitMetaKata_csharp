using System;

namespace RockPaperScissors.Test
{
    internal class GameTests
    {
        public void RunAll()
        {
            Console.WriteLine("Game tests...");
            TestPlayer1WinsGame();
            TestPlayer2WinsGame();
            TestDrawersNotCounted();
            TestInvalidMovesNotCounted();
        }

        private void TestInvalidMovesNotCounted()
        {
            SpyGameListener listener = new SpyGameListener();
            Game game = new Game(listener);
            try
            {
                game.PlayRound(null, null);
                game.PlayRound(Hand.Rock, Hand.Scissors);
            }
            catch (Exception e)
            {
            }

            int result = listener.Winner;
            Assert.Equals(0, result, "invalid moves not counted");
        }

        private void TestDrawersNotCounted()
        {
            SpyGameListener listener = new SpyGameListener();
            Game game = new Game(listener);
            game.PlayRound(Hand.Rock, Hand.Rock);
            game.PlayRound(Hand.Rock, Hand.Rock);

            int result = listener.Winner;
            Assert.Equals(0, result, "drawers not counted");
        }

        private void TestPlayer2WinsGame()
        {
            SpyGameListener listener = new SpyGameListener();
            Game game = new Game(listener);
            game.PlayRound(Hand.Rock, Hand.Paper);
            game.PlayRound(Hand.Rock, Hand.Paper);

            int result = listener.Winner;
            Assert.Equals(2, result, "player 2 wins game");
        }

        private void TestPlayer1WinsGame()
        {
            SpyGameListener listener = new SpyGameListener();
            Game game = new Game(listener);
            game.PlayRound(Hand.Rock, Hand.Scissors);
            game.PlayRound(Hand.Rock, Hand.Scissors);

            int result = listener.Winner;
            Assert.Equals(1, result, "player 1 wins game");
        }
    }
}