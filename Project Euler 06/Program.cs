using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

/* 
    The sum of the squares of the first ten natural numbers is,
    1² + 2² + ... + 10² = 385

    The square of the sum of the first ten natural numbers is,
    (1 + 2 + ... + 10)² = 55² = 3025

    Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025 − 385 = 2640.

    Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.

    Answer = 25164150
 */

namespace Project_Euler_06
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = Stopwatch.StartNew();

            Console.WriteLine(SquareOfSum(100) - SumOfSquare(100));

            Console.WriteLine(watch.ElapsedMilliseconds + "ms");
            Console.ReadKey();
        }

        private static double SumOfSquare(int max)
        {
            double sum = 0;
            for (int i = 1; i <= max; i++)
            {
                sum += Math.Pow(i, 2);
            }
            return sum;
        }

        private static double SquareOfSum(int max)
        {
            int sum = 0;
            for (int i = 1; i <= max; i++)
            {
                sum += i;
            }
            return Math.Pow(sum, 2);
        }
    }
}
