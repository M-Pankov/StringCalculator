using FluentAssertions;
using System;
using Xunit;

namespace StringCalculator.Tests;

public class CustomStringCalculatorTests
{
    CustomStringCalculator stringCalculator;

    public CustomStringCalculatorTests()
    {
        stringCalculator = new CustomStringCalculator();
    }

    [Fact]
    public void Add_EmptyString_ExpectedNumberZeroInResult()
    {
        string input = "";

        var result = stringCalculator.Add(input);

        result.Should().Be(0);
    }

    [Fact]
    public void Add_NumberOne_ExpectedNumberOneInResult()
    {
        string input = "1";

        var result = stringCalculator.Add(input);

        result.Should().Be(1);
    }

    [Fact]
    public void Add_NumbersOneTwoThreeWithStandartDelimiters_ExpectedNumberSixInResult()
    {
        string input = "1,2\n3";

        var result = stringCalculator.Add(input);

        result.Should().Be(6);
    }

    [Fact]
    public void Add_CastomDelimitersAndNumbersOneTwoThree_ExpectedNumberSixInResult()
    {
        string input = "//[]]]][&&&]\n1]]]2&&&3";

        var result = stringCalculator.Add(input);

        result.Should().Be(6);
    }
    [Fact]
    public void Add_CastomDelimitersAndNumbersOneTwoThreeInVerbatimString_ExpectedNumberSixInResult()
    {
        string input = @"//[]]]][&&&]\n1]]]2&&&3";

        var result = stringCalculator.Add(input);

        result.Should().Be(6);
    }


    [Fact]
    public void Add_NumbersOneTwoAndOneThousandOne_ExpectedThreeInResult()
    {
        string input = "1,2\n1001";

        var result = stringCalculator.Add(input);

        result.Should().Be(3);
    }

    [Fact]
    public void Add_NegativeNumberOne_ExpectedExceptionInResult()
    {
        string input = "-1";

        Action result = () => stringCalculator.Add(input);

        result.Should().Throw<Exception>().WithMessage("Negatives not allowed: -1");
    }
}
