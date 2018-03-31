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
            if (result == 1)
            {
                _testSuite.AddTestPassed();
                Console.WriteLine("player 1 wins game: PASS");
            }
            else
            {
                _testSuite.AddTestFailed();
                Console.WriteLine("player 1 wins game: FAIL - expected 1 but was {0}", result);
            }

            // player 2 wins game
            listener = new SpyGameListener();
            game = new Game(listener);
            game.PlayRound(Hand.Rock, Hand.Paper);
            game.PlayRound(Hand.Rock, Hand.Paper);

            result = listener.Winner;
            if (result == 2)
            {
                _testSuite.AddTestPassed();
                Console.WriteLine("player 2 wins game: PASS");
            }
            else
            {
                _testSuite.AddTestFailed();
                Console.WriteLine("player 2 wins game: FAIL - expected 2 but was {0}", result);
            }

            // drawers not counted
            listener = new SpyGameListener();
            game = new Game(listener);
            game.PlayRound(Hand.Rock, Hand.Rock);
            game.PlayRound(Hand.Rock, Hand.Rock);

            result = listener.Winner;
            if (result == 0)
            {
                _testSuite.AddTestPassed();
                Console.WriteLine("drawers not counted: PASS");
            }
            else
            {
                _testSuite.AddTestFailed();
                Console.WriteLine("drawers not counted: FAIL - expected 0 but was {0}", result);
            }

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
            if (result == 0)
            {
                _testSuite.AddTestPassed();
                Console.WriteLine("invalid moves not counted: PASS");
            }
            else
            {
                _testSuite.AddTestFailed();
                Console.WriteLine("invalid moves not counted: FAIL - expected 0 but was {0}", result);
            }
        }
    }
}