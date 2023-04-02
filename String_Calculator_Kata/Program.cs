using StringCalculatorKata.StringCalculator;

public class Program
{
    private static void Main(string[] args)
    {
        var stringCalculator = new StringCalculator();
        Console.WriteLine($"The sum of the input is : {stringCalculator.Add("1,4,-1,-2,-3")}");
    }
}