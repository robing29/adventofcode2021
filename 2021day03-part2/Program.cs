using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Diagnostics.Metrics;

namespace _2021day03_part1
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[] sInputFile = File.ReadAllLines("C:\\Users\\rgude\\Desktop\\adventofcode\\day03\\input.txt"); Laptop
            string[] sInputFile = File.ReadAllLines("C:\\Users\\guder\\Source\\Repos\\robing29\\adventofcode2021\\inputs\\day3.txt");
            //life support rating = oxygen generator rating * C02 scrubber rating
            //oxygen generator rating = immer der stärkere setzt sich durch
            //C02 scrubber rating = immer der schwächere setzt sich durch
            string[] sGammaOutput = new string[sInputFile[0].Length]; //mostCommon
            string[] sEpsilonOutput = new string[sInputFile[0].Length]; //leastCommon

            string sOxygen;
            string sC02;
            List<string> lInput = sInputFile.ToList<string>();
            List<string> lC02 = sInputFile.ToList<string>();

            int i = 0;
            while (lInput.Count != 1)
            {

                int iCounter1 = 0;
                int iCounter0 = 0;
                foreach (string s in lInput)
                {
                    if (s[i] == '1')
                    {
                        iCounter1++;
                    }
                    else
                    {
                        iCounter0++;
                    }
                } //Bits zählen

                if (iCounter1 >= iCounter0)
                {
                    lInput.RemoveAll(s => s[i] == '0');
                } //Remove from list
                else
                {
                    lInput.RemoveAll(s => s[i] == '1');
                } //Remove from list
                i++;
            }
            sOxygen = lInput.First();
            Console.WriteLine("Oxygen = " + sOxygen);

            int i2 = 0;
            while (lC02.Count != 1)
            {
                int iCounter1 = 0;
                int iCounter0 = 0;
                foreach (string s in lC02)
                {
                    if (s[i2] == '1')
                    {
                        iCounter1++;
                    }
                    else
                    {
                        iCounter0++;
                    }
                } //Bits zählen

                if (iCounter1 >= iCounter0)
                {
                    lC02.RemoveAll(s => s[i2] == '1');
                } //Remove from list
                else
                {
                    lC02.RemoveAll(s => s[i2] == '0');
                } //Remove from list
                i2++;
            }

            sC02 = lC02.First();
            Console.WriteLine("C02 = " + sC02);

            long longC02 = Convert.ToInt64(sC02, 2);
            long longOxygen = Convert.ToInt64(sOxygen, 2);

            Console.WriteLine("longC02 = " + longC02);
            Console.WriteLine("longOxygen = " + longOxygen);
            Console.WriteLine("Life Support Rating = " + longC02 * longOxygen);

            //https://www.youtube.com/watch?v=tmzpgfldSE4
        }
    }
}
