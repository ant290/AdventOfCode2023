// See https://aka.ms/new-console-template for more information

using Day4;

Console.WriteLine("Hello, World!");

var lines = File.ReadLines(@"Data.txt");

var engine = new ScratchCardEngine(lines);

var res = engine.ProcessValues();

Console.WriteLine(res);

Console.Read();