using System;

namespace RockPaperScissors.Test
{
    internal class GameTests
    {
        private readonly TestSuite _testSuite;

        public GameTests(TestSuite testSuite)
        {
            _testSuite = testSuite;
        }

        public void RunAll()
        {
// Game tests
            Console.WriteLine("Game tests...");

            // player 1 wins game
            SpyGameListener listener = new SpyGameListener();
            Game game = new Game(listener);
            game.PlayRound(Hand.Rock, Hand.Scissors);
            game.PlayRound(Hand.Rock, Hand.Scissors);

            int result = listener.Winner;
            Assert.Equals(1, result, "player 1 wins game");

            // player 2 wins game
            listener = new SpyGameListener();
            game = new Game(listener);
            game.PlayRound(Hand.Rock, Hand.Paper);
            game.PlayRound(Hand.Rock, Hand.Paper);

            result = listener.Winner;
            Assert.Equals(2, result, "player 2 wins game");

            // drawers not counted
            listener = new SpyGameListener();
            game = new Game(listener);
            game.PlayRound(Hand.Rock, Hand.Rock);
            game.PlayRound(Hand.Rock, Hand.Rock);

            result = listener.Winner;
            Assert.Equals(0, result, "drawers not counted");

            //invalid moves not counted
            listener = new SpyGameListener();
            game = new Game(listener);
            try
            {
                game.PlayRound(null, null);
                game.PlayRound(Hand.Rock, Hand.Scissors);
            }
            catch (Exception e)
            {
            }

            result = listener.Winner;
            Assert.Equals(0, result, "invalid moves not counted");
        }
    }
}