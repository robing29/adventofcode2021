


using System.Diagnostics;

internal class Program
{
    private static void Main(string[] args)
    {
        //var input = File.ReadAllText(@"..\..\..\..\inputs\day6.txt");
        string input = "3,4,3,1,2";
        List<int> list = new List<int>();
        list = input.Split(",").ToList().Select(x => int.Parse(x)).ToList();

        List<Fish> fishInventory = new List<Fish>();
        foreach (int i in list)
        {
            fishInventory.Add(new Fish(i));
        }

        List<Fish> newFish = new List<Fish>();
        Stopwatch sw = new Stopwatch();
        int afterDays = 256;
        for (int i = 0; i < afterDays; i++)
        {
            sw.Start();
            foreach (Fish fish in fishInventory)
            {
                if (fish.DaysUntilReset == 0)
                {
                    newFish.Add(fish.ResetAndBirth());
                }
                else
                {
                    fish.DaysUntilReset--;
                }
            }
            newFish.ForEach(x => fishInventory.Add(x));
            newFish.Clear();
            Console.WriteLine($"day{i}-Dauer: {sw.Elapsed}");
        }



        Console.WriteLine(fishInventory.Count);
        Console.WriteLine("done");
        Console.ReadLine();
    }
}



public class Fish
{
    public Fish()
    {
        DaysUntilReset = 8;
    }
    public Fish(int anfangsFisch)
    {
        DaysUntilReset = anfangsFisch;
    }
    public int DaysUntilReset { get; set; }


    public Fish ResetAndBirth()
    {
        DaysUntilReset = 6;
        return new Fish();
    }


}