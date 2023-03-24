using StringCalculator;
using System;

namespace ConsoleStringCalculator;

public class Program
{
    public static void Main(string[] args)
    {
        var calculatorWorker = new ConsoleCalculatorWorker();

        calculatorWorker.Run();
    }
}