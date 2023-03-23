using ConsoleStringCalculator;
using Moq;
using System;
using System.IO;
using Xunit;

namespace StringCalculator.Tests;

public class ConsoleStringCalculatorTests
{
    private readonly Mock<ICustomStringCalculator> _customStringCalculator;
    private readonly ConsoleCalculatorWorker _consoleCalculatorWorker;

    public ConsoleStringCalculatorTests()
    {
        _customStringCalculator = new Mock<ICustomStringCalculator>();
        _consoleCalculatorWorker = new ConsoleCalculatorWorker(_customStringCalculator.Object);
    }

    [Fact]
    public void Run_SeveralNumbers_ShouldReturnCorrectString()
    {
        _customStringCalculator.Setup(x => x.Add("1,2")).Returns(3);

        var output = new StringWriter();
        Console.SetOut(output);

        var input = new StringReader("1,2");
        Console.SetIn(input);

        _consoleCalculatorWorker.Run();

        Assert.Equal(string.Format("Enter comma separated numbers (enter to exit):\r\n3\r\nyou can enter other numbers (enter to exit)?\r\n"),output.ToString());
    }
}
