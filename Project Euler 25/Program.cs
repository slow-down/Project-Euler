using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using flo = BigFloat;

namespace Project_Euler_25
{
    class Program
    {
        static void Main(string[] args)
        {
            Fib(3);
            Console.ReadKey();
        }


        private static void Fib(int max)
        {
            flo a = 0;
            flo b = 1;
            int length = 0;

            flo index = 1;

            while (length < max)
            {
                flo temp = a;
                a = b;
                b = temp + b;
                length = b.ToString().Length;
                Console.WriteLine($"length: [{length}] index: [{index++}] {b}");
            }

        }
    }
}
