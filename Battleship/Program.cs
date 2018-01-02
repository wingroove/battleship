using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Program
    {
        static void Main(string[] args)
        {

            int ver = 0;
            int hor = 0;
            int boats = 5;
            Random r = new Random();
            int hBounds = 1;
            int vBounds = 1;

            //This makes a grid, or, an array of arrays
            char[,] grid = new char[8, 8];
            for (int i = 0; i < grid.GetLength(0); i++)
            {

                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    //single char are in '', strings are in "".
                    grid[i, j] = '0';
                }
            }

            char[,] answer_grid = new char[8, 8];
            for (int x = 0; x < answer_grid.GetLength(0); x++)
            {

                for (int y = 0; y < answer_grid.GetLength(1); y++)
                {
                    //single char are in '', strings are in "".
                    answer_grid[x, y] = '0';
                }
            }

            for (int populate = 0; populate <= 4; populate++)
            {

                int a = r.Next(0, 8);
                int b = r.Next(0, 8);

                answer_grid[a, b] = '1';

                if (a > 0 && answer_grid[a - 1, b] != '1')
                {
                    answer_grid[a - 1, b] = '2';
                }
                if (a < 7 && answer_grid[a + 1, b] != '1')
                {
                    answer_grid[a + 1, b] = '2';
                }
                if (b > 0 && answer_grid[a, b - 1] != '1')
                {
                    answer_grid[a, b - 1] = '2';
                }
                if (b < 7 && answer_grid[a, b + 1] != '1')
                {
                    answer_grid[a, b + 1] = '2';
                }
            }

            Console.WriteLine("Get ready to battle! There are 5 ships to find.");
            while(boats>0)
            {
                while (hBounds == 1)
                {
                    Console.WriteLine("Please enter your horizontal coordinate (1-8):");
                    hor = Convert.ToInt32(Console.ReadLine());
                    if (hor < 1 || hor > 8)
                    {
                        Console.WriteLine("Please only enter a number 1-8.");
                    }
                    if (hor >= 1 && hor <= 8)
                    {
                        hBounds = 2;
                    }
                }

                while (vBounds == 1)
                {
                    Console.WriteLine("Please enter your vertical coordinate (1-8):");
                    ver = Convert.ToInt32(Console.ReadLine());
                    if (ver < 1 || ver > 8)
                    {
                        Console.WriteLine("Please only enter a number 1-8.");
                    }
                    if (ver >= 1 && ver <= 8)
                    {
                        vBounds = 2;
                    }
                }
                //set where the ships are
                if (answer_grid[ver - 1, hor - 1]=='1') 
                {
                    grid[ver - 1, hor - 1] = '*';
                    Console.WriteLine("hit!");
                    boats = boats - 1;
                }
                else if(answer_grid[ver-1, hor-1]=='2')
                {
                    grid[ver - 1, hor - 1] = '%';
                    Console.WriteLine("near miss!");
                    
                }
                else
                {
                    grid[ver - 1, hor - 1] = 'x';
                    Console.WriteLine("miss!");

                }

                for (int i = 0; i < grid.GetLength(0); i++)
                {
                    for (int j = 0; j < grid.GetLength(1); j++)
                    {
                        Console.Write(grid[i, j]);
                    }
                    Console.WriteLine();
                }
                //Show answer grid
                Console.WriteLine();
                Console.WriteLine("ANSWER GRID");
                for (int i = 0; i < answer_grid.GetLength(0); i++)
                {
                    for (int j = 0; j < answer_grid.GetLength(1); j++)
                    {
                        Console.Write(answer_grid[i, j]);
                    }
                    Console.WriteLine();
                }
                vBounds = 1;
                hBounds = 1;
            }
            Console.WriteLine("You win!");

            Console.ReadLine();
        }
    }
}
