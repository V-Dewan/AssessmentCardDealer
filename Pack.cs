using System;
namespace AssessmentCardDealer
{
    class Pack
    {
        public List<Card> pack = new List<Card>();
        private static Random rng = new Random();

        public Pack()
        {
            //Initialise the card pack here
            for (int suit = 1; suit < 5; suit++)
            {
                for (int value = 1; value < 14; value++)
                {
                    pack.Add(new Card(value, suit));
                }
            }

        }




        public bool shuffleCardPack(int typeOfShuffle)
        {
            //Shuffles the pack based on the type of shuffle


            if (typeOfShuffle == 1)
            {
                int n = pack.Count;
                while (n > 1)
                {
                    n--;
                    int k = rng.Next(n + 1);
                    Card card = pack[k];
                    pack[k] = pack[n];
                    pack[n] = card;
                }
            }
            else if (typeOfShuffle == 2)
            {
                Random random = new Random();
                int x = random.Next(10, 20);
                List<Card> shuffledcards = new List<Card>();

                for (int i = 0; i < x; i++)
                {
                    int cut = (pack.Count / 2);

                    List<Card> top = pack.GetRange(0, cut);
                    List<Card> bottom = pack.GetRange(cut, pack.Count - cut);

                    shuffledcards.Clear();



                    while (top.Count > 0 && bottom.Count > 0)
                    {
                        if (random.Next(2) == 0)
                        {
                            shuffledcards.Add(top[0]);
                            top.RemoveAt(0);
                        }
                        else
                        {
                            shuffledcards.Add(bottom[0]);
                            bottom.RemoveAt(0);
                        }
                    }
                    shuffledcards.AddRange(top);
                    shuffledcards.AddRange(bottom);
                }
                pack = shuffledcards;
            }

            return true;
        }



        public Card deal()
        {
            //Deals one card
            Card card;
            card = pack[0];
            pack.RemoveAt(0);
            return card;
        }



        public List<Card> dealCard(int amount)
        {
            //Deals the number of cards specified by 'amount'
            List<Card> MultiCards = new List<Card>();
            MultiCards = pack.Take(amount).ToList();
            pack.RemoveRange(0, amount);
            return MultiCards;
        }
    }
}

