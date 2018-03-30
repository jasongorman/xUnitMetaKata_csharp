using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    public class Game
    {
        private int _player1Score = 0;
        private int _player2Score = 0;
        private IGameListener _listener;

        public Game(IGameListener listener)
        {
            _listener = listener;
        }

        public void PlayRound(string player1, string player2)
        {
            int result = new Round().Play(player1, player2);
            if (result == 1) _player1Score++;
            if (result == 2) _player2Score++;

            if (_player1Score == 2)
            {
                _listener.GameOver(1);
            }

            if (_player2Score == 2)
            {
                _listener.GameOver(2);
            }
        }
    }
}
