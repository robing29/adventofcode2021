using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Diagnostics.Metrics;
using System.Data;
using Microsoft.VisualBasic;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;

namespace _2021day03_part1
{
    class Program
    {
        /// <summary>
        /// Messy Solution, copied part1 from https://www.youtube.com/watch?v=18gMli4Jr3A&t=57s, then fiddled around to get part2 correct
        /// </summary>
        /// <param name="args"></param>

        static void Main(string[] args)
        {
            List<int> numbers;
            List<List<List<int>>> boards = new();
            List<List<List<int>>> boards2 = new();

            var input = File.ReadAllLines(@"..\..\..\..\inputs\day4.txt").ToList();
            var numberOfBoards = (input.Count - 1) / 6;

            numbers = input[0].Split(",").Select(int.Parse).ToList();

            for (int i = 0; i < numberOfBoards; i++)
            {
                var board = new List<List<int>>();
                var board2 = new List<List<int>>();

                for (int row = 0; row < 5; row++)
                {
                    board.Add(input[2 + 6 * i + row].Split().Where(x => x.Trim() != "").Select(int.Parse).ToList());
                    board2.Add(input[2 + 6 * i + row].Split().Where(x => x.Trim() != "").Select(int.Parse).ToList());
                }

                boards.Add(board);
                boards2.Add(board2);
            }

            int bingo()
            {
                foreach (var number in numbers)
                {
                    foreach (var board in boards)
                    {
                        for (int i = 0; i < 5; i++)
                            for (int j = 0; j < 5; j++)
                            {
                                if (board[i][j] == number)
                                {
                                    board[i][j] = -1;
                                }
                            }
                    }

                    foreach (var board in boards)
                    {
                        for (var i = 0; i < 5; i++)
                        {
                            if (board[i].Sum() == -5 || board.Select(x => x[i]).Sum() == -5)
                                return board.SelectMany(x => x).Where(x => x != -1).Sum() * number;
                        }
                    }
                }

                return 0;
            }
            Console.WriteLine(bingo());


            List<int> winningBoardsWinningNumbers = new();
            
            void bingo2()
            {
                int winningNumber;
                foreach (var number in numbers)
                {
                    foreach (var board in boards2)
                    {
                        
                        for (int i = 0; i < 5; i++)
                            for (int j = 0; j < 5; j++)
                            {
                                if (board[i].Sum() != 0 || board.Select(x => x[i]).Sum() != 0)
                                {
                                    if (board[i][j] == number)
                                    {
                                        board[i][j] = -1;
                                    }
                                }
                                
                            }
                    }

                    foreach (var board in boards2)
                    {
                        for (var i = 0; i < 5; i++)
                        {
                            if (board[i].Sum() == -5 || board.Select(x => x[i]).Sum() == -5)
                            {
                                winningNumber = board.SelectMany(x => x).Where(x => x != -1).Sum() * number;
                                //board.SelectMany(x => x).Where(x => x == -1).ToList().ForEach(x => x = 0);
                                winningBoardsWinningNumbers.Add(winningNumber);
                                //board.ForEach(x => x[i] = 0);
                                for (int k = 0; k < 5; k++)
                                for (int j = 0; j < board[k].Count; j++)
                                {
                                    board[k][j] = 0;
                                }
                                //board.ForEach(x => x[i] = 0);
                                //board[i].ForEach(x => x = 0);
                                //board.ForEach(x => Console.WriteLine(x));
                            }
                        }
                        
                    }
                }
            }
            bingo2();
            Console.WriteLine(winningBoardsWinningNumbers.Last());

        }
    }
}
