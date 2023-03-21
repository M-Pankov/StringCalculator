using Kata1;

internal class Program
{
    private static void Main(string[] args)
    {
        var stringCalc = new StringCalculator();
        Console.WriteLine(stringCalc.Add(Console.ReadLine()));
        Console.ReadLine();
    }
}