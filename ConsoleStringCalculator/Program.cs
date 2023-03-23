using StringCalculator;
using System;

namespace ConsoleStringCalculator;

public class Program
{
    public static void Main(string[] args)
    {
        var customStringCalculator = new CustomStringCalculator();

        var calculatorWorker = new ConsoleCalculatorWorker(customStringCalculator);

        calculatorWorker.Run();
    }
}