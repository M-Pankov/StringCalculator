

namespace Kata1Tests;

public class StringCalculatorTests
{
    private readonly StringCalculator stringCalculator = new StringCalculator();


    [Fact]
    public void Method_Add_With_NullAndEmpty_String_ZeroResult()
    {
        int expected = 0;

        string firstInput = "";
        string secondInput = null;

        var firstResult = stringCalculator.Add(firstInput);
        var secondResult = stringCalculator.Add(secondInput);

        firstResult.Should().Be(expected);
        secondResult.Should().Be(expected);
    }

    [Fact]
    public void Method_Add_With_1_in_String_1_in_Result()
    {
        int expected = 1;

        string firstInput = "1";

        var firstResult = stringCalculator.Add(firstInput);

        firstResult.Should().Be(expected);
    }

    [Fact]
    public void Method_Add_With_12_in_String_With_Comma_Delimiter_3_in_Result()
    {
        int expected = 3;

        string firstInput = "1,2";

        var firstResult = stringCalculator.Add(firstInput);

        firstResult.Should().Be(expected);
    }

    [Fact]
    public void Method_Add_With_123_in_String_With_Comma_and_NewLine_Delimiters_6_in_Result()
    {
        int expected = 6;

        string firstInput = "1,2\n3";

        var firstResult = stringCalculator.Add(firstInput);

        firstResult.Should().Be(expected);
    }

    [Fact]
    public void Method_Add_With_1_in_String_With_Invalid_Delimiters_ZeroResult()
    {
        int expected = 0;

        string firstInput = "1,\n";

        var firstResult = stringCalculator.Add(firstInput);

        firstResult.Should().Be(expected);
    }
}
