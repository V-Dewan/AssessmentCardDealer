using System;
namespace AssessmentCardDealer
{
    class Card
    {
        //Base for the Card class.
        //Value: numbers 1 - 13
        //Suit: numbers 1 - 4
        //The 'set' methods for these properties could have some validation
        public Card(int value, int suit)
        {
            Value = value;
            Suit = suit;
        }

        private int _value;
        private int _suit;

        public int Value
        {
            get { return _value; }
            set
            {
                if (value >= 1 && value <= 13)
                {
                    _value = value;
                }
                else
                {
                    throw new Exception("Error. Value should be between 1 and 13");
                }
            }
        }
        public int Suit
        {
            get { return _suit; }
            set
            {
                if (value >= 1 && value <= 4)
                {
                    _suit = value;
                }
                else
                {
                    throw new Exception("Error. Suit should be between 1 and 4");
                }

            }
        }

        public override string ToString()
        {
            string V;
            string S;

            if (Value == 1)
            {
                V = "Ace";
            }
            else if (Value == 11)
            {
                V = "Jack";
            }
            else if (Value == 12)
            {
                V = "Queen";
            }
            else if (Value == 13)
            {
                V = "King";
            }
            else
            {
                V = Convert.ToString(Value);
            }

            if (Suit == 1)
            {
                S = "Clubs";
            }
            else if (Suit == 2)
            {
                S = "Diamonds";
            }
            else if (Suit == 3)
            {
                S = "Hearts";
            }
            else
            {
                S = "Spades";
            }


            return V + " of " + S;
        }

    }
}

