using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

/*
    A perfect number is a number for which the sum of its proper divisors is exactly equal to the number. 
    For example, the sum of the proper divisors of 28 would be 1 + 2 + 4 + 7 + 14 = 28, which means that 28 is a perfect number.

    A number n is called deficient if the sum of its proper divisors is less than n and it is called abundant if this sum exceeds n.

    As 12 is the smallest abundant number, 1 + 2 + 3 + 4 + 6 = 16, the smallest number that can be written as the sum of two abundant numbers is 24. 
    By mathematical analysis, it can be shown that all integers greater than 28123 can be written as the sum of two abundant numbers. However, 
    this upper limit cannot be reduced any further by analysis even though it is known that the greatest number that cannot be expressed as the sum of two abundant numbers is less than this limit.

    Find the sum of all the positive integers which cannot be written as the sum of two abundant numbers.
*/

namespace Project_Euler_23
{
    class Program
    {
        private static List<int> cache = new List<int>();

        static void Main(string[] args)
        {
            Stopwatch watch = Stopwatch.StartNew();

            // fill cache
            for (int i = 1; i <= 10000; i++)
            {
                if (IsAbundant(i))
                {
                    cache.Add(i);
                }
            }
            Console.WriteLine("Finished filling the cache.");
            Console.WriteLine(watch.ElapsedMilliseconds + "ms");

            int sum = 0;
            for (int i = 1; i <= 10000; i++)
            {
                if (i % 100 == 0) Console.WriteLine("[i]={0,5} [Sum]={1}",i, sum);

                if (!IsSumOfTwoAbnundantNums(i))
                {
                    sum += i;
                }

            }

            Console.WriteLine(sum);
            Console.WriteLine(watch.ElapsedMilliseconds + "ms");
            Console.ReadKey();
        }

        private static bool IsSumOfTwoAbnundantNums(int num)
        {
            for (int outer = 0; outer < cache.Count; outer++)
            {
                for (int inner = outer; inner < cache.Count; inner++)
                {
                    if (cache[outer] + cache[inner] == num)
                    {
                        return true;
                    }
                    if (cache[outer] + cache[inner] > num)
                    {
                        break;
                    }
                }
            }
            return false;
        }

        private static bool IsAbundant(int num)
        {
            int[] divisors = GetDivisors(num);
            int sum = GetSumOfDivisors(divisors);

            return sum > num;
        }

        private static int[] GetDivisors(int num)
        {
            List<int> divisors = new List<int>();
            for (int i = 1; i < num; i++)
            {
                if (num % i == 0)
                {
                    divisors.Add(i);
                }
            }
            return divisors.ToArray();
        }

        private static int GetSumOfDivisors(int[] divisors)
        {
            int sum = 0;
            foreach (int divisor in divisors)
            {
                sum += divisor;
            }
            return sum;
        }
    }
}
