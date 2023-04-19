namespace StringCalculatorKata.StringCalculator
{
    public class StringCalculator : IStringCalculator
    {
        public int Add(string inputs)
        {
            if (string.IsNullOrWhiteSpace(inputs))
                return 0;

            var customDelimeter = CustomDelimeter(inputs);
            var numbers = Convart(inputs, customDelimeter);
            var isNegativNumber = HasNegativeNumber(numbers);
            ThrowAnExceptionIfFindNegativNumber(isNegativNumber, numbers);
            return numbers.Sum(x => x);
        }
        private static List<int> Convart(string inputs, char customDelimeter)
        {
            var delimeter = new char[] { '\n', '/' }.ToList();
            delimeter.Add(customDelimeter);
            var numbers = inputs.Split(delimeter.ToArray()).ToList();

            return numbers
                .Where(x => !string.IsNullOrEmpty(x))
                .Select(x => int.Parse(x))
                .Where(x => x <= 1000)
                .ToList();
        }
        private static char CustomDelimeter(string numbers)
        {
            return numbers.StartsWith("//") ? numbers[2] : ',';
        }
        private static void ThrowAnExceptionIfFindNegativNumber(bool isNegativNumber, List<int> numbersWithoutEmptySpace)
        {
            if (isNegativNumber)
                throw new ArgumentException($"negatives not allowed: " +
                    $"{ReturnStirngContainTheNumberNegative(numbersWithoutEmptySpace)}");
        }
        private static string ReturnStirngContainTheNumberNegative(List<int> numbersWithoutEmptySpace)
        {
            string nums = "";
            numbersWithoutEmptySpace.Where(x => x < 0)
                .ToList().ForEach(x => nums += x + ",");

            return nums;
        }
        private static bool HasNegativeNumber(List<int> number)
        {
            return number
                .Any(x => x < 0);
        }
    }
}
