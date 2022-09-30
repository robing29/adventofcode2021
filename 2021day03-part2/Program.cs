using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace _2021day03_part1
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[] sInputFile = File.ReadAllLines("C:\\Users\\rgude\\Desktop\\adventofcode\\day03\\input.txt"); Laptop
            string[] sInputFile = File.ReadAllLines(C:\Users\guder\Source\Repos\robing29\adventofcode2021\inputs\day3.txt)
            string[] sGammaOutput = new string[sInputFile[0].Length];
            string[] sEpsilonOutput = new string[sInputFile[0].Length];
            string sGammaFinal;
            string sEpsilonFinal;

            for (int i = 0; i < 12; i++)
            {
                int iCounter1 = 0;
                int iCounter0 = 0;
                foreach (string s in sInputFile)
                {
                    if (s[i] == '1')
                    {
                        iCounter1++;
                    }
                    else
                    {
                        iCounter0++;
                    }
                }
                Console.WriteLine("iCounter1 für i = " + i + " ist " + iCounter1);
                Console.WriteLine("iCounter0 für i = " + i + " ist " + iCounter0);
                if (iCounter1 >= iCounter0)
                {
                    Console.WriteLine("Die " + i + ". Stelle von vorne bei sGammaOutput ist 1");
                    Console.WriteLine("Die " + i + ". Stelle von vorne bei sEpsilonOutput ist 0");
                    sGammaOutput[i] = "1";
                    sEpsilonOutput[i] = "0";
                }
                else
                {
                    Console.WriteLine("Die " + i + ". Stelle von vorne bei sGammaOutput ist 0");
                    Console.WriteLine("Die " + i + ". Stelle von vorne bei sEpsilonOutput ist 1");
                    sGammaOutput[i] = "0";
                    sEpsilonOutput[i] = "1";
                }


            }
            sGammaFinal = string.Join(null, sGammaOutput);
            sEpsilonFinal = string.Join(null, sEpsilonOutput);
            Console.WriteLine("sGammaFinal = " + sGammaFinal);
            Console.WriteLine("sEpsilonFinal = " + sEpsilonFinal);

            long iGamma = Convert.ToInt64(sGammaFinal, 2);
            long iEpsilon = Convert.ToInt64(sEpsilonFinal, 2);
            Console.WriteLine("iGamma = " + iGamma + " und iEpsilon = " + iEpsilon);
            Console.WriteLine("Power Current = " + iGamma * iEpsilon);
        }
    }
}
