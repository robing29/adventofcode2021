using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace _2021day011
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] datainput = File.ReadAllLines("C:\\Users\\rgude\\Desktop\\adventofcode\\day1\\input.txt");
            int[] ints = Array.ConvertAll(datainput, int.Parse);

            int countvar = 0;
            int increaseCounter = 0;

            foreach (int r in ints)
            {
                if (ints[countvar] == ints[0])
                {
                    Console.WriteLine(r + " first value");
                }
                else if (ints[countvar] > ints[countvar - 1])
                {
                    Console.WriteLine(r + " increasing");
                    increaseCounter++;
                }
                else
                {
                    Console.WriteLine(r + " decreasing");
                }
                countvar++;
            }
            Console.WriteLine("The answer to the puzzle is " + increaseCounter);

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }
    }
}
