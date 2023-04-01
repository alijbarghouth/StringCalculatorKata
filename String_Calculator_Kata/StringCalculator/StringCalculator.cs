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

        private int Sum(string numbers, char customDelimeter)
        {
            var listArrayOfNumbers = ConvartStringToArrayOfNumber(numbers, customDelimeter);

            return listArrayOfNumbers.Sum(x => x);
        }
        private char CustomDelimeter(string numbers)
        {
            return numbers.StartsWith("//") ? numbers[2] : ',';
        }
        private List<int> ConvartStringToArrayOfNumber(string numbers, char customDelimeter)
        {
            var listNumbers = ConvartStringToArrayWithAtMostTowNumberOfTheArray(numbers, customDelimeter);
            var isNegativNumber = HasNegativeNumber(listNumbers);
            ThrowAnExceptionIfFindNegativNumber(isNegativNumber, listNumbers);

            return listNumbers;
        }

        private void ThrowAnExceptionIfFindNegativNumber(bool isNegativNumber, List<int> numbersWithoutEmptySpace)
        {
            if (isNegativNumber)
                throw new ArgumentException($"negatives not allowed: " +
                    $"{ReturnStirngContainTheNumberNegative(numbersWithoutEmptySpace)}");
        }
        private List<int> ConvartStringToArrayWithAtMostTowNumberOfTheArray(string numbers, char customDelimeter)
        {
            var delimeter = new char[] { '\n', '/' }.ToList();
            delimeter.Add(customDelimeter);
            var number = numbers.Split(delimeter.ToArray()).ToList();

            return number
                .Where(x => !string.IsNullOrEmpty(x))
                .Select(x => int.Parse(x))
                .Where(x => x <= 1000)
                .ToList();
        }
        private string ReturnStirngContainTheNumberNegative(List<int> numbersWithoutEmptySpace)
        {
            string nums = "";
            numbersWithoutEmptySpace.Where(x => x < 0)
                .ToList().ForEach(x => nums += x + ",");

            return nums;
        }
        private bool HasNegativeNumber(List<int> number)
        {
            return number
                .Any(x => x < 0);
        }
    }
}
