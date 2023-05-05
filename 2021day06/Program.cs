


using System.Diagnostics;

internal class Program
{
    private static void Main(string[] args)
    {
        var input = File.ReadAllText(@"..\..\..\..\inputs\day6.txt");
        //string input = "3,4,3,1,2";
        List<int> list = new List<int>();
        list = input.Split(",").ToList().Select(x => int.Parse(x)).ToList();

        List<Fish> fishInventory = new List<Fish>();
        List<FishStruct> fishStructs = new List<FishStruct>();
        foreach (int i in list)
        {
            //fishInventory.Add(new Fish(i));
            fishStructs.Add(new FishStruct(i));
        }

        List<Fish> newFish = new List<Fish>();
        List<FishStruct> newFishStructs = new List<FishStruct>();
        Stopwatch sw = new Stopwatch();
        int afterDays = 256;
        for (int i = 0; i < afterDays; i++)
        {
            sw.Start();
            for (int k = 0; k < fishStructs.Count; k++)
            {
                FishStruct fish = fishStructs[k];
                if (fish.DaysUntilReset == 0)
                {
                    newFishStructs.Add(fish.ResetAndBirth());
                    fish.DaysUntilReset = 6;
                    fishStructs[k] = fish;
                }
                else
                {
                    fish.DaysUntilReset--;
                    fishStructs[k] = fish;
                }
            }
            newFishStructs.ForEach(x => fishStructs.Add(x));
            newFishStructs.Clear();
            //newFish.ForEach(x => fishInventory.Add(x));
            //newFish.Clear();
            Console.WriteLine($"day{i + 1}-Dauer: {sw.Elapsed}");
        }

        //for (int i = 0; i < afterDays; i++)
        //{
        //    sw.Start();
        //    foreach (Fish fish in fishInventory)
        //    {
        //        if (fish.DaysUntilReset == 0)
        //        {
        //            newFish.Add(fish.ResetAndBirth());
        //        }
        //        else
        //        {
        //            fish.DaysUntilReset--;
        //        }
        //    }
        //    newFish.ForEach(x => fishInventory.Add(x));
        //    newFish.Clear();
        //    Console.WriteLine($"day{i+1}-Dauer: {sw.Elapsed}");
        //}
        //Dauer bei afterDays = 200 mit classes: 00:00:45.9082687
        //zweiter Benchmark: day200-Dauer: 00:00:46.6338716


        //Console.WriteLine(fishInventory.Count);
        //Console.WriteLine(fishStructs.Count);
        Console.WriteLine("done");
        Console.ReadLine();
    }
}

public struct FishStruct
{
    public FishStruct(int anfangsFisch)
    {
        DaysUntilReset = anfangsFisch;
    }

    public int DaysUntilReset { get; set; }

    public FishStruct ResetAndBirth()
    {
        return new FishStruct(8);
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