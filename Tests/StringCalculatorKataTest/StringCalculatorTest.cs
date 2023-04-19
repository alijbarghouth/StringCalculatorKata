using StringCalculatorKata.StringCalculator;

namespace StringCalculatorKataTest
{
    public class StringCalculatorTest
    {
        private readonly IStringCalculator _stringCalculator;

        public StringCalculatorTest()
        {
            _stringCalculator = new StringCalculator();
        }

        [Theory]
        [InlineData("", 0)]
        [InlineData("   ", 0)]
        [InlineData(null, 0)]
        [InlineData("1", 1)]
        [InlineData("1,2", 3)]
        [InlineData("1,2,4,5,6", 18)]
        [InlineData("1,2,3,4,5", 15)]
        public void Add_Success(string numbers, int expected)
        {
            var actual = _stringCalculator.Add(numbers);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("", 1)]
        [InlineData("   ", 2)]
        [InlineData(null, 4)]
        [InlineData("1", 11)]
        [InlineData("1,2", 23)]
        [InlineData("1,2,3,4", 19)]
        [InlineData("1,2,3,4,5", 150)]
        public void Add_Failure(string numbers, int expected)
        {
            var actual = _stringCalculator.Add(numbers);

            Assert.NotEqual(expected, actual);
        }
        [Theory]
        [InlineData("//;\n1;2", 3)]
        [InlineData("//;;;;;;1\n\n7\n1;2", 11)]
        public void Add_SuccessSupportDifferentDelimiters(string numbers, int expected)
        {
            Assert.Equal(expected, _stringCalculator.Add(numbers));
        }
        [Theory]
        [InlineData("//\n;\n1;2", 3)]
        [InlineData("//\n;;;;;;1\n\n7\n1;2", 11)]
        public void Add_FailureSupportDifferentDelimiters(string numbers, int expected)
        {
            Assert.NotEqual(expected, _stringCalculator.Add(numbers));
        }
    }
}