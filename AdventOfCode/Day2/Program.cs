using Day2;

Console.WriteLine("Hello, World!");

var lines = File.ReadLines(@"Data.txt");

var processor = new GamesController(lines);
processor.ProcessLines();

var games = processor.FilterGames(12, 13, 14);

Console.WriteLine(games.Sum(x => x.Id));

Console.ReadKey();