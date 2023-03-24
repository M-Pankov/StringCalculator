using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator;

public class CustomStringCalculator
{
    public virtual int Add(string numbers)
    {
        if (string.IsNullOrEmpty(numbers))
        {
            return 0;
        }

        IList<string> delimiters = new List<string>() { ",", @"\n" };

        if (numbers.StartsWith("//"))
        {
            var delimitersEndIndex = numbers.IndexOf(@"\n");

            delimiters = AddCustomDelimiters(numbers, delimiters, delimitersEndIndex);

            var onlyNumbers = numbers.Substring(delimitersEndIndex);

            return CalculateSum(onlyNumbers, delimiters);
        }

        return CalculateSum(numbers, delimiters);
    }

    private int CalculateSum(string numbers, IList<string> delimiters)
    {
        var maxNumber = 1000;

        var splitNumbers = numbers.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries);

        var parsedNumbers = splitNumbers.Select(x => int.Parse(x));

        ThrowExceptionIfNegativeNumbersExist(parsedNumbers);

        return parsedNumbers.Where(x => x <= maxNumber).Sum();
    }

    private void ThrowExceptionIfNegativeNumbersExist(IEnumerable<int> parsedNumbers)
    {
        var negativeNumbers = parsedNumbers.Where(x => x < 0);

        if (!negativeNumbers.Any())
        {
            return;
        }

        throw new Exception("Negatives not allowed: " + string.Join(", ", negativeNumbers));
    }

    private IList<string> AddCustomDelimiters(string numbers, IList<string> delimiters, int delimitersEndIndex)
    {
        var customDelimiters = SeparateCustomDelimiters(numbers, delimitersEndIndex);

        if (!customDelimiters.StartsWith('[') || !customDelimiters.EndsWith(']'))
        {
            delimiters.Add(customDelimiters);

            return delimiters;
        }

        var cleanDelimiters = RemoveAllSquareBrackets(customDelimiters);

        foreach (var cleanDelimiter in cleanDelimiters)
        {
            delimiters.Add(cleanDelimiter);
        }

        return delimiters;
    }

    private string SeparateCustomDelimiters(string numbers, int delimitersEndIndex)
    {
        var slashesEndIndex = 2;

        var numbersWithoutSlashes = numbers.Remove(0, slashesEndIndex);

        return numbersWithoutSlashes.Substring(0, delimitersEndIndex - slashesEndIndex);
    }

    private IEnumerable<string> RemoveAllSquareBrackets(string customDelimitersWithBrackets)
    {
        var delimitersWithoutFirstBracket = customDelimitersWithBrackets.Remove(0, 1);

        var lastBracketIndex = delimitersWithoutFirstBracket.Length - 1;

        var delimitersWithoutFirstAndLastBrackets = delimitersWithoutFirstBracket.Remove(lastBracketIndex);

        return delimitersWithoutFirstAndLastBrackets.Split("][", StringSplitOptions.RemoveEmptyEntries);
    }
}

