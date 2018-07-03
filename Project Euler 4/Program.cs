using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;

/*  
    A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.
    Find the largest palindrome made from the product of two 3-digit numbers.
 */
namespace Project_Euler_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = Stopwatch.StartNew();

            CalculatePalindrome();

            Console.WriteLine($"Dauer: {watch.ElapsedMilliseconds}ms");
            Console.ReadKey();
        }

        private static void CalculatePalindrome()
        {
            int tmp = 0;
            int max = -1;

            for (int i = 999; i >= 100; i--)
            {
                for (int j = 999; j >= 100; j--)
                {
                    tmp = i * j;
                    if (tmp < max) continue;

                    if (IsPalindrome(tmp))
                    {
                        max = tmp;
                        break;
                    }
                }
            }

            Console.WriteLine(max);

        }

        private static bool IsPalindrome(int num)
        {
            string palin = num.ToString();
            for (int i = 0; i < palin.Length / 2; i++)
            {
                if (palin[i] != palin[palin.Length - i - 1])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
