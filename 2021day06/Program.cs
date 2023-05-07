


using System.Diagnostics;

internal class Program
{
    private static void Main(string[] args)
    {

        var input = File.ReadAllText(@"..\..\..\..\inputs\day6.txt");
        //string input = "3,4,3,1,2";

        IEnumerable<long> initalState = input.Split(",").Select(long.Parse);

        long[] fishDatabase = new long[9];

        //FishDatabase = Amount of Fish that are in each state. State fishDatabase[0] means that the amount stored at that position have 0 days left before breeding..
        foreach (var item in initalState)
        {
            long i = item;
            fishDatabase[i]++;
        }

        //Day Simulator
        int afterDays = 256;
        for (int i = 0; i < afterDays; i++)
        {
            long readyToBirth = fishDatabase[0];
            for (int j = 0; j < 8; j++)
            {
                fishDatabase[j] = fishDatabase[j + 1];
            }
            fishDatabase[6] += readyToBirth;
            fishDatabase[8] = readyToBirth;
            Console.WriteLine($"Day{i + 1}: {fishDatabase.Sum()}");
        }
    }
}