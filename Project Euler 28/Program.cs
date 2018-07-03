using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Project_Euler_28
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = Stopwatch.StartNew();

            Console.WriteLine(GetDiagonalSum(1001));

            Console.WriteLine(watch.ElapsedMilliseconds + "ms");
            Console.ReadKey();
        }

        private static Int64 GetDiagonalSum(int cols)
        {
            int num = 1;
            int incrementer = 2;

            Int64 sum = 1;
            for (int i = 0; i < cols/2; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    num += incrementer;
                    sum += num;
                }
                incrementer += 2;
            }

            return sum;
        }
    }
}
