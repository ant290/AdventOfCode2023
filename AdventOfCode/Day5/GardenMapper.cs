namespace Day5
{
    internal class GardenMapper
    {
        private readonly IEnumerable<string> _lines;
        private MappingTypeEnum _mappingType = MappingTypeEnum.seed;

        private List<double> _seeds;
        private List<Mapping> _seedToSoilMaps;
        private List<Mapping> _soilToFertilizerMaps;
        private List<Mapping> _fertilizerToWaterMaps;
        private List<Mapping> _waterToLightMaps;
        private List<Mapping> _lightToTemperatureMaps;
        private List<Mapping> _temperatureToHumidityMaps;
        private List<Mapping> _humidityToLocationMaps;

        public GardenMapper(IEnumerable<string> lines)
        {
            _lines = lines;
        }

        public void ProcessData()
        {
            foreach (var line in _lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    _mappingType++;
                    continue;
                }

                switch (_mappingType)
                {
                    case MappingTypeEnum.seed:
                        ProcessSeedLine(line);
                        break;
                    case MappingTypeEnum.seedToSoil:
                        ProcessSeedToSoilLine(line);
                        break;
                    case MappingTypeEnum.soilToFertilizer:
                        ProcessSoilToFertilizerLine(line);
                        break;
                    case MappingTypeEnum.fertilizerToWater:
                        ProcessFertilizerToWaterLine(line);
                        break;
                    case MappingTypeEnum.waterToLight:
                        ProcessWaterToLightLine(line);
                        break;
                    case MappingTypeEnum.lightToTemperature:
                        ProcessLightToTemperatureLine(line);
                        break;
                    case MappingTypeEnum.temperatureToHumidity:
                        ProcessTemperatureToHumidityLine(line);
                        break;
                    case MappingTypeEnum.humidityToLocation:
                        ProcessHumidityToLocationLine(line);
                        break;
                }
            }
        }

        public List<double> GetSeedLocations()
        {
            var res = new List<double>();
            foreach(var seed in _seeds)
            {
                double soil = GetMappedValue(_seedToSoilMaps, seed);
                double fert = GetMappedValue(_soilToFertilizerMaps, soil);
                double water = GetMappedValue(_fertilizerToWaterMaps, fert);
                double light = GetMappedValue(_waterToLightMaps, water);
                double temp = GetMappedValue(_lightToTemperatureMaps, light);
                double humid = GetMappedValue(_temperatureToHumidityMaps, temp);
                double location = GetMappedValue(_humidityToLocationMaps, humid);

                res.Add(location);
            }

            return res;
        }

        private double GetMappedValue(List<Mapping> maps, double sourceValue)
        {
            var retVal = sourceValue;
            var foundMap = maps.FirstOrDefault(x => x.RangeContains(sourceValue));
            if (foundMap != null)
            {
                var countin = sourceValue - foundMap.SourceCategory;
                retVal = foundMap.DestinationCategory + countin;
            }
            return retVal;
        }

        private void ProcessSeedLine(string line)
        {
            var seedsList = line.Split(':').Last().Trim().Split(' ').ToList();
            _seeds = seedsList.Select(s => double.Parse(s)).ToList();
        }

        private void ProcessSeedToSoilLine(string line)
        {
            if (line.StartsWith("seed"))
            {
                _seedToSoilMaps = new List<Mapping>();
                return;
            }

            ProcessMappingLine(_seedToSoilMaps, line);
        }

        private void ProcessSoilToFertilizerLine(string line)
        {
            if (line.StartsWith("soil"))
            {
                _soilToFertilizerMaps = new List<Mapping>();
                return;
            }

            ProcessMappingLine(_soilToFertilizerMaps, line);
        }

        private void ProcessFertilizerToWaterLine(string line)
        {
            if (line.StartsWith("fertilizer"))
            {
                _fertilizerToWaterMaps = new List<Mapping>();
                return;
            }

            ProcessMappingLine(_fertilizerToWaterMaps, line);
        }

        private void ProcessWaterToLightLine(string line)
        {
            if (line.StartsWith("water"))
            {
                _waterToLightMaps = new List<Mapping>();
                return;
            }

            ProcessMappingLine(_waterToLightMaps, line);
        }

        private void ProcessLightToTemperatureLine(string line)
        {
            if (line.StartsWith("light"))
            {
                _lightToTemperatureMaps = new List<Mapping>();
                return;
            }

            ProcessMappingLine(_lightToTemperatureMaps, line);
        }

        private void ProcessTemperatureToHumidityLine(string line)
        {
            if (line.StartsWith("temperature"))
            {
                _temperatureToHumidityMaps = new List<Mapping>();
                return;
            }

            ProcessMappingLine(_temperatureToHumidityMaps, line);
        }

        private void ProcessHumidityToLocationLine(string line)
        {
            if (line.StartsWith("humidity"))
            {
                _humidityToLocationMaps = new List<Mapping>();
                return;
            }

            ProcessMappingLine (_humidityToLocationMaps, line);
        }

        private void ProcessMappingLine(List<Mapping> mappings, string line)
        {
            var mapParts = line.Split(' ');
            mappings.Add(new Mapping
            {
                DestinationCategory = double.Parse(mapParts[0]),
                SourceCategory = double.Parse(mapParts[1]),
                RangeLength = double.Parse(mapParts[2]),
            });
        }
    }
}
