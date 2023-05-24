using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Tic Tac Toe!");
            Console.WriteLine("Press any key to proceed.");
            Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine("-------------------------");
            while (true)
            {
                TicTacToe game = new TicTacToe();
                int total_turn = 0;
                int whose_turn = 0;
                while (total_turn < 5)
                {
                    total_turn++;

                    whose_turn = 1;
                    game.printgrid();
                    // invoke a method to get user input
                    game.getuser();
                    // invoking the end game method
                    if (game.endgame(whose_turn))
                    {
                        game.printgrid();
                        Console.WriteLine("You won!");
                        Console.WriteLine("Total turn: " + total_turn);
                        break;
                    }

                    if (total_turn == 5)
                    {
                        game.printgrid();
                        Console.WriteLine("It's a draw.");
                        Console.WriteLine("Total turn: " + total_turn);
                        break;
                    }

                    whose_turn = 2;
                    // invoke a method for the computer to input a value
                    // invoking the winning algorithm
                    if (game.computerwin()) ;
                    // invoking the making user lose algorithm
                    else if (game.playerlose()) ;
                    // invoking the random method
                    else game.randommove();
                    // invoking the end game method
                    if (game.endgame(whose_turn))
                    {
                        game.printgrid();
                        Console.WriteLine("Computer won.");
                        Console.WriteLine("Total turn: " + total_turn);
                        break;
                    }
                }

                Console.WriteLine("-------------------------");
                Console.WriteLine("Do you want to play again? (Y/N)");
                if (Console.ReadKey().Key != ConsoleKey.Y)
                {
                    Console.WriteLine();
                    Console.WriteLine("Thanks for playing!");
                    break;
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
