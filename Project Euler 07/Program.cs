using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

/* 
    By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.

    What is the 10 001st prime number?

    Answer = 104743
 */

namespace Project_Euler_07
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = Stopwatch.StartNew();

            int index = 0;
            int i = 1;
            while (true)
            {
                if (index == 10001) break;
                if (IsPrime(++i))
                {
                    index++;
                }
            }

            Console.WriteLine($"Number: {i}");
            Console.WriteLine($"Dauer: {watch.ElapsedMilliseconds}ms");
            Console.ReadKey();
        }

        private static bool IsPrime(int num)
        {
            for (int i = 2; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0) return false;
            }
            return true;
        }
    }
}
