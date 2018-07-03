using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Euler_37
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = Stopwatch.StartNew();

            int sum = 0;
            for (int i = 10; i < 750000; i++)
            {
                var rightToLeft = CutNumbersFromRightToLeft(i);
                bool allPrimes = true;
                foreach (var item in rightToLeft)
                {
                    if (!IsPrime(item))
                    {
                        allPrimes = false;
                        break;
                    }
                }

                if (allPrimes)
                {
                    var leftToRight = CutNumbersFromLeftToRight(i);
                    foreach (var item in leftToRight)
                    {
                        if (!IsPrime(item))
                        {
                            allPrimes = false;
                            break;
                        }
                    }
                }

                if (allPrimes)
                {
                    sum += i;
                    Console.WriteLine(i);
                }

            }

            Console.WriteLine($"Sum: {sum}");
            Console.WriteLine($"Time: {watch.ElapsedMilliseconds}ms");
            Console.ReadKey();
        }

        private static bool IsPrime(int num)
        {
            if (num < 2) return false;

            for (int i = 2; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0) return false;
            }

            return true;
        }

        private static int[] CutNumbersFromRightToLeft(int num)
        {
            int count = num.ToString().Length;
            int[] nums = new int[count];

            int i = 0;
            do
            {
                nums[i++] = num;
                num /= 10;
            } while (num > 0);

            return nums;
        }

        private static int[] CutNumbersFromLeftToRight(int num)
        {
            int count = num.ToString().Length;
            int[] nums = new int[count];

            string nr = num.ToString();
            for (int i = 0; i < count; i++)
            {
                nums[i] = Convert.ToInt32(nr.Substring(i, count - i));
            }

            return nums;
        }
    }
}
