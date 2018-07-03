using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Project_Euler_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = Stopwatch.StartNew();

            UInt64 num = 600851475143;
            for (UInt64 i = 2; num > 1; i++)
            {
                while (num % i == 0)
                {
                    num /= i;
                    Console.WriteLine(i);
                }
            }


            Console.WriteLine("finish");
            Console.WriteLine($"Dauer: {watch.ElapsedMilliseconds}ms");

            Console.ReadKey();
        }

        private static bool IsPrime(UInt64 number)
        {
            for (UInt64 i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }

    }
}
