using System;


namespace Battle_Ship_Game
{
    public class Message
    {
        

        public void PrintWelcomeMessage()
        {
            Console.Clear();
            Console.WriteLine("\n ** BattleShip Game ** ");
            Console.WriteLine("=======================");

        }


        public void PrintInitialPrompt()
        {
            Console.WriteLine("Do you want to play BattleShip Game?");
            Console.WriteLine("Please type 'yes' or something else to quit:");
            Console.Write("> ");
        }

        public void PrintAttemptsAndHits(int Attempts, int ShipHits)
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("|    Remaining attemps: {0}     |    Hits: {1}    |", Attempts, 5 - ShipHits);
            Console.WriteLine("----------------------------------------------");
        }


        public void PrintValidNumberRanges()
        {
            Console.WriteLine("Make a valid shot. Numbers from 1 to 10 only. \n");
        }

        public static void PrintAskForCordinate(char coordinate)
        {
            Console.WriteLine($"{coordinate} axis: ");
            Console.Write("> ");
        }

        public void PrintInvalidShot()
        {
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("** INVALID SHOT **. Please enter valid shot.");
            Console.WriteLine("------------------------------------------------");
        }

        public void PrintShotResult(bool isMissShot)
        {
            Console.WriteLine("\n");
            if(isMissShot)
            {
                ChangeConsoleColor(ConsoleColor.Red, ConsoleColor.White);
                Console.WriteLine("\t*** You MISS. Try again!! ***");
            } 
            else
            {
                ChangeConsoleColor(ConsoleColor.Green, ConsoleColor.Black);
                Console.WriteLine("\t*** You HIT. Well done!! ***");
            }
            Console.WriteLine("-----------------------------------------------");
            Console.ResetColor();
        }

        

        public void PrintGameOver()
        {
            ChangeConsoleColor(ConsoleColor.Red, ConsoleColor.White);
            Console.WriteLine("//////////////////////////////////////////////////");
            Console.WriteLine("/////////// Game Over ////////////////////////////");
            Console.WriteLine("//////////////////////////////////////////////////");
            Console.ResetColor();
        }

        public void PrintGameWon()
        {
            ChangeConsoleColor(ConsoleColor.Green, ConsoleColor.White);
            Console.WriteLine("//////////////////////////////////////////////////");
            Console.WriteLine("/////////// You Won!! ////////////////////////////");
            Console.WriteLine("//////////////////////////////////////////////////");
            Console.ResetColor();
        }
        

        public void ChangeConsoleColor(ConsoleColor backgroundColor, ConsoleColor foregroundColor)
        {
            Console.BackgroundColor = backgroundColor;
            Console.ForegroundColor = foregroundColor;
        }

    }
}