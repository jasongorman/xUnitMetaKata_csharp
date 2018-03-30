using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    public class Round
    {
        public int Play(Hand player1, Hand player2)
        {
            if (player1 == null || player2 == null)
            {
                throw new InvalidMoveException();
            }
            return player1.PlayHand(player2);
        }
    }
}
