namespace Day6
{
    internal class RaceEngine
    {
        private List<Race> Races;

        public RaceEngine(bool isSample)
        {
            if (isSample)
            {
                Races = new List<Race>()
                {
                    new Race()
                    {
                        Time = 71530,
                        Distance = 940200
                    }
                };
            }
            else
            {
                Races = new List<Race>()
                {
                    new Race()
                    {
                        Time = 38677673,
                        Distance = 234102711571236
                    }
                };
            }
        }

        public int ProcessRaces()
        {
            var waysToWin = new List<int>();
            foreach (Race race in Races)
            {
                waysToWin.Add(race.GetNumberOfWaysToWin());
            }

            int? result = null;
            foreach (int i in waysToWin)
            {
                if (result == null)
                {
                    result = i;
                    continue;
                }

                result = result * i;
            }

            return result ?? 0;
        }
    }

    internal class Race
    {
        public int Time;
        public long Distance;

        public int GetNumberOfWaysToWin()
        {
            int waysToWinCount = 0;
            for (int i = 1; i < Time; i++)
            {
                var timeLeftToRace = Time - i;
                long distanceTravelled = timeLeftToRace * (long)i;

                if (distanceTravelled > Distance)
                {
                    waysToWinCount++;
                }
            }

            return waysToWinCount;
        }
    }
}
