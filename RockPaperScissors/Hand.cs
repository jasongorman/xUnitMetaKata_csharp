namespace RockPaperScissors
{
    public class Hand
    {
        private readonly string _name;

        public static readonly Hand Rock;
        public static readonly Hand Paper;
        public static readonly Hand Scissors;

        private Hand _beats;

        static Hand()
        {
            Rock = new Hand("Rock");
            Paper = new Hand("Paper");
            Scissors = new Hand("Scissors");
            Rock._beats = Scissors;
            Scissors._beats = Paper;
            Paper._beats = Rock;
        }

        private Hand(string name)
        {
            _name = name;
        }

        internal int PlayHand(Hand player2)
        {
            if (player2 == _beats)
                return 1;
            if (player2 == this)
                return 0;
            return 2;
        }

        public override string ToString()
        {
            return _name;
        }
    }
}