namespace StringCalculatorKata.StringCalculator
{
    public class StringCalculator : IStringCalculator
    {
        public int Add(string inputs)
        {
            if (string.IsNullOrWhiteSpace(inputs))
                return 0;

            var customDelimeter = CustomDelimeter(inputs);
            var sum = Convart(inputs, customDelimeter);

            return sum.Sum(x => x);
        }


        private List<int> Convart(string inputs, char customDelimeter)
        {
            var delimeter = new char[] { '\n', '/' }.ToList();
            delimeter.Add(customDelimeter);
            var numbers = inputs.Split(delimeter.ToArray()).ToList();

            return numbers
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
