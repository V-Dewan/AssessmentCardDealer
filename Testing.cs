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
            
            //allows the user to input what type of shuffle the user would like to use
            //loops until the validation is complete
            do
            {
                Console.WriteLine("Pick the shuffle you want to use:\nFisher-Yates [1] | Riffle Shuffle [2] | No Shuffle [3]");
                ShuffleType = Validation1(ShuffleType);     //makes sure that the input is an integer
                Check2 = Validation2(ShuffleType, 1, 3);    //makes sure that the user inputs the acceptable values
                shuffleCardPack(ShuffleType);
            }
            while (Check2 == 0);

            while (true)
            {
              
                int ContinueOrEnd = 0;
                Check2 = 0;

                //allows the user to input how many cards they would like to deal
                //loops until the validation is complete
                do
                {
                    Console.WriteLine("Cards Left:" + pack.Count + "\nEnter the amount of cards to deal:");
                    CardAmount = Validation1(CardAmount);               //validating the input 
                    Check2 = Validation2(CardAmount, 1, pack.Count);

                }
                while (Check2 == 0);


                if (CardAmount == 1)
                {
                    Console.WriteLine(deal());  //deals one card
                }
                else
                {
                    List<Card> MultiCard = dealCard(CardAmount);
                    foreach (var card in MultiCard)
                    {
                        Console.WriteLine(card);    //deals the amount of cards asked for
                    }
                }

                //allows the user to select if they would like to continue, reshuffle or end the program if there is still cards left in the pack.
                if (pack.Count != 0)
                {
                    Check2 = 0;
                    //loop until validation is complete
                    do
                    {
                        Console.WriteLine("Continue [1] | Shuffle the remaining cards [2] | End [3] ");
                        ContinueOrEnd = Validation1(ContinueOrEnd);     //validating the input
                        Check2 = Validation2(ContinueOrEnd, 1, 3);
                    }
                    while (Check2 == 0);

                    if (ContinueOrEnd == 1)
                    {
                        continue;
                    }
                    else if (ContinueOrEnd == 2)
                    {
                        shuffleCardPack(ShuffleType);   //added after code review       
                    }
                    else if (ContinueOrEnd == 3)
                    {
                        break;
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
            //making sure that only integers are accepted
            //loops until an integer has been inputted
            do
            {
                check = int.TryParse(Console.ReadLine(), out Input);
                if (check == false)
                {
                    Console.WriteLine("Error!\nPlease enter an integer: ");     //error message produced if it's not an integer
                }

            }
            while (check == false);

            return Input;
        }

        public int Validation2(int Input, int low, int high)
        {
            int _check2 = 0;
            //making sure that only integers within a certain range is accepted
            if (Input >= low && Input <= high)
            {
                _check2 = 1;
            }
            else
            {
                Console.WriteLine("Error!\nPlease enter a number between " + low + " and " + high);     //error message produced if it's not within an acceptable range
                _check2 = 0;
            }
            return _check2;
        }
    }
}

