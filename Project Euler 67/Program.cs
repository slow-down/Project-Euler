using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace Project_Euler_67
{
    class Program
    {
        private const int rows = 100;
        private const int cols = 100;
        private static int[,] nums = new int[rows, cols];

        static void Main(string[] args)
        {
            Stopwatch watch = Stopwatch.StartNew();

            ReadData();
            Console.WriteLine(BottomTop());

            Console.WriteLine(watch.ElapsedMilliseconds + "ms");

            Console.ReadKey();
        }

        private static int BottomTop()
        {
            for (int row = rows - 2; row >= 0; row--)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    int left = nums[row + 1, col];
                    int right = nums[row + 1, col + 1];
                    if (left > right)
                    {
                        nums[row, col] += left;
                    }
                    else
                    {
                        nums[row, col] += right;
                    }
                }
            }
            return nums[0, 0];
        }

        private static void ReadData()
        {
            try
            {
                StreamReader reader = new StreamReader("data.txt");
                string line = "";
                int i = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] tmp = line.Split(' ');
                    for (int j = 0; j < tmp.Length; j++)
                    {
                        nums[i, j] = int.Parse(tmp[j]);
                    }
                    i++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
