using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace _2021day02_part2
{
    class Program
    {
        static void Main(string[] args)
        {
            string filepath = "C:\\Users\\rgude\\Desktop\\adventofcode\\day02\\input.txt";
            string[] datainputString = File.ReadAllLines(filepath);
            //int[] datainputInt = Array.ConvertAll(datainputString, int.Parse); //Read inputs and parse into two arrays: datainputString and datainputInt

            int depth = 0;
            int horizontalPos = 0;
            int iAim = 0;


            foreach (string s in datainputString)
            {
                string anweisung = s.Substring(s.Length - 1); ;
                int anweisungInt = int.Parse(anweisung);
                
                if (s.StartsWith("forward"))
                {

                    horizontalPos = horizontalPos + anweisungInt;
                    depth += (anweisungInt * iAim);
                    Console.WriteLine(s + " vorwärts erkannt" + " horizontalPos = " + horizontalPos + " und depth = " + depth);
                }
                else if (s.StartsWith("up"))
                {
                    iAim -= anweisungInt;
                    Console.WriteLine(s + " aim adjusted by " + anweisungInt + " to " + iAim);
                }
                else if (s.StartsWith("down"))
                {
                    iAim += anweisungInt;
                    Console.WriteLine(s + " aim adjusted by " + anweisungInt + " to " + iAim);
                }

            }
            Console.WriteLine("Die Lösung des Puzzles ist " + depth * horizontalPos);


            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }
    }
}
