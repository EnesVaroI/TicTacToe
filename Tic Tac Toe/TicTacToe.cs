using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    internal class TicTacToe
    {
        private int[,] thegrid = { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        
        private void setuser (String user_input)
        {
            int i = Convert.ToInt32(user_input.Substring(0, 1));
            int j = Convert.ToInt32(user_input.Substring(1, 1));
            thegrid[i, j] = 1;
        }

        public void getuser ()
        {
            Console.Write("Pick an empty spot (e.g 02 is 1st row, 3rd column):");
            while (true)
            {
                String user_input = Console.ReadLine();
                //invokes a method to check if the user input follows the correct format
                if (correctformat(user_input) != true)
                {
                    Console.Write("Please input a valid value (e.g 02 is 1st row, 3rd column):");
                    continue;
                }
                //invokes a method to check if the user input hasn't been picked before
                else if (takenvalue(user_input) != true)
                {
                    Console.WriteLine("This spot is already taken!");
                    Console.Write("Please pick an empty spot:");
                    continue;
                }
                else
                {
                    setuser(user_input);
                    break;
                }
            }
        }

        private bool correctformat (String user_input)
        {
            if (user_input.Length != 2) { return false; }

            else
            {
                int i = Convert.ToInt32(user_input.Substring(0, 1));
                int j = Convert.ToInt32(user_input.Substring(1, 1));
                if ((i == 0 || i == 1 || i == 2) && (j == 0 || j == 1 || j == 2))
                { return true; }
                else return false;
            }
        }

        private bool takenvalue (String user_input)
        {
            int i = Convert.ToInt32(user_input.Substring(0, 1));
            int j = Convert.ToInt32(user_input.Substring(1, 1));
            if (thegrid[i,j] == 0)
            { return true; }
            else return false;
        }

        public bool computerwin ()
        {
            for(int i = 0; i < 3; i++)
            {
                if (test(thegrid[i, 0], thegrid[i, 1], thegrid[i, 2], 2))
                {
                    thegrid[i, 0] = 2;
                    thegrid[i, 1] = 2;
                    thegrid[i, 2] = 2;
                    return true;
                }
            }

            for (int i = 0; i < 3; i++)
            {
                if (test(thegrid[0, i], thegrid[1, i], thegrid[2, i], 2))
                {
                    thegrid[0, i] = 2;
                    thegrid[1, i] = 2;
                    thegrid[2, i] = 2;
                    return true;
                }
            }

            for (int i = 0; i < 2; i++)
            {
                if (test(thegrid[0, 2 * i], thegrid[1, 1], thegrid[2, 2 * (1 - i)], 2))
                {
                    thegrid[0, 2 * i] = 2;
                    thegrid[1, 1] = 2;
                    thegrid[2, 2 * (1 - i)] = 2;
                    return true;
                }
            }

            return false;
        }

        public bool playerlose ()
        {
            for (int i = 0; i < 3; i++)
            {
                if (test(thegrid[i, 0], thegrid[i, 1], thegrid[i, 2], 1))
                {
                    if (thegrid[i, 0] == 0) thegrid[i, 0] = 2;
                    else if (thegrid[i, 1] == 0) thegrid[i, 1] = 2;
                    else if (thegrid[i, 2] == 0) thegrid[i, 2] = 2;
                    return true;
                }
            }

            for (int i = 0; i < 3; i++)
            {
                if (test(thegrid[0, i], thegrid[1, i], thegrid[2, i], 1))
                {
                    if (thegrid[0, i] == 0) thegrid[0, i] = 2;
                    else if (thegrid[1, i] == 0) thegrid[1, i] = 2;
                    else if (thegrid[2, i] == 0) thegrid[2, i] = 2;
                    return true;
                }
            }

            for (int i = 0; i < 2; i++)
            {
                if (test(thegrid[0, 2 * i], thegrid[1, 1], thegrid[2, 2 * (1 - i)], 1))
                {
                    if (thegrid[0, 2 * i] == 0) thegrid[0, 2 * i] = 2;
                    else if (thegrid[1, 1] == 0) thegrid[1, 1] = 2;
                    else if (thegrid[2, 2 * (1 - i)] == 0) thegrid[2, 2 * (1 - i)] = 2;
                    return true;
                }
            }

            return false;
        }

        private bool test(int n1, int n2, int n3, int x)
        {
            if (n1 == x && n2 == x && n3 == 0) { return true; }
            else if (n1 == x && n2 == 0 && n3 == x) { return true; }
            else if (n1 == 0 && n2 == x && n3 == x) { return true; }
            else return false;
        }

        public int randommove()
        {
            int emptyspots = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (thegrid[i, j] == 0) emptyspots++;
                }
            }

            Random random = new Random();
            int randomnumber = random.Next(0, emptyspots);

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (thegrid[i, j] == 0 && randomnumber == 0)
                    {
                        thegrid[i, j] = 2;
                        return 0;
                    }
                    else if (thegrid[i, j] == 0 && randomnumber != 0) randomnumber--;
                }
            }

            return 0;
        }

        public bool endgame(int player)
        {
            for (int i = 0; i < 3; i++)
            {
                if (thegrid[i, 0] == player && thegrid[i, 1] == player && thegrid[i, 2] == player)
                    return true;
            }

            for (int i = 0; i < 3; i++)
            {
                if (thegrid[0, i] == player && thegrid[1, i] == player && thegrid[2, i] == player)
                    return true;
            }

            for (int i = 0; i < 2; i++)
            {
                if (thegrid[0, 2 * i] == player && thegrid[1, 1] == player && thegrid[2, 2 * (1 - i)] == player)
                    return true;
            }

            return false;
        }

        public void printgrid ()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("-------------");
                Console.Write("| ");
                for (int j = 0; j < 3; j++)
                {
                    if (thegrid[i, j] == 0)
                         Console.Write(" " + " | ");
                    else if (thegrid[i, j] == 1)
                        Console.Write("X" + " | ");
                    else if (thegrid[i, j] == 2)
                        Console.Write("O" + " | ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("-------------");
        }
    }
}