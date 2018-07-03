using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Numerics;

/*
    n! means n × (n − 1) × ... × 3 × 2 × 1

    For example, 10! = 10 × 9 × ... × 3 × 2 × 1 = 3628800,
    and the sum of the digits in the number 10! is 3 + 6 + 2 + 8 + 8 + 0 + 0 = 27.

    Find the sum of the digits in the number 100!
*/

namespace Project_Euler_20
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = Stopwatch.StartNew();

            BigInteger num = Factorial(100);
            Console.WriteLine(SumOfDigits(num));

            Console.WriteLine(watch.ElapsedMilliseconds + "ms");
            Console.ReadKey();
        }


        private static BigInteger Factorial(int num)
        {
            BigInteger product = 1;
            for (int i = 1; i <= num; i++)
            {
                product *= i;
            }
            return product;
        }

        private static BigInteger SumOfDigits(BigInteger num)
        {
            BigInteger sum = 0;
            while (num > 0)
            {
                sum += num % 10;
                num /= 10;
            }
            return sum;
        }
    }
}
