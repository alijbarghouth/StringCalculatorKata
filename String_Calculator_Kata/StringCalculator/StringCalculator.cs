namespace StringCalculatorKata.StringCalculator
{
    public class StringCalculator : IStringCalculator
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrWhiteSpace(numbers))
                return 0;

            var customDelimeter = CustomDelimeter(numbers);
            var sum = Sum(numbers,customDelimeter);

            return sum;
        }

        private int Sum(string numbers,char customDelimeter)
        {
            var listArrayOfNumbers = ConvartStringToArrayOfNumber(numbers,customDelimeter);

            return listArrayOfNumbers.Sum(x => x);
        }
        private List<int> ConvartStringToArrayOfNumber(string numbers,char customDelimeter)
        {
            var delimeter = new char[] { '\n', '/' }.ToList();
            delimeter.Add(customDelimeter);
            var number = numbers.Split(delimeter.ToArray()).ToList();

            return number
                                .Where(x => !string.IsNullOrEmpty(x))
                .Select(x => int.Parse(x))
                .ToList();
        }
        private char CustomDelimeter(string numbers)
        {
            return numbers.StartsWith("//") ? numbers[2] : ',';
        }
    }
}
