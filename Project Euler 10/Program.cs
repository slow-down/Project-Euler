using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Threading;

/* 
    The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.

    Find the sum of all the primes below two million.
 * 
 * 142913828922
4711ms
 */

namespace Project_Euler_10
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = Stopwatch.StartNew();

            Console.WriteLine(SumOfPrimes(2000000));

            Console.WriteLine(watch.ElapsedMilliseconds + "ms");
            Console.ReadKey();
        }

        private static Int64 SumOfPrimes(int max)
        {
            Int64 sum = 0;
            for (int i = 2; i < max; i++)
            {
                if (IsPrime(i))
                {
                    sum += i;
                }
            }
            return sum;
        }

        //private static bool IsPrime(int num)
        //{
        //    for (int i = 2; i < num; i++)
        //    {
        //        if (num % i == 0)
        //        {
        //            return false;
        //        }
        //    }
        //    return true;
        //}

        private static bool IsPrime(int number)
        {
            if (number == 1) return false;
            if (number == 2) return true;

            for (int i = 2; i <= Math.Ceiling(Math.Sqrt(number)); ++i)
            {
                if (number % i == 0) return false;
            }

            return true;

        }
    }
}
