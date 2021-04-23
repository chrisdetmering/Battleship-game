using System;
using System.Collections.Generic;


namespace Battle_Ship_Game
{
    public class BattleShipGame
    {
        
        public SpotStatus[,] gameBoard = new SpotStatus[10, 10]; // 10x10 grid
        Player player = new Player();
        Message message = new Message();

        List<int> numbers = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        int Attemps = 10;
        int ShipHits = 5;

        bool isMissShot = true;
        //bool isCheckedShot = false;

        bool isShipSunk = false;

        public bool InitializeGame(){

            // Set the board, place the ship
            InitializeBoardGame();
            placeBattleShip();

            // Print the board game
            printBoardGame();
            
            return true;
        }

        public void GameLoop(bool isGameActive)
        {

             while(isGameActive)
            {
                // Ask Player for a Shot
                bool isValidShot = GetValidShot();
               
   
                if(isValidShot)
                {
                    printBoardGame(isValidShot);
                    if(Attemps == 0 || ShipHits == 0)
                    {
                        // GameOver or we wont!!
                        if(ShipHits == 0 && Attemps >= 0)
                        {
                            isGameActive = false;
                            isShipSunk = true;
                        }
                        isGameActive = false;
                    }
                }
                
                message.PrintAttemptsAndHits(Attemps, ShipHits);

                if(isShipSunk)
                {
                    message.PrintGameWon();
                    return;
                }

                if(Attemps == 0)
                {
                    message.PrintGameOver();
                    return;
                }
            }
        }

      

        public bool GetValidShot()
        {
            bool isInBounds = false; 
            bool isUniqueShot = false;
            bool isCheckedShot = false; 
        

            while(true)
            {
                message.PrintValidNumberRanges();
                int xCoordinate = player.GetCoordinate('x');
                int yCoordinate = player.GetCoordinate('y');
                isInBounds = player.IsShotInBounds(xCoordinate, yCoordinate);
                isUniqueShot = CheckUniqueShot(xCoordinate, yCoordinate);
                isCheckedShot = CheckShotOnBoard(xCoordinate, yCoordinate);

                if (isUniqueShot && isInBounds && isCheckedShot)
                {
                    break;
                } else
                {
                    message.PrintInvalidShot();
                }

            }

            return true;
        }





        public bool CheckShotOnBoard(int X, int Y)
        {
       

            if(gameBoard[X, Y] == SpotStatus.Ship)
            {
                // We are shotting on the ship
                // We have to count 5 - 1 = on the ship
                ShipHits = ShipHits - 1;
                // For the attemps 10 - 1
                isMissShot = false;
                Attemps = Attemps - 1;
                gameBoard[X, Y] = SpotStatus.Hit;
            } else if (gameBoard[X, Y] == SpotStatus.Empty)
            {
                // For the attemps 10 - 1 = water
                Attemps = Attemps - 1;
                gameBoard[X, Y] = SpotStatus.Miss;
                isMissShot = true;
            }
            return true;
        }

        public void InitializeBoardGame()
        {
            foreach (var CoordX in numbers)
            {
                foreach (var CoordY in numbers)
                {
                    gameBoard[CoordX, CoordY] = SpotStatus.Empty;
                }
            }
        }


        public void placeBattleShip()
        {
            // Place randomly a 5 length battleship
            Random random = new Random();
            int direction = random.Next(0,2) % 2;
            // int dimension = 10;

            if( direction == 0 )
            {
                // Horizontilly
                // For Coord_X we got from 0 - to (10-5) = 5
                int CoordX = random.Next(0, 5);  // left side of the ship + 5 spots
                // For Coord_Y we got the full range, and a constant for the ship
                int CoordY = random.Next(0, 10);

                for (var i = CoordX; i <= CoordX + 4; i++)
                {
                    for(var j = CoordY; j <= CoordY; j ++)
                    {
                        gameBoard[i, j] = SpotStatus.Ship;
                    }
                }
            } else            
            {
                // Vertically
                // For Coord_X we got the full range, and a constant for the ship
                int CoordX = random.Next(0, 10);
                // For Coord_Y we got from 0 - to (10-5) = 5
                int CoordY = random.Next(0, 5);  // left side of the ship + 5 spots               

                for (var i = CoordX; i <= CoordX; i++)
                {
                    for(var j = CoordY; j <= CoordY + 4; j ++)
                    {
                        gameBoard[i, j] = SpotStatus.Ship;
                    }
                }
            }
        }

       


        public void printBoardGame(bool isValidShot = false)
        {
            message.PrintWelcomeMessage();
           
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.White;

            string gridLine = "";
            string secondLine = "---";
            
            gridLine = "";
            foreach (var CoordY in numbers)
            {
                gridLine = (CoordY + 1) + ") ";
                foreach (var CoordX in numbers)
                {
                   // Print the board
                   if(gameBoard[CoordX, CoordY] == SpotStatus.Empty){
                       gridLine = gridLine + "  ~  ";
                   }
                   if(gameBoard[CoordX, CoordY] == SpotStatus.Ship){
                    //    gridLine = gridLine + " [B] "; // uncomment this line to see the boat
                        gridLine = gridLine + "  ~  ";   // comment this line to see the boat
                   }
                   if(gameBoard[CoordX, CoordY] == SpotStatus.Miss){
                       gridLine = gridLine + "  O  ";
                   }
                   if(gameBoard[CoordX, CoordY] == SpotStatus.Hit){
                       gridLine = gridLine + "  X  ";
                   }
                
                   if(CoordX == 9)
                   {
                       Console.WriteLine("                                                     ");
                   }
                   
                }
                Console.WriteLine(gridLine);
            } 

            gridLine = "";
            // Print 1-10 for columns
            foreach (var CoordY in numbers){
                gridLine = gridLine + "    " + (CoordY + 1);
                secondLine = secondLine + "-----";
            }
            Console.WriteLine(secondLine);
            Console.WriteLine(gridLine);  
            Console.WriteLine(secondLine);

            if(isValidShot)
            {
                message.PrintShotResult(isMissShot);
            }

            Console.ResetColor();         
        }

        public bool CheckUniqueShot(int X, int Y)
        {
            bool isUniqueShot = true;

            foreach (var CoordX in numbers)
            {
                foreach (var CoordY in numbers)
                {
                    if(gameBoard[X,Y] == SpotStatus.Hit ||
                    gameBoard[X,Y] == SpotStatus.Miss)
                    {
                        isUniqueShot = false;
                    }
                }
            }

            return isUniqueShot;
        }
    }
}