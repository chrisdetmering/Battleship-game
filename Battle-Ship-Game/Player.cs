using System;

namespace Battle_Ship_Game
{
    public class Player
    {


        public int GetCoordinate(char coordinate)
        {
            
            Message.PrintAskForCordinate(coordinate);

            string input = Console.ReadLine();
            int coord;

            coord = Int32.Parse(input);

            return coord - 1; 
        }


        public bool IsShotInBounds(int X, int Y)
        {
            bool isValidShot = false;
            if( (X < 10 && X >= 0) &&
                (Y < 10 && Y >= 0) )
            {
                isValidShot = true;
            }
            
            return isValidShot;
        }

    }
}