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
            var numberWithEmptySpace = ConvartStringToArrayWithAtMostTowNumberOfTheArray(numbers, customDelimeter);
            var numbersWithoutEmptySpace = GetNumberFromList(numberWithEmptySpace);
            var isNegativNumber = IsNegativeNumber(numbersWithoutEmptySpace);
            ThrowAnExceptionIfFindNegativNumber(isNegativNumber, numbersWithoutEmptySpace);

            return numbersWithoutEmptySpace
                .Sum(x => x);
        }
        private void ThrowAnExceptionIfFindNegativNumber(bool isNegativNumber,List<int> numbersWithoutEmptySpace)
        {
            if (isNegativNumber)
                throw new ArgumentException($"negatives not allowed: " +
                    $"{ReturnTheNumberNegativAndThrowAnException(numbersWithoutEmptySpace)}");

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
        private string ReturnTheNumberNegativAndThrowAnException(List<int> numbersWithoutEmptySpace)
        {
            string nums = "";
            numbersWithoutEmptySpace.Where(x => x < 0)
                .ToList().ForEach(x => nums += x + ",");

            return nums;
        }
        private bool IsNegativeNumber(List<int> number)
        {
            return number
                .Any(x => x < 0);
        }
    }
}
