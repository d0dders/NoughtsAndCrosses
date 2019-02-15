using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoughtsAndCrosses
{
    class Program
    {
        static string[] board = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };

        static void Main(string[] args)
        {

            int turnCount = 1;
            while(true)
            {

                //Draw gameboard
                DrawBoard(board);
                //Get Players move
                if (turnCount % 2 == 0)
                {
                    Console.WriteLine("Player 2 - O");
                    Console.WriteLine("Type the number of the square you want to take:");
                    string Move = Console.ReadLine();
                    if (IsMoveValid(Move))
                    {
                        SubmitMove(Move, "O");
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
                    string Move = Console.ReadLine();
                    if (IsMoveValid(Move))
                    {
                        SubmitMove(Move, "X");
                        turnCount++;
                    }
                    else
                    {
                        Console.WriteLine("That square is already taken!");

                    }
                }




                //Check for end of game
                if (board[0] == board[1] && board[1] == board[2] ||
                    board[3] == board[4] && board[4] == board[5] ||
                    board[6] == board[7] && board[7] == board[8] ||
                    board[0] == board[3] && board[3] == board[6] ||
                    board[1] == board[4] && board[4] == board[7] ||
                    board[2] == board[5] && board[5] == board[8] ||
                    board[0] == board[4] && board[4] == board[8] ||
                    board[2] == board[4] && board[4] == board[6])
                {
                    DrawBoard(board);
                    Console.WriteLine("YOU WON!!!! Press ENTER to quit");
                    Console.Read();
                    break;
                }
                //Check for draw
                else if(turnCount > 9)
                {
                    DrawBoard(board);
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

        static bool IsMoveValid(String Move)
        {
            int place = int.Parse(Move);
            return board[place - 1] != "X" && board[place - 1] != "O";
        }

        static void SubmitMove(String Move, string Player)
        {
            int place = int.Parse(Move);
            board[int.Parse(Move) - 1] = Player;
        }
    }
}
