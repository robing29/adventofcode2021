using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Diagnostics.Metrics;
using System.Data;

namespace _2021day03_part1
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[] sInputFile = File.ReadAllLines("C:\\Users\\rgude\\Desktop\\adventofcode\\day03\\input.txt"); Laptop
            //string[] sInputFile = File.ReadAllLines("C:\\Users\\guder\\Source\\Repos\\robing29\\adventofcode2021\\inputs\\day3.txt");
            
            //Initialisation

            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string sFile = System.IO.Path.Combine(sCurrentDirectory, @"..\..\..\..\inputs\day4.txt");
            string sFilePath = Path.GetFullPath(sFile);
            string[] sInputFile = File.ReadAllLines(sFilePath);
            List<string> AllNumbers = new List<string>();
            List<string> NumbersDrawn1 = new List<string>();
            List<string> BingoBoards = new List<string>();
            AllNumbers = File.ReadLines(sFilePath).ToList();
            NumbersDrawn1 = AllNumbers[0].Split(',').ToList();
            AllNumbers.RemoveAt(0);
            BingoBoards = AllNumbers;
            BingoBoards.RemoveAll(x => x == "");

            DataTable dBingoBoard = new DataTable();

            dBingoBoard.CaseSensitive = false;
            dBingoBoard
            
            //var FirstOccurence = AllNumbers.Find("\\n");
            foreach (string s in BingoBoards)
            {
                Console.WriteLine(s);
            }
           
        }
    }
}
