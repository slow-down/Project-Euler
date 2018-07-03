using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;

/*
    Let d(n) be defined as the sum of proper divisors of n (numbers less than n which divide evenly into n).
    If d(a) = b and d(b) = a, where a ≠ b, then a and b are an amicable pair and each of a and b are called amicable numbers.
    b = d(a) and a = d(b)
    For example, the proper divisors of 220 are 1, 2, 4, 5, 10, 11, 20, 22, 44, 55 and 110; therefore d(220) = 284. The proper divisors of 284 are 1, 2, 4, 71 and 142; so d(284) = 220.

    Evaluate the sum of all the amicable numbers under 10000.
*/

namespace Project_Euler_21
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = Stopwatch.StartNew();
            bool[] cache = new bool[100000];

            int sum = 0;
            for (int i = 1; i < 10000; i++)
            {
                if (cache[i]) continue;
                int b = d(i);
                if (b == i) continue;

                int a = d(b);
                if (a == i)
                {
                    sum += a;
                    sum += b;
                }
                cache[i] = true;
                cache[b] = true;
            }
            Console.WriteLine(sum);
            Console.WriteLine(watch.ElapsedMilliseconds + "ms");
            Console.ReadKey();
        }

        private static int d(int num)
        {
            int sum = 0;
            for (int i = 1; i <= num / 2; i++)
            {
                if (num % i == 0)
                {
                    sum += i;
                }
            }
            return sum;
        }
    }
}
