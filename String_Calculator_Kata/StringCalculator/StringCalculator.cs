namespace StringCalculatorKata.StringCalculator
{
    public class StringCalculator : IStringCalculator
    {
        public int Add(string inputs)
        {
            if (string.IsNullOrWhiteSpace(inputs))
                return 0;
            var sum = Convart(inputs);

            return sum.Sum(x => x);
        }


        private List<int> Convart(string inputs)
        {
            var numbers = inputs.Split(',').ToList();

             return numbers
                .Select(x => int.Parse(x))
                .ToList(); 
        }
    }
}
