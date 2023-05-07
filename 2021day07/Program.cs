internal class Program
{
    private static void Main(string[] args)
    {
        //var input = File.ReadAllText(@"..\..\..\..\inputs\day6.txt");
        string input = "16,1,2,0,4,2,7,1,2";

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

        intArray.ForEach(i => Console.WriteLine(i));
        
        Console.WriteLine(median);
        Console.WriteLine("Hello, World!");
    }
}