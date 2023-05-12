public class day7
{
    private static void Main(string[] args)
    {
        var input = File.ReadAllText(@"..\..\..\..\inputs\day7.txt");
        //string input = "16,1,2,0,4,2,7,1,2,14";

        var intArray = input.Split(",").Select(int.Parse).ToList();
        intArray.Sort();


        int median;
        if (intArray.Count % 2 != 0)
        {
            median = intArray[intArray.Count/2];
        } else
        {
            median = (intArray[intArray.Count/2]+intArray[(intArray.Count/2)-1])/2;
        }

        float average = 0;
        intArray.ForEach(i => average += i);
        average = average / intArray.Count;
        int iAverage = (int)Math.Round(average);

        //Part1
        int sumOfFuel = 0;
        intArray.ForEach(i => Console.WriteLine(i));
        intArray.ForEach(x => sumOfFuel += (Math.Abs(median - x)));
        
        //Part2
        long sumOfFuelPart2 = 0;
        var test = intArray.GroupBy(x => x);
        float weightedAverage = 0;
        float weightSum = 0;
        foreach ( var group in test) { 
            float weight = (float)group.Count()/intArray.Count;
            int key = group.Key;
            weightedAverage += weight * (Math.Abs(iAverage - key));
            weightSum += weight;
        }

        List<long> values = new List<long>();
        
        //intArray.ForEach(x => sumOfFuelPart2 += getFuel(Math.Abs((int)weightedAverage - x)));
        for (int i = -20; i <= 20; i++)
        {
            intArray.ForEach(x => sumOfFuelPart2 += getFuel(Math.Abs((iAverage+i) - x)));
            Console.WriteLine("sumOfFuel = " + sumOfFuelPart2 + " bei average = " + iAverage + "und i = " + i);
            values.Add(sumOfFuelPart2);
            sumOfFuelPart2 = 0;
        }

        Console.WriteLine("Best value = " + values.Min());
        


        //Solution print
        //Console.WriteLine($"Median: {median}, sumOfFuelpart1: {sumOfFuel}, average: {average}, iAverage: {iAverage}, sumOfFuelPart2: {sumOfFuelPart2}, weightedAverage: {weightedAverage}");

        //94862126 is not the answer
    }

    public static long getFuel(int stepsToTake)
    {
        long fuelForJourney = 0;
        if (stepsToTake > 0)
        {
            for (int stepstaken = 1; stepstaken <= stepsToTake; stepstaken++)
            {
                fuelForJourney += stepstaken;
            }
        }
        
        return fuelForJourney;
    }
}