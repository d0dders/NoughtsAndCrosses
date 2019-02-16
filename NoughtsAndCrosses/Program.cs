using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoughtsAndCrosses
{
    class Program
    {
        static char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        static void Main(string[] args)
        {
            Console.WriteLine("How would you like to play?");
            Console.WriteLine("---------------------------");
            Console.WriteLine("1. Against the computer");
            Console.WriteLine("2. Against a friend");
            int numberOfPlayers = int.Parse(Console.ReadLine());

            Console.Clear();

            char playerTurn;

            int turnCount = 1;
            while (true)
            {


                //Draw gameboard
                DrawBoard(board);
                //Get Players move
                if (turnCount % 2 == 1)
                {
                    playerTurn = 'X';
                }
                else
                {
                    playerTurn = 'O';
                }
                string Move;
                if (playerTurn == 'O' && numberOfPlayers == 1)
                {
                    //generateCPUMove
                    Move = GenerateMove();
                }
                else
                {
                    Console.WriteLine("Player {0}", playerTurn);
                    Console.WriteLine("Type the number of the square you want to take:");
                        Move = Console.ReadLine();
                }
                                                          
                if (IsMoveValid(Move))
                {
                    Console.Clear();
                    SubmitMove(Move, playerTurn);
                    turnCount++;
                }
                else
                {
                    Console.WriteLine("That was an invalid move");

                }
                
                
                



                //Check for end of game
                if (IsWinner())
                {
                    DrawBoard(board);
                    //TODO - currenty this displays if the computer wins as well.
                    if (playerTurn == 'O' && numberOfPlayers == 1)
                    {
                        Console.WriteLine("You were beaten! Press ENTER to quit");
                    }
                    else
                    {
                        Console.WriteLine("YOU WON!!!! Press ENTER to quit");
                    }
                    Console.Read();
                    break;
                }
                //Check for draw
                else if (turnCount > 9)
                {
                    DrawBoard(board);
                    Console.WriteLine("It was a draw! Press ENTER to quit");
                    Console.ReadLine();
                    break;
                }

            }

        }

        private static string GenerateMove()
        {
            Random random = new Random();
            String move = "";
            while (true)
            {
                move = random.Next(1, 9).ToString();
                if (IsMoveValid(move))
                {
                    return move;
                }
            }

        }

        static void DrawBoard(char[] places)
        {
            Console.WriteLine();
            Console.WriteLine($"  {places[0]} | {places[1]} | {places[2]} ");
            Console.WriteLine(" ---|---|---");
            Console.WriteLine($"  {places[3]} | {places[4]} | {places[5]} ");
            Console.WriteLine(" ---|---|---");
            Console.WriteLine($"  {places[6]} | {places[7]} | {places[8]} ");
            Console.WriteLine();
        }

        static bool IsWinner()
        {
            return (board[0] == board[1] && board[1] == board[2] ||
                    board[3] == board[4] && board[4] == board[5] ||
                    board[6] == board[7] && board[7] == board[8] ||
                    board[0] == board[3] && board[3] == board[6] ||
                    board[1] == board[4] && board[4] == board[7] ||
                    board[2] == board[5] && board[5] == board[8] ||
                    board[0] == board[4] && board[4] == board[8] ||
                    board[2] == board[4] && board[4] == board[6]);
        }


        static bool IsMoveValid(String Move)
        {
            bool isValid = false;
            if (int.TryParse(Move, out int place))
            {
                if (place >= 1 && place <= 9)
                {
                    isValid = board[place - 1] != 'X' && board[place - 1] != 'O';
                }
            }
           
            return isValid;
            
            
        }

        static void SubmitMove(String Move, char Player)
        {
            int place = int.Parse(Move);
            board[int.Parse(Move) - 1] = Player;
        }
    }
}
