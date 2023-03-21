using FluentAssertions;
using Xunit;

namespace StringCalculatorProject.Tests;

public class CustomStringCalculatorTests
{
    [Fact]
    public void Add_EmptyString_0()
    {
        var stringCalculator = new CustomStringCalculator();

        int expected = 0;

        string input = "";

        var result = stringCalculator.Add(input);

        result.Should().Be(expected);
    }

    [Fact]
    public void Add_1_1()
    {
        var stringCalculator = new CustomStringCalculator();

        int expected = 1;

        string firstInput = "1";

        var firstResult = stringCalculator.Add(firstInput);

        firstResult.Should().Be(expected);
    }

    [Fact]
    public void Add_126_6()
    {
        var stringCalculator = new CustomStringCalculator();

        int expected = 6;

        string firstInput = "1,2\n3";

        var firstResult = stringCalculator.Add(firstInput);

        firstResult.Should().Be(expected);
    }

    [Fact]
    public void Add_NewDelimiters11111_5()
    {
        var stringCalculator = new CustomStringCalculator();

        int expected = 5;

        string firstInput = "//[$$$][&&&]\n1\n1,1$$$1&&&1";

        var firstResult = stringCalculator.Add(firstInput);

        firstResult.Should().Be(expected);
    }
}
