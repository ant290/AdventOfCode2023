// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;

Console.WriteLine("Hello, World!");

var data = File.ReadAllText(@"Data.txt");

var matches = Regex.Matches(data, "(mul\\((\\d+)\\,(\\d+)\\))");

Console.WriteLine(matches.Count);

var total = 0;

foreach (Match match in matches)
{
    var x = match.Value;
    Console.WriteLine(x);

    x = x.Replace("mul(", "");
    x = x.Replace(")", "");

    var parts = x.Split(',');
    var res = int.Parse(parts[0]) * int.Parse(parts[1]);

    total += res;
}

Console.WriteLine(total);