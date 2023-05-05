using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

///<summary>Data Input</summary>
///
var input = File.ReadAllLines(@"..\..\..\..\inputs\day5.txt").ToList();
List<string> inputPart2 = new List<string>(input);
//File.ReadAllLines(@"..\..\..\..\inputs\day4.txt").ToList();
List<int[]> punkteViererpacksListe = new List<int[]>();
List<int[]> punktePaareListe = new List<int[]>();

///<summary>Part 1</summary>
///
foreach (string zeile in input)
{
    var zeileWerte = zeile.Split(" -> ");
    var zeileErsteKoordinaten = zeileWerte[0].Split(",");
    int x1 = int.Parse(zeileErsteKoordinaten[0]);
    int y1 = int.Parse(zeileErsteKoordinaten[1]);
    var zeileZweiteKoordinaten = zeileWerte[1].Split(",");
    int x2 = int.Parse(zeileZweiteKoordinaten[0]);
    int y2 = int.Parse(zeileZweiteKoordinaten[1]);

    if (x1 == x2 || y1 == y2)
    {
        int[] punktePaare = { x1, y1,x2,y2};
        punkteViererpacksListe.Add(punktePaare);
    }
}

foreach (var vierPunkteWerte in punkteViererpacksListe)
{
    //x1 = 10, y1= 50, x2 = 10, y2 = 30
    //x1 = 30, y1=10, x2 = 50, y2= 10
    if (vierPunkteWerte[0] == vierPunkteWerte[2]) //x-Werte gleich
    {
        if (vierPunkteWerte[1] >= vierPunkteWerte[3]) //erster Y-Wert größer als der zweite
        {
            for (int i = vierPunkteWerte[3]; i <= vierPunkteWerte[1]; i++)
            {
                int[] punktePaar = { vierPunkteWerte[0], i };
                punktePaareListe.Add(punktePaar);
            }
        }
        else
        {
            for (int i = vierPunkteWerte[1]; i <= vierPunkteWerte[3]; i++)
            {
                int[] punktePaar = { vierPunkteWerte[0], i };
                punktePaareListe.Add(punktePaar);
            }
        }
        
    } else if (vierPunkteWerte[1] == vierPunkteWerte[3]) //Y-Werte gleich
    {
        if (vierPunkteWerte[0] >= vierPunkteWerte[2]) //erster Y-Wert größer als der zweite
        {
            for (int i = vierPunkteWerte[2]; i <= vierPunkteWerte[0]; i++)
            {
                int[] punktePaar = { i, vierPunkteWerte[1] };
                punktePaareListe.Add(punktePaar);
            }
        }
        else
        {
            for (int i = vierPunkteWerte[0]; i <= vierPunkteWerte[2]; i++)
            {
                int[] punktePaar = { i, vierPunkteWerte[1] };
                punktePaareListe.Add(punktePaar);
            }
        }
    }
}

int numberOfDuplicateGroups = punktePaareListe
    .GroupBy(array => string.Join(",", array))
    .Count(group => group.Count() > 1);

Console.WriteLine(numberOfDuplicateGroups);

///<summary>Part 2</summary>
///

// punkteViererpacksListe = x1, y1, x2, y2;

List<int[]> punktePaareListePart2 = new List<int[]>();
int[] punktePaarPart2 = new int[2];
foreach (var intArray in punkteViererpacksListe)
{
    int maxX = Math.Max(intArray[0], intArray[2]); //max X-Value
    int minX = Math.Min(intArray[0], intArray[2]); //min X-Value
    int maxY = Math.Max(intArray[1], intArray[3]); //max Y-Value
    int minY = Math.Min(intArray[1], intArray[3]); //min Y-Value

    if (intArray[0] == minX && intArray[1] == minY)
    {
        for (int i = intArray[0]; i <= intArray[2]; i++)
        for (int k = intArray[1]; k <= intArray[3]; k++)
            {
                punktePaarPart2[0] = i;
                punktePaarPart2[1] = k;
                punktePaareListePart2.Add(punktePaarPart2);
            }

    }
    if (intArray[0] == minX && intArray[1] == maxY)
    {
        for (int i = intArray[0]; i <= intArray[2]; i++)
        for (int k = intArray[1]; k >= intArray[3]; k--)
            {
                punktePaarPart2[0] = i;
                punktePaarPart2[1] = k;
                punktePaareListePart2.Add(punktePaarPart2);
            }
    }
    if (intArray[0] == maxX && intArray[1] == maxY)
    {
        for (int i = intArray[0]; i >= intArray[2]; i--)
            for (int k = intArray[1]; k >= intArray[3]; k--)
            {
                punktePaarPart2[0] = i;
                punktePaarPart2[1] = k;
                punktePaareListePart2.Add(punktePaarPart2);
            }
    }
    if (intArray[0] == maxX && intArray[1] == minY)
    {
        for (int i = intArray[0]; i >= intArray[2]; i--)
            for (int k = intArray[1]; k <= intArray[3]; k++)
            {
                punktePaarPart2[0] = i;
                punktePaarPart2[1] = k;
                punktePaareListePart2.Add(punktePaarPart2);
            }
    }
    foreach (var item in punktePaareListePart2)
    {
        Console.WriteLine($"{string.Join(",", item)}");
    }
}

