using System;
namespace AssessmentCardDealer
{
    class Testing : Pack
    {
        public Testing()
        {
            int ShuffleType = 0;
            int CardAmount = 0;
            int Check2 = 0;
            do
            {
                Console.WriteLine("Pick the shuffle you want to use:\nFisher-Yates [1] | Riffle Shuffle [2] | No Shuffle [3]");
                ShuffleType = Validation1(ShuffleType);
                Check2 = Validation2(ShuffleType, 1, 3);
                shuffleCardPack(ShuffleType);
            }
            while (Check2 == 0);


            while (true)
            {

                int ContinueOrEnd = 0;
                Check2 = 0;

                do
                {
                    Console.WriteLine("Cards Left:" + pack.Count + "\nEnter the amount of cards to deal:");
                    CardAmount = Validation1(CardAmount);
                    Check2 = Validation2(CardAmount, 1, pack.Count);

                }
                while (Check2 == 0);


                if (CardAmount == 1)
                {
                    Console.WriteLine(deal());
                }
                else
                {
                    List<Card> MultiCard = dealCard(CardAmount);
                    foreach (var card in MultiCard)
                    {
                        Console.WriteLine(card);
                    }
                }

                if (pack.Count != 0)
                {
                    Console.WriteLine("End [2] to end | Continue [Any other number]");
                    ContinueOrEnd = Validation1(ContinueOrEnd);
                    if (ContinueOrEnd == 2)
                    {
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Thank you for playing!");
                    break;
                }



            }

        }

        public int Validation1(int Input)
        {
            bool check = false;

            do
            {
                check = int.TryParse(Console.ReadLine(), out Input);
                if (check == false)
                {
                    Console.WriteLine("Error\nPlease enter an integer:");
                }

            }
            while (check == false);

            return Input;
        }

        public int Validation2(int Input, int low, int high)
        {
            int _check2 = 0;

            if (Input >= low && Input <= high)
            {
                _check2 = 1;
            }
            else
            {
                Console.WriteLine("Error\nPlease enter a number between" + low + " and " + high);
                _check2 = 0;
            }
            return _check2;
        }
    }
}

