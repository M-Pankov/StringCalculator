using StringCalculator;

namespace ConsoleStringCalculator;

public class Program
{
    public static void Main(string[] args)
    {
        var consoleWrapper = new ConsoleWrapper();

        var customStringCalculator = new CustomStringCalculator();

        var calculatorWorker = new ConsoleCalculatorWorker(customStringCalculator, consoleWrapper);

        calculatorWorker.Run();
    }
}