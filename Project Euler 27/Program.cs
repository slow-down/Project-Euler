using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;


/*
    Euler discovered the remarkable quadratic formula:

        n²+n+41

    It turns out that the formula will produce 40 primes for the consecutive integer values 0≤n≤39. However, when 
    n=40,40²+40+41=40(40+1)+41 is divisible by 41, and certainly when n=41,41²+41+41 is clearly divisible by 41.

    The incredible formula n²−79n+1601 was discovered, which produces 80 primes for the consecutive values 0≤n≤79.
    The product of the coefficients, −79 and 1601, is −126479.

    Considering quadratics of the form:

        n²+an+b , where |a|<1000 and |b|≤1000

    where |n| is the modulus/absolute value of n
    e.g. |11|=11 and |−4|=4

    Find the product of the coefficients, a and b, for the quadratic expression that produces the maximum number of primes for consecutive values of n, starting with n=0. 
 */
namespace Project_Euler_27
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = Stopwatch.StartNew();

            QuadraticFormula();

            Console.WriteLine(watch.ElapsedMilliseconds + "ms");
            Console.ReadKey();
        }

        private static void QuadraticFormula()
        {
            int maxA = 0;
            int maxB = 0;
            int maxN = 0;
            for (int a = -1000; a < 1000; a++)
            {
                for (int b = -1000; b <= 1000; b++)
                {
                    if (a == -61 && b == 971)
                    {
                        int x = 2;
                    }
                    int n = MaxConsecutivePrimes(a, b);

                    if (n > maxN)
                    {
                        maxA = a;
                        maxB = b;
                        maxN = n;
                    }
                }
            }
            Console.WriteLine($"a = {maxA}");
            Console.WriteLine($"b = {maxB}");
            Console.WriteLine($"n = {maxN}");
            Console.WriteLine($"product = {maxA * maxB}");
            Console.WriteLine($"");
        }

        private static int MaxConsecutivePrimes(int a, int b)
        {
            int n = 0;

            while (true)
            {
                if (IsPrime(Math.Abs(n * n + a * n + b)))
                {
                    n++;
                }
                else
                {
                    return n;
                }
            }
        }

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
