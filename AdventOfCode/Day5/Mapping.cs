namespace Day5
{
    internal class Mapping
    {
        public double DestinationCategory { get; set; }
        public double SourceCategory {  get; set; }
        public double RangeLength { get; set; }

        public bool RangeContains(double input)
        {
            var sourceRangeEnd = SourceCategory + RangeLength - 1;
            if (SourceCategory <= input && sourceRangeEnd >= input)
            {
                return true;
            }

            return false;
        }
    }
}
