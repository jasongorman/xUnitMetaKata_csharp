using System;
using JasonUnit.Framework;

namespace RockPaperScissors.Test
{
    public class GameTests
    {
        public void TestInvalidMovesNotCounted()
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

            Assert.Equals(0, listener.Winner, "invalid moves not counted");
        }

        public void TestDrawersNotCounted()
        {
            SpyGameListener listener = new SpyGameListener();
            Game game = new Game(listener);
            game.PlayRound(Hand.Rock, Hand.Rock);
            game.PlayRound(Hand.Rock, Hand.Rock);

            Assert.Equals(0, listener.Winner, "drawers not counted");
        }

        public void TestPlayer2WinsGame()
        {
            SpyGameListener listener = new SpyGameListener();
            Game game = new Game(listener);
            game.PlayRound(Hand.Rock, Hand.Paper);
            game.PlayRound(Hand.Rock, Hand.Paper);

            Assert.Equals(2, listener.Winner, "player 2 wins game");
        }

        public void TestPlayer1WinsGame()
        {
            SpyGameListener listener = new SpyGameListener();
            Game game = new Game(listener);
            game.PlayRound(Hand.Rock, Hand.Scissors);
            game.PlayRound(Hand.Rock, Hand.Scissors);

            Assert.Equals(1, listener.Winner, "player 1 wins game");
        }
    }
}