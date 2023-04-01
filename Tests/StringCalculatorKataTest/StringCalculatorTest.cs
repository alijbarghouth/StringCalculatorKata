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

        [Fact]
        public void Add_ShouldReturnTheSum()
        {
            Assert.Equal(1, _stringCalculator.Add("1"));
            Assert.Equal(3, _stringCalculator.Add("1,2"));
            Assert.Equal(3, _stringCalculator.Add("1,2,3"));
        }
    }
}