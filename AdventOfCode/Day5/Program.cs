// See https://aka.ms/new-console-template for more information
using Day5;

Console.WriteLine("Hello, World!");

var lines = File.ReadLines(@"Data.txt");

var mapper = new GardenMapper(lines);

mapper.ProcessData();

var res = mapper.GetSeedLocations();

Console.WriteLine(res.OrderBy(x => x).First());

Console.ReadLine();