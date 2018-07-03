using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

/* 

    2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.

    What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?

    Answer = 232792560
 */

namespace Project_Euler_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = Stopwatch.StartNew();

            int i = 2520;
            while (!IsMultiple(i)) { i += 2520; }

            Console.WriteLine(i);
            Console.WriteLine($"Dauer: {watch.ElapsedMilliseconds}ms");

            Console.ReadKey();
        }

        private static bool IsMultiple(int num)
        {
            for (int i = 2; i <= 20; i++)
            {
                if (num % i != 0) return false;
            }
            return true;
        }

    }


}
