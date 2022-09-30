using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace _2021day01part2
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
                //if (ints[countvar - 1] == null || ints[countvar - 2] == null || ints[countvar - 3] == null || ints[countvar] == null)
                if (countvar <= 2)
                {
                    Console.WriteLine("countvar: " + countvar + " Keine vollständige Dreier-Reihe, r = " + r);
                    //index >= 0 && index < array.Length
                }
                else
                {
                    int a = ints[countvar] + ints[countvar - 1] + ints[countvar - 2];
                    int b = ints[countvar - 1] + ints[countvar - 2] + ints[countvar - 3];
                    if (a > b)
                    {
                        Console.WriteLine("countvar: " + countvar + " a: " + a + " b: " + b +  "increasing");
                        increaseCounter++;
                    }
                    else if (b > a)
                    {
                        Console.WriteLine("countvar: " + countvar + " a: " + a + " b: " + b + "decreasing");
                    }
                }

                //if (ints[countvar] == ints[0])
                //{
                //    Console.WriteLine(r + " first value");
                //}
                //else if (ints[countvar] > ints[countvar - 1])
                //{
                //    Console.WriteLine(r + " increasing");
                //    increaseCounter++;
                //}
                //else
                //{
                //    Console.WriteLine(r + " decreasing");
                //}
                countvar++;
            }
            Console.WriteLine("The answer to the puzzle is " + increaseCounter);

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }
    }
}
