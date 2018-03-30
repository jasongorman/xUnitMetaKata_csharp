using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            int testsPassed = 0;
            int testsFailed = 0;

            // output header
            Console.WriteLine("Running RockPaperScissors tests...");

            // Round tests
            Console.WriteLine("Round tests...");

            // rock blunts scissors
            int result = new Round().Play(Hand.Rock, Hand.Scissors);
            if (result == 1)
            {
                testsPassed++;
                Console.WriteLine("rock blunts scissors (Rock, Scissors): PASS");
            }
            else
            {
                testsFailed++;
                Console.WriteLine("rock blunts scissors (Rock, Scissors): FAIL - expected 1 but was {0}", result);
            }

            result = new Round().Play(Hand.Scissors, Hand.Rock);
            if (result == 2)
            {
                testsPassed++;
                Console.WriteLine("rock blunts scissors (Scissors, Rock): PASS");
            }
            else
            {
                testsFailed++;
                Console.WriteLine("rock blunts scissors (Scissors, Rock): FAIL - expected 2 but was {0}", result);
            }

            // scissors cut paper
            result = new Round().Play(Hand.Scissors, Hand.Paper);
            if (result == 1)
            {
                testsPassed++;
                Console.WriteLine("scissors cut paper (Scissors, Paper): PASS");
            }
            else
            {
                testsFailed++;
                Console.WriteLine("scissors cut paper (Scissors, Paper): FAIL - expected 1 but was {0}", result);
            }

            result = new Round().Play(Hand.Paper, Hand.Scissors);
            if (result == 2)
            {
                testsPassed++;
                Console.WriteLine("scissors cut paper (Paper, Scissors): PASS");
            }
            else
            {
                testsFailed++;
                Console.WriteLine("scissors cut paper (Paper, Scissors): FAIL - expected 2 but was {0}", result);
            }

            // paper wraps rock
            result = new Round().Play(Hand.Paper, Hand.Rock);
            if (result == 1)
            {
                testsPassed++;
                Console.WriteLine("paper wraps rock (Paper, Rock): PASS");
            }
            else
            {
                testsFailed++;
                Console.WriteLine("paper wraps rock (Paper, Rock): FAIL - expected 1 but was {0}", result);
            }

            result = new Round().Play(Hand.Rock, Hand.Paper);
            if (result == 2)
            {
                testsPassed++;
                Console.WriteLine("paper wraps rock (Rock, Paper): PASS");
            }
            else
            {
                testsFailed++;
                Console.WriteLine("paper wraps rock (Rock, Paper): FAIL - expected 2 but was {0}", result);
            }

            // round is a draw
            result = new Round().Play(Hand.Rock, Hand.Rock);
            if (result == 0)
            {
                testsPassed++;
                Console.WriteLine("round is a draw (Rock, Rock): PASS");
            }
            else
            {
                testsFailed++;
                Console.WriteLine("round is a draw (Rock, Rock): FAIL - expected 0 but was {0}", result);
            }

            result = new Round().Play(Hand.Scissors, Hand.Scissors);
            if (result == 0)
            {
                testsPassed++;
                Console.WriteLine("round is a draw (Scissors, Scissors): PASS");
            }
            else
            {
                testsFailed++;
                Console.WriteLine("round is a draw (Scissors, Scissors): FAIL - expected 0 but was {0}", result);
            }

            result = new Round().Play(Hand.Paper, Hand.Paper);
            if (result == 0)
            {
                testsPassed++;
                Console.WriteLine("round is a draw (Paper, Paper): PASS");
            }
            else
            {
                testsFailed++;
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
                testsPassed++;
                Console.WriteLine("invalid inputs not allowed: PASS");
            }
            else
            {
                testsFailed++;
                Console.WriteLine("invalid inputs not allowed: FAIL - expected InvalidMoveException");
            }

            // Game tests
            Console.WriteLine("Game tests...");

            // player 1 wins game
            SpyGameListener listener = new SpyGameListener();
            Game game = new Game(listener);
            game.PlayRound(Hand.Rock, Hand.Scissors);
            game.PlayRound(Hand.Rock, Hand.Scissors);

            result = listener.Winner;
            if (result == 1)
            {
                testsPassed++;
                Console.WriteLine("player 1 wins game: PASS");
            }
            else
            {
                testsFailed++;
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
                testsPassed++;
                Console.WriteLine("player 2 wins game: PASS");
            }
            else
            {
                testsFailed++;
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
                testsPassed++;
                Console.WriteLine("drawers not counted: PASS");
            }
            else
            {
                testsFailed++;
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
                testsPassed++;
                Console.WriteLine("invalid moves not counted: PASS");
            }
            else
            {
                testsFailed++;
                Console.WriteLine("invalid moves not counted: FAIL - expected 0 but was {0}", result);
            }


            Console.WriteLine("Tests run: {0}  Passed: {1}  Failed: {2}", testsPassed + testsFailed, testsPassed, testsFailed);
        }
    }

    internal class SpyGameListener : IGameListener
    {
        private int _winner = 0;

        public int Winner
        {
            get { return _winner; }
        }

        public void GameOver(int winner)
        {
            _winner = winner;
        }
    }
}
