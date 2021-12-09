namespace Day8
{
    public class SevenSegmentDisplay
    {
        private string Zero = String.Empty;
        private string One = String.Empty;
        private string Two = String.Empty;
        private string Three = String.Empty;
        private string Four = String.Empty;
        private string Five = String.Empty;
        private string Six = String.Empty;
        private string Seven = String.Empty;
        private string Eight = String.Empty;
        private string Nine = String.Empty;

        private char BottomLeft = char.MaxValue;

        public int Value;

        public SevenSegmentDisplay(List<string> inputValues, List<string> reading)
        {
            MapInputValues(inputValues);
            AssignValue(reading);
        }

        private void MapInputValues(List<string> inputValues)
        {
            // 1, 4, 7, 8
            MapUniqueCountValues(inputValues);
            FindNine(inputValues);
            FindZero(inputValues);
            FindSix(inputValues);
            FindFive(inputValues);
            FindTwo(inputValues);
            FindThree(inputValues);
        }

        private void MapUniqueCountValues(List<string> inputValues)
        {
            One = inputValues.Single(v => v.Length == 2);
            Four = inputValues.Single(v => v.Length == 4);
            Seven = inputValues.Single(v => v.Length == 3);
            Eight = inputValues.Single(v => v.Length == 7);
        }

        private void FindNine(List<string> inputValues)
        {
            Nine = inputValues.Single(v => 
                v.Count() == 6
                && Contains(v, Four)
                && Contains(v, Seven));

            BottomLeft = Eight.Single(c => !Nine.Contains(c));
        }

        private void FindZero(List<string> inputValues) =>
            Zero = inputValues.Single(v => v.Count() == 6
                && Contains(v, One)
                && v != Nine);
            
        private void FindSix(List<string> inputValues)
        {
            var values = inputValues.Where(v => v.Count() == 6);
            values = values.Where(v => v != Nine);
            values = values.Where(v => v != Zero);

            Six = values.Single();
        }

        private void FindFive(List<string> inputValues) =>
            Five = inputValues.Single(v => v.Count() == 5
                && Contains(Six, v));

        private void FindTwo(List<string> inputValues) =>
            Two = inputValues.Single(c => c.Count() == 5
                && c.Contains(BottomLeft));

        private void FindThree(List<string> inputValues) =>
            Three = inputValues.Single(v => !(new[] { Zero, One, Two, Four, Five, Six, Seven, Eight, Nine }).Contains(v));

        private bool Contains(string container, string containee) =>
            containee.All(x => container.Contains(x));
        
        private void AssignValue(List<string> output)
        {
            var stringifiedValue = string.Empty;
            foreach(var value in output)
            {
                stringifiedValue += 
                      IsEquivalent(value, Zero) ? "0"
                    : IsEquivalent(value, One) ? "1"
                    : IsEquivalent(value, Two) ? "2"
                    : IsEquivalent(value, Three) ? "3"
                    : IsEquivalent(value, Four) ? "4"
                    : IsEquivalent(value, Five) ? "5"
                    : IsEquivalent(value, Six) ? "6"
                    : IsEquivalent(value, Seven) ? "7"
                    : IsEquivalent(value, Eight) ? "8"
                    : "9";
            }

            Value = int.Parse(stringifiedValue);
        }

        private bool IsEquivalent(string val1, string val2) =>
            val1.Count() == val2.Count()
            && val1.All(x => val2.Contains(x));
    }
}
