using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator;

public class CustomStringCalculator
{
    public int Add(string numbers)
    {
        List<string> delimiters = new() { "\n", ",", @"\n" };

        if (string.IsNullOrEmpty(numbers))
        {
            return 0;
        }

        if (numbers.StartsWith("//"))
        {
            numbers = numbers.Remove(0, 2);

            delimiters = AddCustomDelimiters(numbers, delimiters, out int delimitersEndIndex);

            numbers = numbers.Substring(delimitersEndIndex);
        }

        var stringsToSum = numbers.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries);

        var sumResult = GetSumOfNumbers(stringsToSum);

        return sumResult;
    }

    private int GetSumOfNumbers(string[] numberStrings)
    {
        List<int> validNumbers = new();

        List<int> negativeNumbers = new();

        foreach (var numberString in numberStrings)
        {

            int.TryParse(numberString, out int numberStringParsResult);

            int parseValue = numberStringParsResult;

            if (parseValue < 0)
            {
                negativeNumbers.Add(parseValue);

                continue;
            }

            validNumbers.Add(parseValue);
        }

        if (negativeNumbers.Any())
        {
            var negativeNumbersExceptionStrings = negativeNumbers.ConvertAll(x => x.ToString());

            throw new Exception("Negatives not allowed: " + string.Join(", ", negativeNumbersExceptionStrings));
        }

        return validNumbers.Where(x => x <= 1000).Sum();
    }


    private List<string> AddCustomDelimiters(string numbersAndCustomDelimiters, List<string> delimiters, out int delimitersEndIndex)
    {
        delimitersEndIndex = numbersAndCustomDelimiters.IndexOf('\n');

        if (delimitersEndIndex == -1)
        {
            delimitersEndIndex = numbersAndCustomDelimiters.IndexOf(@"\n");
        }

        var delimitersInString = numbersAndCustomDelimiters.Substring(0, delimitersEndIndex);

        if (!delimitersInString.StartsWith('[') | !delimitersInString.EndsWith(']'))
        {
            delimiters.Add(delimitersInString);

            return delimiters.Distinct().ToList();
        }

        string currentDelimiter = string.Empty;

        int delimiterCurrentIndex = 0;

        while (delimiterCurrentIndex < delimitersInString.Length - 1)
        {

            if (delimitersInString[delimiterCurrentIndex + 1] == '[')
            {
                delimiters.Add(currentDelimiter.Remove(0, 1));

                currentDelimiter = string.Empty;

                delimiterCurrentIndex++;

                continue;
            }

            currentDelimiter += delimitersInString[delimiterCurrentIndex];

            delimiterCurrentIndex++;
        }

        delimiters.Add(currentDelimiter.Remove(0, 1));

        return delimiters.Where(x => !string.IsNullOrEmpty(x)).Distinct().ToList();
    }
}

