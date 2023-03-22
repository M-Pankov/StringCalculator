using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator;

public class CustomStringCalculator
{
    public int Add(string numbers)
    {
        if (string.IsNullOrEmpty(numbers))
        {
            return 0;
        }

        IList<string> delimiters = new List<string>() { ",", @"\n" };

        if (numbers.StartsWith("//"))
        {
            var slashesEndIndex = 2;

            numbers = numbers.Remove(0, slashesEndIndex);

            var delimitersEndIndex = numbers.IndexOf(@"\n");

            var separatedCustomDelimiters = numbers.Substring(0, delimitersEndIndex);

            numbers = numbers.Substring(delimitersEndIndex); 

            delimiters = AddCustomDelimiters(separatedCustomDelimiters, delimiters);
        }

        var numbersStrings = numbers.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries);

        return CalculateSum(numbersStrings);
    }

    private int CalculateSum(string[] numberStrings)
    {
        var parsedNumbers = numberStrings.Select(x => int.Parse(x));

        ThrowNegativeNumbersException(parsedNumbers);

        return parsedNumbers.Where(x => x <= 1000).Sum();
    }

    private void ThrowNegativeNumbersException(IEnumerable<int> numbers)
    {
        var negativeNumbers = numbers.Where(x => x < 0);

        if (!negativeNumbers.Any())
        {
            return;
        }

        var negativeNumbersExceptionStrings = negativeNumbers.Select(x => x.ToString());

        throw new Exception("Negatives not allowed: " + string.Join(", ", negativeNumbersExceptionStrings));
    }

    private IList<string> AddCustomDelimiters(string customDelimitersString, IList<string> delimiters)
    {
        if (!customDelimitersString.StartsWith('[') | !customDelimitersString.EndsWith(']'))
        {
            delimiters.Add(customDelimitersString);

            return delimiters;
        }

        var customDelimitersStrings = RemoveAllSquareBracket(customDelimitersString);

        foreach (var customDelimiter in customDelimitersStrings)
        {
            delimiters.Add(customDelimiter);
        }

        return delimiters;
    }

    private IList<string> RemoveAllSquareBracket(string customDelimitersWithBrackets)
    {
        var delimitersStringWithoutFirstBracket = customDelimitersWithBrackets.Remove(0, 1);

        var lastBracketIndex = delimitersStringWithoutFirstBracket.Length - 1;

        var delimitersStringWithoutFirstAndLastSquareBrackets = delimitersStringWithoutFirstBracket.Remove(lastBracketIndex);

        return delimitersStringWithoutFirstAndLastSquareBrackets.Split("][", StringSplitOptions.RemoveEmptyEntries);
    }
}

