using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Euler_35
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = Stopwatch.StartNew();

            int count = 0;

            for (int i = 2; i < 1000000; i++)
            {
                var nums = RotatedNumbers(i.ToString());

                bool isCircular = true;

                foreach (var item in nums)
                {
                    if (!IsPrime(Convert.ToInt32(item)))
                    {
                        isCircular = false;
                        break;
                    }
                }

                if (isCircular)
                {
                    count++;
                    Console.WriteLine(i);
                }

            }

            Console.WriteLine($"Count of circular primes: {count}");
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

        private static string RotateNumber(string nr)
        {
            char leftNum = nr[0];
            nr = nr.Remove(0, 1);
            nr += leftNum;
            return nr;
        }

        private static string[] RotatedNumbers(string num)
        {
            int count = num.ToString().Length;
            string[] nums = new string[count];
            nums[0] = num;

            string rotated = num;
            for (int i = 1; i < count; i++)
            {
                nums[i] = RotateNumber(rotated);
                rotated = nums[i];
            }

            return nums;
        }
    }
}
