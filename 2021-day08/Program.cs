using Microsoft.VisualBasic;
using System.Security.Cryptography.X509Certificates;

///<summary>Data Input</summary>
///
//var input = File.ReadAllLines(@"..\..\..\..\inputs\day8.txt").ToList();
var input = File.ReadAllLines(@"..\..\..\..\inputs\day8sample.txt").ToList();

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

foreach (var zeile in input)
{
    var puzzleInput = zeile.Split(" | ").First();
    var puzzleOutput = zeile.Split(" | ").Last();

    var puzzleDigits = puzzleInput.Split(" ").ToList();

    //Gemeinsamkeiten zwischen 2er und 3er finden
    //Gemeinsamkeiten zwischen allen unique values finden
    //Die Resultate dieser Detektivarbeit auf die fuenfer anwenden -> .contains(gefundenerBuchstabe/gefundeneBuchstaben)
    //Vergleich von Length = 4 und Length = 2 -> mittlerer und linksoberer Strich
    string obererStrich1 = puzzleDigits.Select(x => x).Where(x => x.Length == 2 || x.Length == 3).First();
    string obererStrich2 = puzzleDigits.Select(x => x).Where(x => x.Length == 2 || x.Length == 3).Last();
    var buchstabeFuerOberenStrich = obererStrich2.Except(obererStrich1).ToArray();// muss in beide Richtungen passieren
    string buchstabeFuerOberenStrichString = new string(buchstabeFuerOberenStrich);


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

    //Schnittmenge der 6er: a, b, f, g
    //Enthalten in jeweils zwei 6ern, aber in einem nicht: d, c, e

    //5er: Enthalten in zwei, aber nicht in einem = c
    //5er: Enthalten in einem, aber nicht in den anderen zwei = e

    //7 - 6 = dddd
    //4 - 1 = (bei erkanntem dddd) -> b
    //Der 5er mit dem b -> fünf
    //5-1 = c
    //6er mit c -> neun - Der andere 6er -> sechs
    //3-2 = aaaa
    //

    

    Console.WriteLine(buchstabeFuerOberenStrich);
    //foreach (var buchstabe in puzzleDigits)
    //{
    //    if (buchstabe.Length == 2 || buchstabe.Length == 3)
    //    {

    //    }
    //}


}



