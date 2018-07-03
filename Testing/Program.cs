using Shared;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = Stopwatch.StartNew();
            var primes = Maul.GetAllPrimes(30);
            Console.WriteLine($"{watch.ElapsedMilliseconds}ms");

            foreach (var num in primes)
            {
                Console.WriteLine(num);
            }

            Console.ReadKey();
        }
    }
}
