using StringCalculator;
using System;

namespace ConsoleStringCalculator;

public class ConsoleCalculatorWorker
{
    private readonly CustomStringCalculator _stringCalculator;

    private readonly ConsoleWrapper _consoleWrapper;

    public ConsoleCalculatorWorker(): this(new CustomStringCalculator(), new ConsoleWrapper())
    {
    }

    public ConsoleCalculatorWorker(CustomStringCalculator calculator, ConsoleWrapper consoleWrapper)
    {
        _stringCalculator = calculator;
        _consoleWrapper = consoleWrapper;
    }

    public void Run()
    {
        _consoleWrapper.WriteLine("Enter comma separated numbers (enter to exit):");

        var input = _consoleWrapper.ReadLine();
        DoWork(input);
    }

    private void DoWork(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return;
        }

        var sum = _stringCalculator.Add(input);

        _consoleWrapper.WriteLine("Result is: " + sum + "\r\nyou can enter other numbers (enter to exit)?");

        var nextInput = _consoleWrapper.ReadLine();
        DoWork(nextInput);
    }
}
