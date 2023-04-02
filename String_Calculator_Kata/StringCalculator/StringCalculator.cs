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
            var numberWitoutBigInteger = ReturnFinalArrayOfInteger(numbers, customDelimeter);

            return numberWitoutBigInteger
                .Sum(x => x);
        }
        private List<int> ReturnFinalArrayOfInteger(string numbers, char customDelimeter)
        {
            var numberWithEmptySpace = ConvartStringToArrayWithAtMostTowNumberOfTheArray(numbers, customDelimeter);
            var numbersWithoutEmptySpace = GetNumberFromList(numberWithEmptySpace);
            var findNegativNumber = FindNegativeNumber(numbersWithoutEmptySpace);
            ThrowAnExceptionIfFindNegativNumber(findNegativNumber, numbersWithoutEmptySpace);
            var findBigInteger = FindBigInteger(numbersWithoutEmptySpace);
            var numberWithoutBigInteger = RemoveBigIntegerIfExists(findBigInteger, numbersWithoutEmptySpace);

            return numberWithoutBigInteger;
        }
        private List<int> RemoveBigIntegerIfExists(bool findBigInteger, List<int> numbersWithoutEmptySpace)
        {
            return findBigInteger
                ? numbersWithoutEmptySpace.Where(x => x <= 1000).ToList()
                : numbersWithoutEmptySpace;
        }

        private void ThrowAnExceptionIfFindNegativNumber(bool isNegativNumber, List<int> numbersWithoutEmptySpace)
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
        private bool FindNegativeNumber(List<int> number)
        {
            return number
                .Any(x => x < 0);
        }

        private bool FindBigInteger(List<int> numbers)
        {
            return numbers
                .Any(x => x > 1000);
        }
    }
}
