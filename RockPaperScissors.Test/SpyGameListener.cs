namespace RockPaperScissors.Test
{
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