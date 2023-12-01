using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    internal class CalibrationEngine
    {
        private IEnumerable<string> _lines;

        private Dictionary<string, char> _numbersDictionary = new Dictionary<string, char>
        {
            {"one", '1'},
            {"two", '2'},
            {"three", '3'},
            {"four", '4'},
            {"five", '5'},
            {"six", '6'},
            {"seven", '7'},
            {"eight", '8'},
            {"nine", '9'}
        };

        public CalibrationEngine(IEnumerable<string> lines)
        {
            _lines = lines;
        }

        public int ProcessValues()
        {
            var sumOfCalibration = 0;
            foreach (var line in _lines)
            {
                var firstVal = FindFirstValue(line);
                var lastVal = FindLastValue(line);

                var twoDigits = $"{firstVal}{lastVal}";
                int.TryParse(twoDigits, out int bigNum);
                sumOfCalibration += bigNum;
            }

            return sumOfCalibration;
        }

        private char FindFirstValue(string line)
        {
            var numbers = string.Concat(line.Where(char.IsDigit));
            var posFirstDigit = numbers.Length > 0 ? line.IndexOf(numbers[0]) : -1;
            (char charFirstString, int posFirstString) = FindFirstString(line);

            if (posFirstDigit > -1 && posFirstDigit < posFirstString) return numbers[0];
            return charFirstString;
        }

        private char FindLastValue(string line)
        {
            var numbers = string.Concat(line.Where(char.IsDigit));
            var posLastDigit = numbers.Length > 0 ? line.LastIndexOf(numbers.Last()) : -1;
            (char charLastString, int posLastString) = FindLastString(line);

            if (posLastDigit > -1 && posLastDigit > posLastString) return numbers.Last();
            return charLastString;
        }

        private (char num, int location) FindFirstString(string line)
        {
            var firstFoundNumber = '0';
            var firstFoundLocation = line.Length +1;

            foreach (var i in _numbersDictionary)
            {
                var found = line.IndexOf(i.Key);
                if (found > -1 && found < firstFoundLocation)
                {
                    firstFoundNumber = i.Value;
                    firstFoundLocation = found;
                }
            }

            return (firstFoundNumber, firstFoundLocation);
        }

        private (char num, int location) FindLastString(string line)
        {
            var lastFoundNumber = '0';
            var lastFoundLocation = -1;

            foreach (var i in _numbersDictionary)
            {
                var found = line.LastIndexOf(i.Key);
                if (found > -1 && found > lastFoundLocation)
                {
                    lastFoundNumber = i.Value;
                    lastFoundLocation = found;
                }
            }

            return (lastFoundNumber, lastFoundLocation);
        }
    }
}
