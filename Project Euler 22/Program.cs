using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

/*
    Using names.txt (right click and 'Save Link/Target As...'), a 46K text file containing over five-thousand first names, begin by sorting it into alphabetical order. 
    Then working out the alphabetical value for each name, multiply this value by its alphabetical position in the list to obtain a name score.

    For example, when the list is sorted into alphabetical order, COLIN, which is worth 3 + 15 + 12 + 9 + 14 = 53, is the 938th name in the list. So, COLIN would obtain a score of 938 × 53 = 49714.

    What is the total of all the name scores in the file?
 */

namespace Project_Euler_22
{
    class Program
    {
        private static string[] names;

        static void Main(string[] args)
        {
            Stopwatch watch = Stopwatch.StartNew();

            if (LoadNames())
            {
                Array.Sort(names);
                Int64 total = 0;

                for (int i = 0; i < names.Length; i++)
                {
                    total += (i + 1) * NameValue(names[i]);
                }

                Console.WriteLine("Score: " + total);
            }

            Console.WriteLine(watch.ElapsedMilliseconds + "ms");
            Console.ReadKey();
        }

        private static int NameValue(string name)
        {
            int sum = 0;
            foreach (var chr in name)
            {
                sum += CharValue(chr);
            }
            return sum;
        }

        private static int CharValue(char c)
        {
            return (int)c - 64;
        }

        private static bool LoadNames()
        {
            try
            {
                using (StreamReader reader = new StreamReader("names.txt"))
                {
                    string data = reader.ReadToEnd();
                    data = data.Replace("\"", "");
                    names = data.Split(',');
                    reader.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }
    }
}
