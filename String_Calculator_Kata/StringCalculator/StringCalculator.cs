namespace StringCalculatorKata.StringCalculator
{
    public class StringCalculator : IStringCalculator
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrWhiteSpace(numbers))
                return 0;
            var customDelimeter = CustomDelimeter(numbers);
            var sum = Sum(numbers, customDelimeter);

            return sum;
        }

        private char CustomDelimeter(string numbers)
        {
            return numbers.StartsWith("//") ? numbers[2] : ',';
        }
        private int Sum(string numbers, char customDelimeter)
        {
            var number = ConvartStringToArrayWithAtMostTowNumberOfTheArray(numbers, customDelimeter);
            var myNumbers = GetNumberFromList(number);

            return myNumbers
                .Sum(x => x);
        }
        private List<string> ConvartStringToArrayWithAtMostTowNumberOfTheArray(string numbers, char customDelimeter)
        {
            var delimeter = new char[] { '\n', '/' }.ToList();
            delimeter.Add(customDelimeter);

            var number = numbers.Split(delimeter.ToArray()).ToList();

            return number;
        }
        private List<int> GetNumberFromList(List<string> numbers)
        {
            return numbers
                .Where(x => !string.IsNullOrEmpty(x))
                .Select(x => int.Parse(x))
                .ToList();
        }
        private bool IsNegativNumber(int number)
        {
            return number < 0;
        }
    }
}
