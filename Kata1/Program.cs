using StringCalculatorProject;
using System;

internal class Program
{
    public static void Main(string[] args)
    {
        var stringCalc = new CustomStringCalculator();

        var userData = Console.ReadLine();

        var sumResult = stringCalc.Add(userData);

        Console.WriteLine(sumResult);

        Console.ReadLine();
    }
}