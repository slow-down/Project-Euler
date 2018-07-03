using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

/*
    Starting in the top left corner of a 2×2 grid, and only being able to move to the right and down, there are exactly 6 routes to the bottom right corner.

    How many such routes are there through a 20×20 grid?
 */

namespace Project_Euler_15
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = Stopwatch.StartNew();

            Console.WriteLine(FindRoutes(2, 2));

            Console.WriteLine(watch.ElapsedMilliseconds + "ms");
            Console.ReadKey();
        }

        private static int FindRoutes(int gridX, int gridY)
        {
            return 1;
        }
    }
}
