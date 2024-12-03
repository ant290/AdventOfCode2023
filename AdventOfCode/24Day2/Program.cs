// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var lines = File.ReadLines(@"Data.txt");

var safeRep = 0;
var unsafeRep = 0;

foreach (var line in lines)
{
    var parts = line.Split(' ');

    int? lastpart = null;
    var increases = false;
    var decreases = false;
    var unsafeDifference = false;

    foreach (var part in parts)
    {
        var thisPart = int.Parse(part);
        if (lastpart == null)
        {
            lastpart = thisPart;
            continue;
        }

        if (lastpart == thisPart)
        {
            unsafeDifference = true;
        } 
        else if (lastpart > thisPart)
        {
            decreases = true;
            if (lastpart - thisPart > 3) unsafeDifference = true;
        }
        else if (lastpart < thisPart)
        {
            increases = true;
            if (thisPart - lastpart > 3) unsafeDifference = true;
        }

        lastpart = thisPart;
    }

    if (unsafeDifference || (increases && decreases))
    {
        unsafeRep++;
    }
    else
    {
        safeRep++;
    }
}

Console.WriteLine(safeRep);
