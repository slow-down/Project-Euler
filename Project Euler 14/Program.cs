using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;

/*
    The following iterative sequence is defined for the set of positive integers:

    n → n/2 (n is even)
    n → 3n + 1 (n is odd)

    Using the rule above and starting with 13, we generate the following sequence:
    13 → 40 → 20 → 10 → 5 → 16 → 8 → 4 → 2 → 1

    It can be seen that this sequence (starting at 13 and finishing at 1) contains 10 terms. Although it has not been proved yet (Collatz Problem), it is thought that all starting numbers finish at 1.

    Which starting number, under one million, produces the longest chain?

    NOTE: Once the chain starts the terms are allowed to go above one million.
 */

namespace Project_Euler_14
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = Stopwatch.StartNew();

            long longestChain = 0;
            long index = 0;
            Parallel.For(1, 1000000, (i) =>
            {
                long tmp = Collatz(i);
                if (tmp > longestChain)
                {
                    longestChain = tmp;
                    index = i;
                }
            });

            Console.WriteLine("Index: " + index);
            Console.WriteLine("Chain of " + longestChain);

            Console.WriteLine($"Dauer: {watch.ElapsedMilliseconds}ms");
            Console.ReadKey();
        }

        private static long Collatz(long num)
        {
            long i = 1;
            while (num != 1)
            {
                if (num % 2 == 0)
                {
                    num = num / 2;
                }
                else
                {
                    num = (3 * num) + 1;
                }
                i++;
            }
            return i;
        }

    }
}
