// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var lines = File.ReadLines(@"Data.txt");
var sumOfCalibration = 0;

foreach (string line in lines)
{
    var numbers = string.Concat(line.Where(char.IsDigit));
    var firstNum = numbers[0];
    var lastNum = numbers[numbers.Length - 1];
    var twoDigits = $"{firstNum}{lastNum}";
    int.TryParse(twoDigits, out int bigNum);
    sumOfCalibration += bigNum;
}

Console.WriteLine($"result = {sumOfCalibration}");
Console.Read();