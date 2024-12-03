// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var lines = File.ReadLines(@"Data.txt");
var firstList = new List<int>();
var lastList = new List<int>();

foreach (var line in lines)
{
    var parts = line.Split(' ');
    //Console.WriteLine(parts.First());
    //Console.WriteLine(parts.Last());

    firstList.Add(int.Parse(parts.First()));
    lastList.Add(int.Parse(parts.Last()));
}

//firstList.Sort();
//lastList.Sort();

//Console.WriteLine(firstList.Count);
//Console.WriteLine(lastList.Count);

//var distance = 0;

//for (int i = 0; i < firstList.Count; i++)
//{
//    distance += Math.Abs(firstList[i] - lastList[i]);
//}

//Console.WriteLine(distance);

var similarity = 0;

foreach (var i in firstList)
{
    var quantity = lastList.FindAll(x => x == i).Count();

    similarity += i * quantity;
}

Console.WriteLine(similarity);