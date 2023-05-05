// See https://aka.ms/new-console-template for more information
//List<int> numbers = new List<int> { 8, 2, 6, 4, 9, 1, 5, 3, 7 };

//var groupedNumbers = numbers.GroupBy(n => n % 2 == 0 ? "Even" : "Odd");

//Console.WriteLine(groupedNumbers);

using linq_uebungen;
using System.Threading.Tasks.Dataflow;

bool isPrime(int number)
{
    if (number <= 1) return false;
    if (number == 2) return true;
    if (number % 2 == 0) return false;

    var boundary = (int)Math.Floor(Math.Sqrt(number));

    for (int i = 3; i <= boundary; i += 2)
    {
        if (number % i == 0)
        {
            return false;
        }
    }
    return true;
}

List<int> numbers = new List<int> { 1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20 };

var primeNumbers = numbers.Where(x => isPrime(x) == true).ToList();

primeNumbers.ForEach(x => Console.WriteLine(x));

List<string> fruits = new List<string> { "apple", "banana", "orange", "grape", "strawberry", "pineapple" };

var bigFruits = fruits.Where(x => x.Length >= 6).Select(x => x.ToUpper()).ToList();

bigFruits.ForEach(x => Console.WriteLine(x));

List<Student> students = new List<Student>
{
    new Student {Name = "Alice", Age = 23 },
    new Student {Name = "Bob", Age = 25 },
    new Student {Name = "Charlie", Age = 23 },
    new Student {Name = "David", Age = 28 },
    new Student {Name = "Eva", Age = 25 }
};

var groups = students.GroupBy(s => s.Age);

foreach (var group in groups)
{
    Console.WriteLine($"{ group.Key} Count: {group.Count()}");
    Console.WriteLine($"Students: {string.Join(", ", group.Select(s => s.Name))}");
    Console.WriteLine();
}
