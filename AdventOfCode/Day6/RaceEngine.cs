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
                        Time = 7,
                        Distance = 9
                    },
                    new Race()
                    {
                        Time = 15,
                        Distance = 40
                    },
                    new Race()
                    {
                        Time = 30,
                        Distance = 200
                    }
                };
            }
            else
            {
                Races = new List<Race>()
                {
                    new Race()
                    {
                        Time = 38,
                        Distance = 234
                    },
                    new Race()
                    {
                        Time = 67,
                        Distance = 1027
                    },
                    new Race()
                    {
                        Time = 76,
                        Distance = 1157
                    },
                    new Race()
                    {
                        Time = 73,
                        Distance = 1236
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
        public int Distance;

        public int GetNumberOfWaysToWin()
        {
            int waysToWinCount = 0;
            for (int i = 1; i < Time; i++)
            {
                var timeLeftToRace = Time - i;
                var distanceTravelled = i * timeLeftToRace;

                if (distanceTravelled > Distance) waysToWinCount++;
            }

            return waysToWinCount;
        }
    }
}
