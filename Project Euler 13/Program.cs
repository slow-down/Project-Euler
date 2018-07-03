using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.IO;
using System.Diagnostics;

/*  
     Work out the first ten digits of the sum of the following one-hundred 50-digit numbers.
 */
namespace Project_Euler_13
{
    class Program
    {
        private static BigInteger[] nums = new BigInteger[100];

        static void Main(string[] args)
        {
            Stopwatch watch = Stopwatch.StartNew();

            ReadNums();
            Console.WriteLine(SumOfNums());

            Console.WriteLine($"Dauer: {watch.ElapsedMilliseconds}ms");
            Console.ReadKey();
        }

        private static BigInteger SumOfNums()
        {
            BigInteger sum = 0;
            foreach (var num in nums)
            {
                sum += num;
            }
            return sum;
        }

        private static void ReadNums()
        {
            StreamReader reader = new StreamReader("nums.txt");
            int i = 0;
            string line = "";
            while ((line = reader.ReadLine()) != null)
            {
                nums[i] = BigInteger.Parse(line);
                i++;
            }
        }
    }
}
