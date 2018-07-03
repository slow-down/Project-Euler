using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using flo = BigFloat;

namespace Project_Euler_55
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = Stopwatch.StartNew();

            // max iterations = 49
            // max n = 9999

            int amount = 0;

            for (int i = 10; i < 10000; i++)
            {
                bool palin = true;
                flo tmp = i;
                for (int j = 0; j < 50; j++)
                {
                    tmp += Reverse(tmp);
                    if (IsPalindrome(tmp))
                    {
                        palin = false;
                        break;
                    }
                }
                if (palin) amount++;
            }

            Console.WriteLine($"Amount: {amount}");
            Console.WriteLine($"Dauer: {watch.ElapsedMilliseconds}ms");
            Console.ReadKey();
        }

        private static flo Reverse(flo num)
        {
            string s = num.ToString();
            StringBuilder builder = new StringBuilder();
            for (int i = s.Length - 1; i >= 0; i--)
            {
                builder.Append(s[i]);
            }
            return flo.Parse(builder.ToString());
        }

        private static bool IsPalindrome(flo num)
        {
            string s = num.ToString();
            int max = s.Length / 2;

            for (int i = 0; i < max; i++)
            {
                if (s[i] != s[s.Length - 1 - i]) return false;
            }
            return true;
        }
    }
}
