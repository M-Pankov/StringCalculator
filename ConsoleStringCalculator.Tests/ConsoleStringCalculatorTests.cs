using Moq;
using StringCalculator;
using Xunit;

namespace ConsoleStringCalculator.Tests;

public class ConsoleStringCalculatorTests
{
    private readonly Mock<CustomStringCalculator> _customStringCalculator;
    private readonly Mock<ConsoleWrapper> _consoleWrapper;
    private readonly ConsoleCalculatorWorker _consoleCalculatorWorker;

    public ConsoleStringCalculatorTests()
    {
        _consoleWrapper = new Mock<ConsoleWrapper>();
        _customStringCalculator = new Mock<CustomStringCalculator>();
        _consoleCalculatorWorker = new ConsoleCalculatorWorker(_customStringCalculator.Object, _consoleWrapper.Object);
    }

    [Fact]
    public void Run_SeveralNumbers_Should()
    {
        _consoleWrapper.Setup(x => x.WriteLine(It.IsAny<string>()));

        _consoleWrapper.Setup(x => x.ReadLine()).Returns("");

        _consoleCalculatorWorker.Run();

        _consoleWrapper.VerifyAll();
    }
}
