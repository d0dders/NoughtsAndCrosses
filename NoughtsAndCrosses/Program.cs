using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoughtsAndCrosses
{
    class Program
    {
        static void Main(string[] args)
        {

            //Ask for players name
            Console.WriteLine("What is your name?");
            string playerName = Console.ReadLine();
            Console.WriteLine("Hi " + playerName + ", you are crosses!");
            string[] places = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };

            int turnCount = 1;
            while(true)
            {

                //Draw gameboard
                DrawBoard(places);
                //Get Players move
                if (turnCount % 2 == 0)
                {
                    Console.WriteLine("Player 2 - O");
                    Console.WriteLine("Type the number of the square you want to take:");
                    int place = int.Parse(Console.ReadLine());
                    if (places[place - 1] != "X" && places[place - 1] != "O")
                    {
                        places[place - 1] = "O";
                        turnCount++;
                    }
                    else
                    {
                        Console.WriteLine("That square is already taken!");
                       
                    }
                } 
                else
                {
                    Console.WriteLine("Player 1 - X");
                    Console.WriteLine("Type the number of the square you want to take:");
                    int place = int.Parse(Console.ReadLine());
                    if (places[place - 1] != "X" && places[place - 1] != "O")
                    {
                        places[place - 1] = "X";
                        turnCount++;
                    }
                    else
                    {
                        Console.WriteLine("That square is already taken!");
                        
                    }
                }




                //Check for end of game
                if (places[0] == places[1] && places[1] == places[2] ||
                    places[3] == places[4] && places[4] == places[5] ||
                    places[6] == places[7] && places[7] == places[8] ||
                    places[0] == places[3] && places[3] == places[6] ||
                    places[1] == places[4] && places[4] == places[7] ||
                    places[2] == places[5] && places[5] == places[8] ||
                    places[0] == places[4] && places[4] == places[8] ||
                    places[2] == places[4] && places[4] == places[6])
                {
                    DrawBoard(places);
                    Console.WriteLine("YOU WON!!!! Press ENTER to quit");
                    Console.Read();
                    break;
                }
                //Check for draw
                else if(turnCount > 9)
                {
                    DrawBoard(places);
                    Console.WriteLine("It was a draw! Press ENTER to quit");
                    Console.ReadLine();
                    break;
                }

            }

        }

        static void DrawBoard(string[] places)
        {
            Console.WriteLine();
            Console.WriteLine($" {places[0]} | {places[1]} | {places[2]} ");
            Console.WriteLine("---|---|---");
            Console.WriteLine($" {places[3]} | {places[4]} | {places[5]} ");
            Console.WriteLine("---|---|---");
            Console.WriteLine($" {places[6]} | {places[7]} | {places[8]} ");
            Console.WriteLine();
        }
    }
}
