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
    }
}