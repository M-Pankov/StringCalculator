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

        IList<string> delimiters = new List<string>() { "\n", ",", @"\n" };

        if (numbers.StartsWith("//"))
        {
            var separatedDelimitersAndNumbers = SeparateCustomDelimitersAndNumbers(numbers);

            delimiters = AddCustomDelimiters(separatedDelimitersAndNumbers.First(), delimiters);

            numbers = separatedDelimitersAndNumbers.Last();
        }

        var stringsOfNumbers = numbers.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries);

        return CalculateSum(stringsOfNumbers);
    }

    private int CalculateSum(string[] numberStrings)
    {
        IList<int> validNumbers = new List<int>();

        validNumbers = numberStrings.Select(x => int.Parse(x)).ToList();

        ThrowNegativeNumbersException(validNumbers);

        return validNumbers.Where(x => x <= 1000).Sum();
    }

    private void ThrowNegativeNumbersException(IList<int> numbers)
    {
        var negativeNumbers = numbers.Where(x => x < 0);

        if (negativeNumbers.Any())
        {
            var negativeNumbersExceptionStrings = negativeNumbers.Select(x => x.ToString());

            throw new Exception("Negatives not allowed: " + string.Join(", ", negativeNumbersExceptionStrings));
        }
    }

    private IList<string> SeparateCustomDelimitersAndNumbers(string numbers)
    {
        var slashesEndIndex = 2;
        
        IList<string> separatedDelimitersAndNumbers = new List<string>();

        numbers = numbers.Remove(0, slashesEndIndex);

        var delimitersEndIndex = GetCustomDelimitersEndIndex(numbers);

        var customDelimiters = numbers.Substring(0, delimitersEndIndex);

        separatedDelimitersAndNumbers.Add(customDelimiters);

        var numbersString = numbers.Substring(delimitersEndIndex);

        separatedDelimitersAndNumbers.Add(numbersString);

        return separatedDelimitersAndNumbers;
    }

    private int GetCustomDelimitersEndIndex(string numbers)
    {
        int delimitersEndIndex = numbers.IndexOf("\n");

        if (delimitersEndIndex == -1)
        {
            delimitersEndIndex = numbers.IndexOf(@"\n");
        }

        return delimitersEndIndex;
    }

    private IList<string> AddCustomDelimiters(string customDelimitersString, IList<string> delimiters)
    {
        if (!customDelimitersString.StartsWith('[') | !customDelimitersString.EndsWith(']'))
        {
            delimiters.Add(customDelimitersString);

            return delimiters;
        }

        var customDelimiters = customDelimitersString.Split("][", StringSplitOptions.RemoveEmptyEntries);

        var lastDelimiterIndex = customDelimiters.Length - 1;

        var firstDelimiter = customDelimiters.First().Remove(0, 1);

        customDelimiters[0] = firstDelimiter;

        var lastDelimiter = customDelimiters.Last();

        customDelimiters[lastDelimiterIndex] = lastDelimiter.Remove(lastDelimiter.Length - 1);

        foreach (var customDelimiter in customDelimiters)
        {
            delimiters.Add(customDelimiter);
        }

        return delimiters;
    }
}

