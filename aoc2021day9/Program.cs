using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;
///<summary>Data Input</summary>
///
internal class Program
{
    enum extremitiesProperties
    {
        obenLinks,
        obenMitte,
        obenRechts,
        untenLinks,
        untenMitte,
        untenRechts,
        links,
        rechts,
        normal
    }
    private static void Main(string[] args)
    {
        var input = File.ReadAllLines(@"..\..\..\..\inputs\day9.txt").ToList();

        ///<summary>Part 1</summary>
        ///
        List<List<Tuple<int, int>>> basinSizes = new List<List<Tuple<int, int>>>();
        long riskLevel = 0;
        for (int row = 0; row < input.Count(); row++)
        {
            for (int i = 0; i < input[row].Length; i++)
            {
                var test = checkValue(i, input[row], row, input, extremitiesCheck(i, input[row], row, input));
                if (test.Item1 == true)
                {
                    riskLevel += (test.Item2 + 1);
                    basinSizes.Add(getbasinSize(i, input[row], row, input, extremitiesCheck(i, input[row], row, input)).Distinct().ToList());
                }
            }
        }
        Console.WriteLine(riskLevel);
        basinSizes = basinSizes.OrderByDescending(x => x.Count()).ToList();
        Console.WriteLine(basinSizes[0].Count() * basinSizes[1].Count * basinSizes[2].Count + "Multipliziert zusammen");
        
        


        List<Tuple<int,int>> getbasinSize(int index, string s, int rowIndex, List<string> list, bool[] extremitiesProperties)
        {
            int basinSize = 0;
            List<Tuple<int, int>> listOfTuples = new List<Tuple<int, int>>();//first int = index, second int = rowIndex;
            //int basinSize returns 4 if all 4 values adjacent to the mid value are lower than 9

            //Parameter needed to tell the function to not check against the direction it came from

            bool isLeft = extremitiesProperties[0];
            bool isRight = extremitiesProperties[1];
            bool isTop = extremitiesProperties[2];
            bool isBottom = extremitiesProperties[3];
            bool searchinLeftDirection = false;
            bool searchinRightDirection = false;
            bool searchinTopDirection = false;
            bool searchinBottomDirection = false;
            bool[] search = { searchinLeftDirection, searchinRightDirection, searchinTopDirection, searchinBottomDirection };

            int midValue = int.Parse(s[index].ToString());
            listOfTuples.Add(Tuple.Create(index, rowIndex));
            if (!isLeft)
            {
                int leftValue = int.Parse(s[(index - 1)].ToString());
                if (leftValue < 9)
                {
                    //basinSize += 1;
                    //basinSize += getbasinSize(index - 1, s, rowIndex, input, extremitiesCheck(index - 1, s, rowIndex, input));
                    listOfTuples.Add(Tuple.Create(index-1, rowIndex));
                    var test = getbasinSize(index - 1, s, rowIndex, input, extremitiesCheck(index - 1, s, rowIndex, input));
                    test.ForEach(x => listOfTuples.Add(x));
                }
            }
            if (!isRight)
            {
                int rightValue = int.Parse(s[(index + 1)].ToString());
                if (rightValue < 9)
                {
                    //basinSize += 1;
                    //basinSize += getbasinSize(index + 1, s, rowIndex, input, extremitiesCheck(index + 1, s, rowIndex, input));
                    listOfTuples.Add(Tuple.Create(index+1, rowIndex));
                    var test = getbasinSize(index + 1, s, rowIndex, input, extremitiesCheck(index + 1, s, rowIndex, input));
                    test.ForEach(x => listOfTuples.Add(x));
                }
            }
            if (!isTop)
            {
                int topValue = int.Parse(list[(rowIndex - 1)][index].ToString());
                if (topValue < 9)
                {
                    //basinSize += 1;
                    //basinSize += getbasinSize(index, s, rowIndex-1, input, extremitiesCheck(index, s, rowIndex-1, input));
                    listOfTuples.Add(Tuple.Create(index, rowIndex-1));
                    var test = getbasinSize(index, s, rowIndex - 1, input, extremitiesCheck(index, s, rowIndex - 1, input));
                    test.ForEach(x => listOfTuples.Add(x));
                }
            }
            if (!isBottom)
            {
                int bottomValue = int.Parse(list[rowIndex + 1][index].ToString());
                if (bottomValue < 9)
                {
                    //basinSize += 1;
                    //basinSize += getbasinSize(index, s, rowIndex+1, input, extremitiesCheck(index, s, rowIndex+1, input));
                    listOfTuples.Add(Tuple.Create(index, rowIndex+1));
                    var test = getbasinSize(index, s, rowIndex + 1, input, extremitiesCheck(index, s, rowIndex + 1, input));
                    test.ForEach(x => listOfTuples.Add(x));
                }
            }
            return listOfTuples;
        }

        Tuple<bool, int> checkValue(int index, string s, int rowIndex, List<string> list, bool[] extremitiesProperties)
        {
            bool isLeft = extremitiesProperties[0];
            bool isRight = extremitiesProperties[1];
            bool isTop = extremitiesProperties[2];
            bool isBottom = extremitiesProperties[3];
            int midValue = int.Parse(s[index].ToString());
            List<int> compareValue = new List<int>();
            if (!isLeft)
            {
                int leftValue = int.Parse(s[(index-1)].ToString());
                compareValue.Add(leftValue);
            }
            if (!isRight)
            {
                int rightValue = int.Parse(s[(index+1)].ToString());
                compareValue.Add(rightValue);
            }
            if (!isTop)
            {
                int topValue = int.Parse(list[(rowIndex - 1)][index].ToString());
                compareValue.Add(topValue);
            }
            if (!isBottom)
            {
                int bottomValue = int.Parse(list[rowIndex + 1][index].ToString());
                compareValue.Add(bottomValue);
            }
            if(compareValue.All(x => x > midValue))
            {
                return new Tuple<bool, int>(true, midValue);
            } else
            {
                return new Tuple<bool, int>(false, 0);
            }

        }

        bool[] extremitiesCheck(int index, string s, int rowIndex, List<string> list)
        {
            bool isTopRow = false;
            bool isBottomRow = false;
            bool isLeft = false;
            bool isRight = false;
            if (rowIndex == 0)
            {
                isTopRow = true;
            }
            else if (rowIndex == list.Count()-1)
            {
                isBottomRow = true;
            }

            if (index == 0)
            {
                isLeft = true;
            }
            else if (index == (s.Length-1))
            {
                isRight = true;
            }
            bool[] bools = {isLeft, isRight, isTopRow, isBottomRow};
            return bools;

            //if(isRight&& isTopRow)
            //{
            //    return extremitiesProperties.obenRechts;
            //}
            //if(isLeft&& isTopRow)
            //{
            //    return extremitiesProperties.obenLinks;
            //}
            //if (isTopRow)
            //{
            //    return extremitiesProperties.obenMitte;
            //}
            //if (isBottomRow && isLeft)
            //{
            //    return extremitiesProperties.untenLinks;
            //}
            //if (isBottomRow && isRight)
            //{
            //    return extremitiesProperties.untenRechts;
            //}
            //if (isBottomRow)
            //{
            //    return extremitiesProperties.untenMitte;
            //}
            //if (isRight)
            //{
            //    return extremitiesProperties.rechts;
            //}
            //if (isLeft)
            //{
            //    return extremitiesProperties.links;
            //}
            //return extremitiesProperties.normal;
        }
    }
}

///<summary>Part 2</summary>
///

