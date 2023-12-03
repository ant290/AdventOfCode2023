using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    internal class GamesController
    {
        private IEnumerable<string> _lines;
        private List<Game> _games = new List<Game>();
        public GamesController(IEnumerable<string> lines)
        {
            _lines = lines;
        }

        public List<Game> FilterGames(int red, int green, int blue)
        {
            var filteredGames = _games.Where(x => x.MinRed <= red && x.MinGreen <= green && x.MinBlue <= blue);
            return filteredGames.ToList();
        }

        public void ProcessLines()
        {
            foreach (var line in _lines)
            {
                var gameParts = line.Split(':');
                Int32.TryParse(gameParts[0].Split(' ')[1], out int gameId);

                var game = new Game
                {
                    Id = gameId
                };

                foreach (var gameSet in gameParts[1].Split(';'))
                {
                    var set = ProcessSet(gameSet);

                    game.Sets.Add(set);
                }

                game.CalculateMins();

                _games.Add(game);
            }
        }

        private Set ProcessSet(string gameSet)
        {
            var results = new List<Result>();

            var colourParts = gameSet.Split(',');
            foreach (var colourPart in colourParts)
            {
                var result = new Result
                {
                    Quantity = Convert.ToInt32(string.Concat(colourPart.Where(char.IsDigit))),
                    Colour = string.Concat(colourPart.Where(char.IsLetter)).Trim()
                };

                results.Add(result);
            }

            var set = new Set
            {
                Results = results
            };
            return set;
        }
    }

    internal class Game
    {
        public int Id;
        public List<Set> Sets = new List<Set>();

        public int MinRed;
        public int MinGreen;
        public int MinBlue;

        public void CalculateMins()
        {
            int reds = 0, blues = 0, greens = 0;

            foreach(var set in Sets)
            {
                foreach(var res in set.Results)
                {
                    switch (res.Colour)
                    {
                        case "red":
                            reds += res.Quantity;
                            break;
                        case "blue":
                            blues += res.Quantity;
                            break;
                        case "green":
                            greens += res.Quantity;
                            break;
                    }
                }
            }

            MinRed = reds; MinGreen = greens; MinBlue = blues;
        }
    }

    internal class Set
    {
        public List<Result> Results = new List<Result>();
    }

    internal class Result
    {
        public int Quantity;
        public string Colour;
    }
}
