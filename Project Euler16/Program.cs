using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Diagnostics;

/*
    2^15 = 32768 and the sum of its digits is 3 + 2 + 7 + 6 + 8 = 26.

    What is the sum of the digits of the number 2^1000?
 */

namespace Project_Euler16
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = Stopwatch.StartNew();

            BigInteger num = BigInteger.Pow(2, 1000);
            BigInteger sum = 0;

            Console.WriteLine("The Number is: " + num);
            while (num > 0)
            {
                sum += num % 10;
                num /= 10;
            }
            Console.WriteLine("The sum is: " + sum);

            Console.WriteLine(watch.ElapsedMilliseconds + "ms");
            Console.ReadKey();
        }

    }
}
