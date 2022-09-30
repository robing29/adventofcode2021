using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace _2021day01
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
                if (ints[countvar] + ints[countvar-1] + ints[countvar-2] > ints[countvar-1] + ints[countvar-2] + ints[countvar-3])
                {
                    Console.WriteLine(r + " Dreier increased");
                    increaseCounter++;
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
