using System;
using Xunit;

namespace StringCalculator.Tests;

public class CustomStringCalculatorTests
{
    private CustomStringCalculator _stringCalculator;

    public CustomStringCalculatorTests()
    {
        _stringCalculator = new CustomStringCalculator();
    }

    [Fact]
    public void Add_EmptyString_ShouldReturnZero()
    {
        string input = "";

        var result = _stringCalculator.Add(input);

        Assert.Equal( 0, result);
    }

    [Fact]
    public void Add_Number_ShouldReturnThisNumber()
    {
        string input = "1";

        var result = _stringCalculator.Add(input);

        Assert.Equal( 1, result);
    }

    [Fact]
    public void Add_CustomDelimitersAndSeveralNumbers_ShouldReturnSum()
    {
        string input = @"//[]]]][&&&]\n1]]]2&&&3";

        var result = _stringCalculator.Add(input);

        Assert.Equal( 6, result);
    }

    [Fact]
    public void Add_SeveralNumbersWithOneWitchGreaterThanMaxNumber_ShouldReturnSumOfNumbersThatLessMaxNumber()
    {
        string input = @"1,2\n1001";

        var result = _stringCalculator.Add(input);

        Assert.Equal( 3, result);
    }

    [Fact]
    public void Add_NegativeNumber_ShouldThrowException()
    {
        string input = "-1";

        var result = Assert.Throws<Exception>(() => _stringCalculator.Add(input));

        Assert.Equal( "Negatives not allowed: -1", result.Message);
    }
}
