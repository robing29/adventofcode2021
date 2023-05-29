using Microsoft.VisualBasic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using static System.Net.Mime.MediaTypeNames;

///<summary>Data Input</summary>
///
var input = File.ReadAllLines(@"..\..\..\..\inputs\day8.txt").ToList();
//var input = File.ReadAllLines(@"..\..\..\..\inputs\day8sample.txt").ToList();

//input = input.Select(x => x.Split(" | ").Last()).ToList();


int uniqueDigits = 0;
foreach (var item in input)
{
    var itemArray = item.Split(" ").ToList();
    uniqueDigits += itemArray.Select(x => x).Where(x => x.Length == 2 || x.Length == 3 || x.Length == 4 || x.Length == 7).Count();
}

Console.WriteLine(uniqueDigits);



///<summary>Part 2</summary>
///
long puzzleOutputZahl = 0;
foreach (var zeile in input)
{
    var puzzleInput = zeile.Split(" | ").First();
    var puzzleOutput = zeile.Split(" | ").Last().Split(" ").ToList();

    //Sorting of values
    for (int i = 0; i < puzzleOutput.Count; i++)
    {
        var test = puzzleOutput[i].ToCharArray();
        Array.Sort(test);
        puzzleOutput[i] = new string(test);
    }

    //Sorting of values
    var puzzleDigits = puzzleInput.Split(" ").ToList();
    for (int i = 0; i < puzzleDigits.Count; i++)
    {
        var chararray = puzzleDigits[i].ToCharArray();
        Array.Sort(chararray);
        puzzleDigits[i] = new string(chararray);
    }
    //var chararray = puzzleDigits.Select(x => x.ToCharArray());
    List<string> decodierteZahlen = new List<string>();
    for (int i = 0; i < 10; i++)
    {
        decodierteZahlen.Add("");
    }

    //Decode unique values
    decodierteZahlen[8] = puzzleDigits.Select(x => x).Where(x => x.Length == 7).First();
    decodierteZahlen[7] = puzzleDigits.Select(x => x).Where(x => x.Length == 3).First();
    decodierteZahlen[4] = puzzleDigits.Select(x => x).Where(x => x.Length == 4).First();
    decodierteZahlen[1] = puzzleDigits.Select(x => x).Where(x => x.Length == 2).First();
    puzzleDigits.Remove(decodierteZahlen[8]);
    puzzleDigits.Remove(decodierteZahlen[7]);
    puzzleDigits.Remove(decodierteZahlen[4]);
    puzzleDigits.Remove(decodierteZahlen[1]);

    //Extract identifiers
    string dddd = String.Empty;
    string c_oder_f = decodierteZahlen[1];
    string b_oder_d = String.Concat(decodierteZahlen[4].Except(decodierteZahlen[1]));

    //Extract codes with length of 5 or 6
    List<string> fuenferlaenge = puzzleDigits.Select(x => x).Where(x => x.Length == 5).ToList();
    List<string> sechserlaenge = puzzleDigits.Select(x => x).Where(x => x.Length == 6).ToList();

    //identify dddd
    if (fuenferlaenge.All(x => x.Contains(b_oder_d[0]))){
        dddd = b_oder_d[0].ToString();
    }
    else
    {
        dddd = b_oder_d[1].ToString();
    }



    decodierteZahlen[3] = fuenferlaenge.Select(x => x).Where(x => x.Contains(decodierteZahlen[1][0]) && x.Contains(decodierteZahlen[1][1]) ).First();
    fuenferlaenge.Remove(decodierteZahlen[3]);
    decodierteZahlen[5] = fuenferlaenge.Select(x => x).Where(x => x.Contains(b_oder_d[0]) && x.Contains(b_oder_d[1])).First();
    fuenferlaenge.Remove(decodierteZahlen[5]);
    decodierteZahlen[2] = fuenferlaenge[0];
    fuenferlaenge.Remove(decodierteZahlen[2]);



    decodierteZahlen[9] = sechserlaenge.Select(x => x).Where(x => x.Contains(decodierteZahlen[4][0]) && x.Contains(decodierteZahlen[4][1]) && x.Contains(decodierteZahlen[4][2]) && x.Contains(decodierteZahlen[4][3])).First();
    sechserlaenge.Remove(decodierteZahlen[9]);
    decodierteZahlen[0] = sechserlaenge.Select(x => x).Where(x => x.Contains(dddd) == false).First();
    sechserlaenge.Remove(decodierteZahlen[0]);
    decodierteZahlen[6] = sechserlaenge[0];

    string outputValueString = "";
    List<int> outputValue = new List<int>();
    foreach (var item in puzzleOutput)
    {
        outputValue.Add(decodierteZahlen.IndexOf(item));
        //outputValueString = outputValueString.Insert(outputValueString.Length, outputValue.ToString());
    }
    foreach (var item in outputValue)
    {
        outputValueString += item.ToString();
    }
    puzzleOutputZahl += int.Parse(outputValueString);

    //  0:      1:      2:      3:      4:
    // aaaa    ....    aaaa    aaaa    ....
    //b    c  .    c  .    c  .    c  b    c
    //b    c  .    c  .    c  .    c  b    c
    // ....    ....    dddd    dddd    dddd
    //e    f  .    f  e    .  .    f  .    f
    //e    f  .    f  e    .  .    f  .    f
    // gggg    ....    gggg    gggg    ....


    //  5:      6:      7:      8:      9:
    // aaaa    aaaa    aaaa    aaaa    aaaa
    //b    .  b    .  .    c  b    c  b    c
    //b    .  b    .  .    c  b    c  b    c
    // dddd    dddd    ....    dddd    dddd
    //.    f  e    f  .    f  e    f  .    f
    //.    f  e    f  .    f  e    f  .    f
    // gggg    gggg    ....    gggg    gggg

    //unique values: eins = 2, vier = 4, sieben = 3, acht = 7
    //5er= zwei, drei, fünf
    //6er= null, sechs, neun
}

Console.WriteLine(puzzleOutputZahl);



