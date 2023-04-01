namespace StringCalculatorKata.StringCalculator
{
    public class StringCalculator : IStringCalculator
    {
        public int Add(string numbers)
        {
            var sum = Sum(numbers);

            return sum;
        }
        private int Sum(string numbers)
        {
            if (string.IsNullOrWhiteSpace(numbers))
                return 0;
            var number = ConvartStringToArrayWithAtMostTowNumberOfTheArray(numbers);

            return number.Sum(x => int.Parse(x));
        }
        private List<string> ConvartStringToArrayWithAtMostTowNumberOfTheArray(string numbers)
        {
            var tokens = numbers.Split(",");
            if (tokens.Length == 1)
                return new List<string> { tokens[0] };

            return new List<string> { tokens[0], tokens[1] };
        }
    }
}
