using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Euler_34
{
    class Program
    {
        static void Main(string[] args)
        {
            DigitFactorials(10000000);

            Console.ReadKey();
        }

        private static void DigitFactorials(int max)
        {
            int bigSum = 0;
            for (int i = 10; i <= max; i++)
            {
                int sum = 0;
                int num = i;

                while (num > 0)
                {
                    int rest = num % 10;
                    sum += Factorial(rest);
                    num /= 10;
                }
                if (sum == i)
                {
                    bigSum += sum;
                }
            }
            Console.WriteLine($"Sum: {bigSum}");
        }

        private static int Factorial(int n)
        {
            if (n == 0) return 1;
            return Factorial(n - 1) * n;
        }
    }
}
