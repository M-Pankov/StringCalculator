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

        Assert.Equal(result, 0);
    }

    [Fact]
    public void Add_Number_ShouldReturnThisNumder()
    {
        string input = "1";

        var result = _stringCalculator.Add(input);

        Assert.Equal(result, 1);
    }

    [Fact]
    public void Add_CustomDelimitersAndSeveralNumbers_ShouldReturnSum()
    {
        string input = @"//[]]]][&&&]\n1]]]2&&&3";

        var result = _stringCalculator.Add(input);

        Assert.Equal(result, 6);
    }

    [Fact]
    public void Add_SeveralNumbersWithOneWitchGreaterThanMaxNumber_ShouldReturnSumOfNumbersThatLessMaxNumber()
    {
        string input = @"1,2\n1001";

        var result = _stringCalculator.Add(input);

        Assert.Equal(result, 3);
    }

    [Fact]
    public void Add_NegativeNumber_ShouldThrowException()
    {
        string input = "-1";

        var result = Assert.Throws<Exception>(() => _stringCalculator.Add(input));

        Assert.Equal(result.Message, "Negatives not allowed: -1");
    }
}
