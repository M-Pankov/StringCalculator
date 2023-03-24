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
    public void Run_EmptyString_ShouldReturnWelcomeMessageAndShutDown()
    {
        _consoleWrapper.Setup(x => x.WriteLine(It.IsAny<string>()));
        _consoleWrapper.Setup(x => x.ReadLine()).Returns("");

        _consoleCalculatorWorker.Run();

        _consoleWrapper.Verify(p => p.WriteLine("Enter comma separated numbers (enter to exit):"), Times.Once);
        _consoleWrapper.Verify(p => p.ReadLine(), Times.Once);
    }

    [Fact]
    public void Run_SeveralNumbersTwoTimes_ShouldReturnTwoMessagesWithSumResult()
    {
        _customStringCalculator.SetupSequence(x => x.Add(It.IsAny<string>()))
            .Returns(3)
            .Returns(4);

        _consoleWrapper.Setup(x => x.WriteLine(It.IsAny<string>()));

        _consoleWrapper.SetupSequence(x => x.ReadLine())
            .Returns("1,2")
            .Returns("2,2");

        _consoleCalculatorWorker.Run();

        _consoleWrapper.Verify(p => p.WriteLine("Result is: 3\r\nyou can enter other numbers (enter to exit)?"), Times.Once);
        _consoleWrapper.Verify(p => p.WriteLine("Result is: 4\r\nyou can enter other numbers (enter to exit)?"), Times.Once);
    }
}
