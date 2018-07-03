using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Project_Euler_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = Stopwatch.StartNew();

            int num1 = 0;
            int num2 = 1;
            int sum = 0;

            int num3 = num1 + num2;
            while (num3 < 4000000)
            {
                num3 = num1 + num2;
                num1 = num2;
                num2 = num3;

                if (num3 % 2 == 0)
                {
                    sum += num3;
                }

            }

            Console.WriteLine(sum);
            Console.WriteLine($"Dauer: {watch.ElapsedMilliseconds}ms");


            Console.ReadKey();
        }
    }
}
