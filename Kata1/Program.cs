using System;

namespace StringCalculator;

internal class Program
{
    public static void Main(string[] args)
    {
        var stringCalculator = new CustomStringCalculator();

        var userData = Console.ReadLine();

        var sum = stringCalculator.Add(userData);

        Console.WriteLine(sum);

        Console.ReadLine();
    }
}