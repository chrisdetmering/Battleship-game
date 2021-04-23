using System;

namespace Battle_Ship_Game
{
    class Program
    {
        public static bool isGameActive = false;
        
        static void Main(string[] args)
        {
            // bool isGameActive = false;
            BattleShipGame game = new BattleShipGame();

            //PrintWelcomeMessage();
            if(AskForNewGame()){
                isGameActive = game.InitializeGame();
            }

            game.GameLoop(isGameActive);
        }

        public static bool AskForNewGame()
        {
            Message message = new Message();
            bool isPlayerReady = false;
            
            message.PrintWelcomeMessage();
            message.PrintInitialPrompt();

            string input = Console.ReadLine();
            if(input == "yes"){
                isPlayerReady = true;
            }
            
            return isPlayerReady;
        }

    }    

} 
