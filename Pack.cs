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
            //produces cards with value 1-13 within each suit 1-4
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


            if (typeOfShuffle == 1)     //selects the fisher-yates shuffle
            {
                int n = pack.Count;
                while (n > 1)
                {
                   
                    n--;    //starts from the end of the list
                    int k = rng.Next(n + 1);    //generating a random number
                    Card tempcard = pack[k];    //placing the card of the random location into a temporary place
                    pack[k] = pack[n];          //placing the card of the current location into the random location     
                    pack[n] = tempcard;         //placing the card within the temporary place into the current location
                }
            }
            else if (typeOfShuffle == 2)    //selects the riffle shuffle
            {
                Random random = new Random();
                int x = random.Next(10, 20);    //generating a random number within the selected range
                List<Card> shuffledcards = new List<Card>();

                for (int i = 0; i < x; i++)     //shuffling the cards an x amount of times
                {
                    int cut = (pack.Count / 2);
                    //split the pack of cards into 2
                    List<Card> top = pack.GetRange(0, cut);
                    List<Card> bottom = pack.GetRange(cut, pack.Count - cut);

                    shuffledcards.Clear();

                    while (top.Count > 0 && bottom.Count > 0)
                    {   
                        int rng = random.Next(0, 2);    //generating a number
                        if (rng == 1)        //if it's 1, add a card from the top pile. Else add a card from the bottom pile
                        {
                            shuffledcards.Add(top[0]);
                            top.RemoveAt(0);    //removing the added card from the top pile
                        }
                        else
                        {
                            shuffledcards.Add(bottom[0]);
                            bottom.RemoveAt(0); //removing the added card from the bottom pile
                        }
                    }
                    shuffledcards.AddRange(top);        //adding the leftover cards to the end
                    shuffledcards.AddRange(bottom);     
                    pack = shuffledcards;
                }

            }

            return true;
        }



        public Card deal()
        {
            //Deals one card from the pack and removes the dealt card from the pack.
            Card card;
            card = pack[0];
            pack.RemoveAt(0);
            return card;
        }



        public List<Card> dealCard(int amount)
        {
            //Deals the number of cards specified by 'amount' from the pack and removes the dealt cards from the pack.
            List<Card> MultiCards = new List<Card>();
            MultiCards = pack.Take(amount).ToList();
            pack.RemoveRange(0, amount);
            return MultiCards;
        }
    }
}

