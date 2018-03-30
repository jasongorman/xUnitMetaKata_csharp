namespace RockPaperScissors
{
    public class Hand
    {
        public static readonly Hand Rock;
        public static readonly Hand Paper;
        public static readonly Hand Scissors;

        private Hand _beats;

        static Hand()
        {
            Rock = new Hand();
            Paper = new Hand();
            Scissors = new Hand();
            Rock._beats = Scissors;
            Scissors._beats = Paper;
            Paper._beats = Rock;
        }

        private Hand()
        {
        }

        internal int PlayHand(Hand player2)
        {
            if (player2 == _beats)
                return 1;
            if (player2 == this)
                return 0;
            return 2;
        }
    }
}