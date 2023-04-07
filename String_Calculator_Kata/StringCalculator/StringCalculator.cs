namespace StringCalculatorKata.StringCalculator
{
    public class StringCalculator : IStringCalculator
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrWhiteSpace(numbers))
                return 0;
            var sum = Sum(numbers);

            return sum;
        }

        private int Sum(string numbers)
        {
            var listArrayOfNumbers = ConvartStringToArrayOfNumber(numbers);

            return listArrayOfNumbers.Sum(x => x);
        }
        private List<int> ConvartStringToArrayOfNumber(string numbers)
        {
            var listOfNumbers = numbers.Split(',');

             return listOfNumbers
                .Select(x => int.Parse(x))
                .ToList(); 
        }
    }
}
