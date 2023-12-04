using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    internal class ScratchCardEngine
    {
        private IEnumerable<string> _lines;
        private List<ScratchCard> _cards = new List<ScratchCard>();

        public ScratchCardEngine(IEnumerable<string> lines)
        {
            _lines = lines;
        }

        public int ProcessValues()
        {
            foreach (var line in _lines)
            {
                var gameSplit = line.Split(':');
                Int32.TryParse(string.Concat(gameSplit.First().Where(char.IsDigit)), out int id);
                var card = new ScratchCard{ Id = id };

                var scoringNums = gameSplit.Last().Split('|').First().Trim().Split(' ').ToList();
                    scoringNums.RemoveAll(x => x.Trim().Length == 0);
                var scratchedNums = gameSplit.Last().Split('|').Last().Trim().Split(' ').ToList();
                    scratchedNums.RemoveAll(x => x.Trim().Length == 0);

                card.ScoringNums = scoringNums.Select(x => Int32.Parse(x)).ToList();
                card.ScratchedNums = scratchedNums.Select(x => Int32.Parse(x)).ToList();

                _cards.Add(card);
            }

            return _cards.Sum(x => x.Score);
        }
    }

    internal class ScratchCard
    {
        public int Id;
        public List<int> ScoringNums = new List<int>();
        public List<int> ScratchedNums = new List<int>();

        public int Score
        {
            get
            {
                return GetScore();
            }
        }

        private int GetScore()
        {
            int timesScored = 0;
            foreach (int scoringNum in ScoringNums)
            {
                if (ScratchedNums.Contains(scoringNum)) timesScored++;
            }

            var res = timesScored > 0 ? 1 : 0;
            for (int i = 1; i < timesScored; i++)
            {
                res = res * 2;
            }
            return res;
        }
    }
}
