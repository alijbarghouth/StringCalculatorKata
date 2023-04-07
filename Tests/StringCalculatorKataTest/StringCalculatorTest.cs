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
        [InlineData("")]
        [InlineData("   ")]
        [InlineData(null)]
        public void Add_ShouldReturnZero(string numbers)
        {
            var actual = _stringCalculator.Add(numbers);

            Assert.Equal(0, actual);
        }

        [Theory]
        [InlineData("1",1)]
        [InlineData("1,2",3)]
        public void Add_ShouldReturnTheSum(string numbers,int expected)
        {
            Assert.Equal(expected, _stringCalculator.Add(numbers));
        }
        [Theory]
        [InlineData("1,2,3,4", 10)]
        [InlineData("1,2,3,4,5", 15)]
        public void Add_ShouldReturnTheSumAllowUnknownAmountOfNumbers(string numbers, int expected)
        {
            Assert.Equal(expected, _stringCalculator.Add(numbers));
        }
        [Theory]
        [InlineData("1\n2,3", 6)]
        [InlineData("1\n2,3\n5", 11)]
        public void Add_ShouldReturnTheSumHandleNewLinesBetweenNumbers(string numbers, int expected)
        {
            Assert.Equal(1, _stringCalculator.Add("1"));
            Assert.Equal(3, _stringCalculator.Add("1,2"));
        }
        [Theory]
        [InlineData("//;\n1;2", 3)]
        [InlineData("//;;;;;;1\n\n7\n1;2", 11)]
        public void Add_SupportDifferentDelimiters(string numbers, int expected)
        {
            Assert.Equal(expected, _stringCalculator.Add(numbers));
        }
        [Fact]
        public void Add_NegativeNumbersMustReturnException()
        {
            Assert.Throws<ArgumentException>(() => _stringCalculator.Add("1,4,-1"));
        }
        [Fact]
        public void Add_IgnoreBigNumbers()
        {
            Assert.Equal(3, _stringCalculator.Add("1,1001,2000,2"));
        }
    }
}